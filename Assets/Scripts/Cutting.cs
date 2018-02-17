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
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("cutRoom");
        }
    }

    IEnumerator cutRoom()
    {
        cut = true;
        yield return new WaitForSeconds(1);
        cut = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(cut);
        if (cut)
        {
            if (coll.gameObject.tag == "carrot")
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
