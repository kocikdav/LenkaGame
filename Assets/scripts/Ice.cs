using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour {

    private Animator animator;

	private void OnMouseDown()
	{
        //Debug.Log("clicked");
        animator.SetTrigger("disolve");
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
