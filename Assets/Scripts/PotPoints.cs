using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPoints : MonoBehaviour {

    bool hitPot;
    bool increaseScore;
    Vector3 p;

    // Use this for initialization
    void Start () {
        increaseScore = false;
        hitPot = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(increaseScore && hitPot)
        {
            Score.score++;
        }
        if (Meter.progress > .45f && Meter.progress < .486f)
        {
            increaseScore = true;
        }
        else
        {
            increaseScore = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "burner")
        {
            hitPot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "burner")
        {
            hitPot = false;
            increaseScore = false;
        }
    }
}
