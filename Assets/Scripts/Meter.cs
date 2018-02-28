using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{

    public static float progress;
    public Transform knobProgress;
    private IEnumerator coroutine;
    float randomValue;
    float incValue;
    float timer;
    int currentBurner;

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

    // Use this for initialization
    void Start()
    {
        progress = 0.75f;
        timer = 8f;
        coroutine = startValue();
        StartCoroutine(coroutine);

        randomValue = 0f;
        incValue = 0f;

        currentBurner = -1;
    }

    // The larger the number, the greater the variance
    float randomRange(float p)
    {
        return Random.Range(p, -p);
    }

    float falseSigmoid(float value)
    {
        return (float)(value / (1 + Mathf.Abs(value)));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBurner != PickBurner.pickedBurner)
        {
            currentBurner = PickBurner.pickedBurner;

            foreach (Transform child in PickBurner.stovePart[PickBurner.pickedBurner].transform)
            {
                if (child.tag == "knob")
                {
                    knobProgress = child.transform; 
                }
            }
        }

        float p = (knobProgress.localEulerAngles.z / 360.0f);
        if(incValue != randomValue)
        {
            if (incValue < randomValue)
                incValue += .001f;
            else incValue -= .001f;
        }


        progress = (knobProgress.localEulerAngles.z / 360.0f) < .05 || (knobProgress.localEulerAngles.z / 360.0f) > .95 ? 0 : 1 - p + incValue + randomRange(falseSigmoid(.005f));

        this.gameObject.GetComponent<Image>().fillAmount = progress;
    }
}