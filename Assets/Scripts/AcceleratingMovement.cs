using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class AcceleratingMovement : MonoBehaviour
{
 
     float Speed = 0.006f;
     float Acceleration = .07f; //How fast will object reach a maximum speed
     float initialPush = 0.03f;
 
 	// Use this for initialization
 	void Start()
    {
        
    }
 
 
 
 
    void Update()
    {

        Speed += Acceleration * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (initialPush < 0)
                initialPush = 0;
            initialPush += .005f;
            Speed += initialPush;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (initialPush > 0)
                initialPush = 0;
            initialPush -= .003f;
            Speed += initialPush;
            
        }
        
        if(Time.timeScale == 1)
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y);
    }
 }