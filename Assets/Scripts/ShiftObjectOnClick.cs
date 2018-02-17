using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnClick : MonoBehaviour {

    public int lowerPosition = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - lowerPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + lowerPosition);
        }
	}
}
