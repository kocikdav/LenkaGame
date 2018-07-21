using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Vector3 movementDir;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float lastDist;
    private float step;
    private bool moving = false;
    public bool MovingAnimation { get; set; }
    public float speed = 1f;
    private Rigidbody2D rb2d;
    private Animator animator;
	// Use this for initialization
	void Start () {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        endPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            endPosition = Input.mousePosition;
            endPosition = Camera.main.ScreenPointToRay(endPosition).origin;
            endPosition = endPosition + new Vector3(0, this.gameObject.GetComponent<Renderer>().bounds.size.y/3, 0);
            Debug.Log(this.gameObject.GetComponent<Renderer>().bounds.size.y);
            movementDir = (endPosition - startPosition).normalized;
            startPosition = transform.position;
            lastDist = Mathf.Sqrt(Mathf.Pow(transform.position.x - endPosition.x,2) + Mathf.Pow(transform.position.y - endPosition.y, 2));
            step = speed * Time.deltaTime;
            setMovementAnim(endPosition);
            moving = true;
            //Debug.Log(moving.ToString());
        }
        //Debug.Log(moving+ " " +Mathf.Approximately(transform.position.x, endPosition.x)+ " " +Mathf.Approximately(transform.position.y, endPosition.y));
        //if (moving && Mathf.Approximately(transform.position.x,endPosition.x) && Mathf.Approximately(transform.position.y, endPosition.y))
        float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - endPosition.x, 2) + Mathf.Pow(transform.position.y - this.gameObject.GetComponent<Renderer>().bounds.size.y / 3 - endPosition.y, 2));
        if(distance > lastDist)
        {
            moving = false;
            animator.SetInteger("movement", 0);
            rb2d.position = endPosition;
        }
        lastDist = distance;

        if(moving && MovingAnimation)
        {
            //Vector3 newPosition = Vector3.MoveTowards(rb2d.position, endPosition, speed* Time.deltaTime);

            //rb2d.transform.position = newPosition;


            //transform.Translate((endPosition - startPosition ) * Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x + movementDir.x*step,transform.position.y + movementDir.y * step,transform.position.z);
        }

        //Debug.Log(distance);
        //Debug.Log(endPosition.ToString() + transform.position.ToString());
        //Debug.Log(Time.deltaTime.ToString());
	}

    private void setMovementAnim(Vector3 tar)
    {
        Vector3 myp = transform.position;
        if(tar.x > myp.x && tar.y >myp.y)
        {
            animator.SetInteger("movement", 1);
        }else if(tar.x > myp.x && tar.y <= myp.y)
        {
            animator.SetInteger("movement", 2);
        }else if(tar.x <= myp.x && tar.y <= myp.y)
        {
            animator.SetInteger("movement", 3);
        }else
        {
            animator.SetInteger("movement", 4);
        }
    }

}
