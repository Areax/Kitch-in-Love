using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnTime : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    bool isOn = false;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOn && PickBurner.stovePart[PickBurner.pickedBurner].GetComponentInChildren<ShiftObjectOnTime>().gameObject == this.gameObject)
        {
            ChangeSpriteTo2();
            isOn = true;
        }
        else if (PickBurner.stovePart[PickBurner.pickedBurner].GetComponentInChildren<ShiftObjectOnTime>().gameObject != this.gameObject && isOn)
        {
            ChangeSpriteTo1();
            isOn = false;
        }
    }

    void ChangeSpriteTo2()
    {
        spriteRenderer.sprite = sprite2;
    }

    void ChangeSpriteTo1()
    {
        spriteRenderer.sprite = sprite1;
    }
}
