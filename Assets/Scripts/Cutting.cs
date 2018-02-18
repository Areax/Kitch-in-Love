using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {

    public bool cut = false;
    public bool donezo = true;
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite[] carrotParts;
    public Sprite[] deadCarrots;
    public static int ele = 0;
    bool cutOnce;
    public GameObject deadCarrot;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        ele = 0;
        cutOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && donezo)
        {
            StartCoroutine("cutRoom");
        }

        if (Input.GetMouseButtonUp(0) && !cutOnce)
        {
            if(Score.score > 0)
                Score.score -= 1;
        }
    }

    IEnumerator cutRoom()
    {
        donezo = false;
        cut = true;
        spriteRenderer.sprite = sprite3;
        yield return new WaitForSeconds(0.05f);
        cut = false;
        yield return new WaitForSeconds(.16f);
        cutOnce = false;
        spriteRenderer.sprite = sprite1;
        donezo = true;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cut)
        {

            if (coll.gameObject.tag == "carrot" && !cutOnce && ele < 12)
            {
                Score.score += ((ele * ele) / 3) + 3;
                cutOnce = true;
                coll.gameObject.GetComponent<SpriteRenderer>().sprite = carrotParts[ele];
                coll.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(coll.gameObject.GetComponent<BoxCollider2D>().offset.x-.66f, coll.gameObject.GetComponent<BoxCollider2D>().offset.y);
                deadCarrot.GetComponent<SpriteRenderer>().sprite = deadCarrots[11 - ele];
                Instantiate(deadCarrot, coll.transform.position, new Quaternion(0,0,0,0), coll.gameObject.transform.parent.gameObject.transform);
                
                ele++;


            }
        }
    }
}
