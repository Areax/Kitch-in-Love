using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNew : MonoBehaviour {

    public GameObject createableObject;
    public Transform createLocation;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(createableObject, createLocation);
        }
	}
}
