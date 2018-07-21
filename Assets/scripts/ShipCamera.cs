using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour {

    private float moveSpeed = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float camx = Input.mousePosition.x;
        if(camx > Screen.width /8 *7)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }else if(camx  < Screen.width / 8)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
	}


}
