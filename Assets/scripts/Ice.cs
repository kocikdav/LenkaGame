using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour {

    private Animator animator;
    bool clicked = false;
	private void OnMouseDown()
	{
        if (clicked)
        {
            return;
        }
        clicked = true;
        //Debug.Log("clicked");
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        pl.AddAction(Player.Actions.START, this.transform.position, null);
        if (this.name == "Kra1")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, 0, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, 0, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
        }
        else if (this.name == "Kra2")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, -0.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, -0.5f, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
        }
        else if (this.name == "Kra3")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2.5f, -0.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2.5f, -0.5f, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
        }
        else if(this.name == "Kra4")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(5, 1, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(5, 1, 0), null);
        }
        else if (this.name == "Kra5")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(5.8f, 1.8f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(-0.7f, 1.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(-0.7f, 0, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(-0.7f, 0, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(-0.7f, 1.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(5.8f, 1.8f, 0), null);
        }
        else if (this.name == "Kra7")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(4, 0, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, -0.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(2, -0.5f, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(4, 0, 0), null);
        }
        else if (this.name == "Kra8")
        {
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(6f, 1.8f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position + new Vector3(0, 0.5f, 0), null);
            pl.AddAction(Player.Actions.JUMP, this.transform.position, null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1, 0), null);
            pl.AddAction(Player.Actions.ICE, this.transform.position, animator);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(0, 1.5f, 0), null);
            pl.AddAction(Player.Actions.WALK, this.transform.position - new Vector3(6f, 1.8f, 0), null);
        }

        pl.AddAction(Player.Actions.STOP, this.transform.position, null);
        //animator.SetTrigger("disolve");
    }
	// Use this for initialization
	void Start () {
        //Debug.Log("started");
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
