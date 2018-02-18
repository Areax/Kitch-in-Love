using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnClick : MonoBehaviour
{

    private Vector3 knifePosition;
    public float moveSpeed = 0.05f;
    public int lowerPosition = 1;
    GameObject knife;
    float timer = .5f;
    float randomValue = 1f;
    float incValue = 0.01f;

    // Use this for initialization
    void Start()
    {
        knife = GameObject.Find("Knife");
        IEnumerator c = startValue();
        StartCoroutine(c);
    }

    IEnumerator startValue()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            randomValue = randomRange(200);
            incValue = randomValue / 100f;
            timer = .2f;
        }
    }

    float randomRange(float p)
    {
        return Random.Range(p, -p);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            knifePosition = Input.mousePosition;
            knifePosition = Camera.main.ScreenToWorldPoint(knifePosition);
            knifePosition.y = -0.7f;
            knifePosition.x += incValue;

            if(knifePosition.x < -2.2f)
            {
                knifePosition.x = -2.2f;
            }
            if (knifePosition.x > 3.2f)
            {
                knifePosition.x = 3.2f;
            }
            transform.position = Vector2.Lerp(transform.position, knifePosition, moveSpeed);
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.position = new Vector3(0.35f, -0.77f, 0f);
        }

    }

    }