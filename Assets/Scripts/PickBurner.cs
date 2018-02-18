using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBurner : MonoBehaviour {

    float timer;

    public static int pickedBurner;
	// Use this for initialization
	void Start () {
        pickedBurner = RR();
        timer = 10f;
	}

    int RR()
    {
        return Random.Range(0,3);
    }

    IEnumerator startValue()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            int r = RR();
            while(r == pickedBurner)
            {
                r = RR();
            }
            pickedBurner = r;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
