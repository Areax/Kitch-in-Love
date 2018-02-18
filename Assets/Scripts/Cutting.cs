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

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && donezo)
        {
            StartCoroutine("cutRoom");
        }
    }

    IEnumerator cutRoom()
    {
        donezo = false;
        cut = true;
        spriteRenderer.sprite = sprite3;
        yield return new WaitForSeconds(0.10f);
        cut = false;
        Debug.Log("Made it here");
        yield return new WaitForSeconds(.33f);
        spriteRenderer.sprite = sprite1;
        donezo = true;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cut)
        {

            if (coll.gameObject.tag == "carrot")
            {
                //GRAB COMPONENT's SCRIPT THAT HAS THE 2 CUT SPRITES
                //RERENDER PARENT SPRITE AS THE NEW SMALLER CARROT SPRITE
                //RERENDER THE CUT PART OF THE SPRITE HAS A NEW INSTANTIATE GAME OBJECT
                Destroy(coll.gameObject);
                


            }
        }
    }
}
