using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBurner : MonoBehaviour {

    public static int pickedBurner;
	// Use this for initialization
	void Start () {
        pickedBurner = RR();
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
            randomValue = randomRange(falseSigmoid(progress));
            incValue += randomValue / 100f;
            timer = 4f + randomRange(1.5f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
