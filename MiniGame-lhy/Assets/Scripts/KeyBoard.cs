using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : MonoBehaviour
{
    public KeyCode assignedKey; //��ü�� key
    public int index;
    public Sprite KeyBoard_0;
    public Sprite KeyBoard_1;
    public Sprite KeyBoard_2;
    public Sprite KeyBoard_3;
    public Sprite SpaceSprite;

    public void SetKeySprite(KeyCode key, int i)
    {
        assignedKey = key; //�� ��������Ʈ�� Ű�� ����
        index = i;
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


    void Update()
    {
        if (Input.GetKeyDown(assignedKey) && index == GameManager.turn)
        {
            GameManager.turn++;
            Destroy(gameObject);
        }
    }
}
