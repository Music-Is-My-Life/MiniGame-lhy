using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : MonoBehaviour
{
    public KeyCode assignedKey;

    public Sprite KeyBoard_0;
    public Sprite KeyBoard_1;
    public Sprite KeyBoard_2;
    public Sprite KeyBoard_3;
    public Sprite SpaceSprite;

    void Start()
    {
        SetVisualRepresentation();
    }

    void SetVisualRepresentation()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        switch (assignedKey)
        {
            case KeyCode.LeftArrow:
                spriteRenderer.sprite = KeyBoard_0;
                break;
            case KeyCode.RightArrow:
                spriteRenderer.sprite = KeyBoard_1;
                break;
            case KeyCode.DownArrow:
                spriteRenderer.sprite = KeyBoard_2;
                break;
            case KeyCode.UpArrow:
                spriteRenderer.sprite = KeyBoard_3;
                break;
            case KeyCode.Space:
                spriteRenderer.sprite = SpaceSprite;
                break;
        }
    }

    public void SetKey(KeyCode key)
    {
        assignedKey = key;
        SetVisualRepresentation();
    }

    void Update()
    {
        if (Input.GetKeyDown(assignedKey))
        {   
            Destroy(gameObject);
        }
    }
}