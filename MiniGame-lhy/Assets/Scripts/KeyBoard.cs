using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : MonoBehaviour
{
    public KeyCode assignedKey; //객체의 key
    public Sprite KeyBoard_0; //좌
    public Sprite KeyBoard_1; //우
    public Sprite KeyBoard_2; //하
    public Sprite KeyBoard_3; //상
    public Sprite SpaceSprite; //스페이스바
    public int objectIndex;
    int keyState = 0; //키보드가 눌렸는지 체크하는 변수
    public static int mistake = 0;

    public void SetKeySprite(KeyCode key, int index)
    {
        assignedKey = key; //이 스프라이트의 키를 저장
        objectIndex = index;
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
        if (objectIndex == GameManager.turn)
        {
            if (Input.GetKeyDown(assignedKey))
            {
                keyState = 1;
            }
            if (keyState == 1 && !Input.anyKeyDown)
            {
                GameManager.turn++;
                Destroy(gameObject);
                keyState = 0;
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(assignedKey) && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
            {
                keyState = 0;
                foreach (GameObject keyboard in GameManager.spawnedKeyboards)
                {
                    Destroy(keyboard);
                }
                GameManager.spawnedKeyboards.Clear();
                mistake += 50000;
                Debug.Log("mistake = " + mistake);
                GameObject.FindWithTag("GM").GetComponent<GameManager>().increaseStageNum();
                GameObject.FindWithTag("GM").GetComponent<GameManager>().SpawnKeyBoards();
            }
        }
    }
}
