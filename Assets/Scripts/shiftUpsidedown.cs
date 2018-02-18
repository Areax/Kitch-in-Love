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


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tempValue -= .01f;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            tempValue += .01f;
        }

        transform.Rotate(0, 0, tempValue);

    }
}