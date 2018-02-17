using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {

    public bool cut = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Input.GetMouseButtonDown(0))
        {
            cut = true;
        }
        if (cut)
        {
            if (coll.gameObject.tag == "carrot")
            {
                Destroy(coll.gameObject);
            }
        }
        cut = false;
    }
}
