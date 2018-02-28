using UnityEngine;
using System.Collections;

public class shiftUpsidedown : MonoBehaviour
{
    private IEnumerator coroutine;
    float randomValue;
    float incValue;
    float timer;
    int currentBurner;
    float tempValue;
    float rotateVal;

    IEnumerator startValue()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            randomValue = randomRange(1);
            incValue += randomValue / 100f;
            timer = 2f + randomRange(1.5f);
        }
    }

    // Use this for initialization
    void Start()
    {
        coroutine = startValue();
        StartCoroutine(coroutine);

        randomValue = 0f;
        incValue = 0f;
        tempValue = 0f;
        rotateVal = 0f;
    }

    // The larger the number, the greater the variance
    float randomRange(float p)
    {
        return Random.Range(p, -p);
    }


    // Update is called once per frame
    void Update()
    {
        if (incValue != randomValue)
        {
            if (incValue < randomValue)
                incValue += .001f;
            else incValue -= .001f;
        }
        
        tempValue = transform.rotation.z + incValue;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateVal -= .025f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            rotateVal += .025f;
        }

        transform.Rotate(0, 0, tempValue + rotateVal);

        if(Mathf.Abs(transform.rotation.z) > .75)
        {
            Timer.timer = 0.0f;
        }

    }
}