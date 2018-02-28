using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;
    public bool isLocal;
    bool isClicked = false;

	// Use this for initialization
	void Start() {

    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;

            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            Collider2D[] col = Physics2D.OverlapPointAll(v);

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (this.gameObject == c.gameObject)
                    {
                        isClicked = true;
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if(isClicked)
            {
                mouse_pos = Input.mousePosition;
                mouse_pos.z = -20;
                object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
                mouse_pos.x = mouse_pos.x - object_pos.x;
                mouse_pos.y = mouse_pos.y - object_pos.y;
                angle = (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg) - 90;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
 