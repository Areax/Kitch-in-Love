using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnClick : MonoBehaviour
{

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
        if (Input.GetMouseButtonDown(0))
        {
            knife.gameObject.transform.localScale += new Vector3(0, -1, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y + lowerPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - lowerPosition);
            knife.gameObject.transform.localScale += new Vector3(0, 1, 0);
        }
    }

}
