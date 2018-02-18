using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftObjectOnTime : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public int number = -1;
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
        if (!isOn && PickBurner.pickedBurner == number)
        {
            ChangeSpriteTo2();
            isOn = true;
        }
        else if (PickBurner.pickedBurner != number && isOn)
        {
            ChangeSpriteTo1();
            isOn = false;
        }
    }

    void ChangeSpriteTo2()
    {
        spriteRenderer.sprite = sprite1;
    }

    void ChangeSpriteTo1()
    {
        spriteRenderer.sprite = sprite2;
    }
}
