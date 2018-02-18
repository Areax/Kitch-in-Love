using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour
{

    public static float progress;
    public Vector2 pos;
    public Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
    public Transform knobProgress;
    private IEnumerator coroutine;
    float randomValue;
    float incValue;
    float timer;

    void OnGUI()
    {

        float posX = Screen.width * pos.x;
        float posY = Screen.height * pos.y;

        //draw the background:
        GUI.BeginGroup(new Rect(posX, posY, size.x, size.y));
        GUI.DrawTexture(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        //GUI.BeginGroup(new Rect(0, 0, size.x * progress, size.y));
        //GUI.DrawTexture(new Rect(0,0, size.x, size.y), fullTex);
        //draw the filled-in part FLIPPED:
        int yProg = (int)(size.y * progress);
        GUI.BeginGroup(new Rect(0, size.y - yProg, size.x, yProg));
        GUI.DrawTexture(new Rect(0, -size.y + yProg, size.x, size.y), fullTex);

        GUI.EndGroup();
        GUI.EndGroup();
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

    // Use this for initialization
    void Start()
    {
        progress = 0.75f;
        timer = 8f;
        pos = new Vector2(0.837f, 0.12f);
        size = new Vector2(14.5f, 110f);
        coroutine = startValue();
        StartCoroutine(coroutine);

        randomValue = 0f;
        incValue = 0f;
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
        float p = (knobProgress.localEulerAngles.z / 360.0f);
        if(incValue != randomValue)
        {
            if (incValue < randomValue)
                incValue += .001f;
            else incValue -= .001f;
        }

        progress = (knobProgress.localEulerAngles.z / 360.0f) < .05 || (knobProgress.localEulerAngles.z / 360.0f) > .95 ? 0 : 1 - p + incValue + randomRange(falseSigmoid(.005f));

    }
}