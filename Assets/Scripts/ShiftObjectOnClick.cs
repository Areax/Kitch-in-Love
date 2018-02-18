using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnClick : MonoBehaviour
{

    private Vector3 knifePosition;
    public float moveSpeed = 0.05f;
    public int lowerPosition = 1;
    GameObject knife;
    // Use this for initialization
    void Start()
    {
        knife = GameObject.Find("Knife");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            knifePosition = Input.mousePosition;
            knifePosition = Camera.main.ScreenToWorldPoint(knifePosition);
            knifePosition.y = -0.7f;
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