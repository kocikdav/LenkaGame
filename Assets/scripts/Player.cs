using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Actions
    {
        START,
        WALK,
        JUMP,
        ICE,
        STOP
    }
    Vector3 movementDir;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float lastDist;
    private float step;
    public bool Moving { get; set; }
    public bool MovingAnimation { get; set; }
    public float speed = 1f;
    private Rigidbody2D rb2d;
    private Animator animator;
    Queue<Vector3> targets;
    Queue<Actions> actions;
    Queue<Animator> otherAnimators;
    Actions currentAction;
    bool doingActions;
    // Use this for initialization
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        endPosition = transform.position;
        targets = new Queue<Vector3>();
        actions = new Queue<Actions>();
        otherAnimators = new Queue<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //addTarget(Input.mousePosition, false);
            //moveTo(Input.mousePosition);
        }
        //Debug.Log(moving+ " " +Mathf.Approximately(transform.position.x, endPosition.x)+ " " +Mathf.Approximately(transform.position.y, endPosition.y));
        //if (moving && Mathf.Approximately(transform.position.x,endPosition.x) && Mathf.Approximately(transform.position.y, endPosition.y))
        float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - endPosition.x, 2) + Mathf.Pow(transform.position.y - this.gameObject.GetComponent<Renderer>().bounds.size.y / 3 - endPosition.y, 2));
        //Debug.Log("d: "+ Mathf.Approximately(transform.position.x, endPosition.x).ToString() + " vs "+ Mathf.Approximately(transform.position.y, endPosition.y).ToString());
        //Debug.Log("d: " + transform.position.x.ToString() + " vs " + endPosition.x.ToString());

        //if (distance > lastDist /*&& Moving && MovingAnimation */&& currentAction == Actions.WALK)
        if (currentAction == Actions.WALK /*&& Moving && MovingAnimation */&& Mathf.Approximately(transform.position.x, endPosition.x) && Mathf.Approximately(transform.position.y, endPosition.y))
        {
            Moving = false;
            animator.SetInteger("movement", 0);
            rb2d.position = endPosition;
            Debug.Log("set to endPos" + endPosition.ToString()+" "+distance.ToString() + " vs "+lastDist.ToString());
            distance = 0f;
        }
        lastDist = distance;

        if (currentAction == Actions.JUMP && Moving && MovingAnimation)
        {
            Moving = false;
            animator.SetInteger("movement", 0);
        }

        if (Moving && MovingAnimation)
        {
            setMovementAnim(endPosition);
            Vector3 newPosition = Vector3.MoveTowards(rb2d.position, endPosition, speed* Time.deltaTime);

            rb2d.transform.position = newPosition;


            //transform.Translate((endPosition - startPosition ) * Time.deltaTime * speed);

            //Debug.Log(transform.position.x.ToString() + (movementDir.x * step).ToString() + transform.position.y.ToString() + (movementDir.y * step).ToString());
            float xstep = transform.position.x + (endPosition.x > transform.position.x ? Mathf.Abs(movementDir.x) * step : -Mathf.Abs(movementDir.x) * step);
            float ystep = transform.position.y + (endPosition.y > transform.position.y ? Mathf.Abs(movementDir.y) * step : -Mathf.Abs(movementDir.y) * step);
            //transform.position = new Vector3(xstep, ystep, transform.position.z);
            //transform.position = endPosition;
            Debug.Log(endPosition.ToString() + transform.position.ToString());
        }
        //Debug.Log(Moving.ToString()  + MovingAnimation.ToString());
        if (!Moving && !MovingAnimation)
        {
            NextAction();
        }
        //Debug.Log(distance);
        //Debug.Log(endPosition.ToString() + transform.position.ToString());
        //Debug.Log(Time.deltaTime.ToString());
    }

    private void MoveTo(Vector3 tar)
    {
        Debug.Log("MOVE TO");
        endPosition = tar;
        //endPosition = Camera.main.ScreenPointToRay(endPosition).origin;
        endPosition = endPosition + new Vector3(0, this.gameObject.GetComponent<Renderer>().bounds.size.y / 3 * this.transform.localScale.y, 0);
        Debug.Log("New pos" + endPosition.ToString());
        movementDir = (endPosition - startPosition).normalized;

        startPosition = transform.position;
        lastDist = Mathf.Sqrt(Mathf.Pow(transform.position.x - endPosition.x, 2) + Mathf.Pow(transform.position.y - endPosition.y, 2));
        step = speed * Time.deltaTime;
        setMovementAnim(endPosition);
        Moving = true;
    }

    private void MakeJump()
    {
        Debug.Log("JUMP");
        Moving = true;
        animator.SetInteger("movement", 9);
    }

    private void PlayIce()
    {
        if (otherAnimators.Count == 0)
        {
            return;
        }
        otherAnimators.Peek().SetTrigger("disolve");
        otherAnimators.Dequeue();
    }

    private void AddTarget(Vector3 tar, bool clear)
    {
        if (clear)
        {
            targets.Clear();
        }
        targets.Enqueue(tar);
    }

    public void AddAction(Actions action,Vector3 pos, Animator animator)
    {
        if (doingActions)
        {
            return;
        }
        switch (action)
        {
            case Actions.WALK:
                AddTarget(pos,false);
                break;
            case Actions.JUMP:
                break;
            case Actions.ICE:
                otherAnimators.Enqueue(animator);
                break;
            case Actions.STOP:
                doingActions = true;
                break;
            default:
                break;
        }
        actions.Enqueue(action);
    }

    private void NextAction()
    {
        if (actions.Count == 0)
        {
            return;
        }
        Debug.Log("SUCCESS NA");
        currentAction = actions.Peek();
        switch (currentAction)
        {
            case Actions.WALK:
                MoveTo(targets.Peek());
                targets.Dequeue();
                break;
            case Actions.JUMP:
                MakeJump();
                break;
            case Actions.ICE:
                PlayIce();
                break;
            case Actions.START:
                doingActions = true;
                break;
            case Actions.STOP:
                doingActions = false;
                break;
            default:
                break;
        }
        actions.Dequeue();
    }


    private void setMovementAnim(Vector3 tar)
    {
        //1:BR 2:R 3:FR 4:F 5:FL 6:L 7:BL (8:B)
        Vector3 myp = transform.position;
        if (tar.x > myp.x && tar.y > myp.y)
        {
            animator.SetInteger("movement", 1);
        }
        else if (Mathf.Abs(tar.y - myp.y)<0.5f && tar.x > myp.x)
        {
            animator.SetInteger("movement", 2);
        }
        else if (tar.x > myp.x && tar.y < myp.y)
        {
            animator.SetInteger("movement", 3);
        }
        else if (Mathf.Abs(tar.x - myp.x) < 0.5f && tar.y < myp.y)
        {
            animator.SetInteger("movement", 4);
        }
        else if (tar.x < myp.x && tar.y < myp.y)
        {
            animator.SetInteger("movement", 5);
        }
        else if (Mathf.Abs(tar.y - myp.y) < 0.5f && tar.x < myp.x)
        {
            animator.SetInteger("movement", 6);
        }
        else if (Mathf.Abs(tar.x - myp.x) < 0.5f && tar.y >
            myp.y)
        {
            animator.SetInteger("movement", 8);
        }
        else
        {
            animator.SetInteger("movement", 7);
        }
    }

}
