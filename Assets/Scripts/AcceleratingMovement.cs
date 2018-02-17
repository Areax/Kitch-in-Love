using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingMovement : MonoBehaviour {

    float Speed = 0;
    float Acceleration = 70; //How fast will object reach a maximum speed
    float initialPush = 0.3f;

	// Use this for initialization
	void Start() {

    }




    void Update() {
        if(Input.GetKeyDown("d"))
        {
            transform.position = new Vector3(transform.position.x + initialPush, transform.position.y);
        }
        if ((Input.GetKey("d")))
            Speed = Speed + Acceleration * Time.deltaTime;
        else
            Speed = 0;

        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y);
    }
}
