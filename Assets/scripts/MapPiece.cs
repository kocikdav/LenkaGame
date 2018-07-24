using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour {

    public int XCoord { get; set; }
    public int YCoord { get; set; }
    MapEmptyPiece emptyPiece;
	// Use this for initialization
	void Start () {
        emptyPiece = GameObject.Find("Hole").GetComponent<MapEmptyPiece>();
        XCoord = 0;
        YCoord = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        Debug.Log("OnMouse");
        if((emptyPiece.XCoord == XCoord && (emptyPiece.YCoord == YCoord + 1 || emptyPiece.YCoord == YCoord - 1))|| (emptyPiece.YCoord == YCoord && (emptyPiece.XCoord == XCoord + 1 || emptyPiece.XCoord == XCoord - 1)))
        {
            Debug.Log("Hit");
            Vector3 pos = transform.position;
            this.transform.position = emptyPiece.transform.position;
            emptyPiece.transform.position = pos;
        }
    }

}
