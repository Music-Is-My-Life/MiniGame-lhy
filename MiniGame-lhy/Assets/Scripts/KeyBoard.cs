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
    private int objectIndex;
    private static int stageNum = 1;
    int buttonState = 0; //키보드가 눌렸는지 체크하는 변수 

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
        if (stageNum > 5)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif

            stageNum = 1;
        }


        if (objectIndex == GameManager.turn)
        {
            if (Input.GetKeyDown(assignedKey))
            {
                buttonState = 1;
            }
            else
            {
                if (buttonState == 1)
                {
                    GameManager.turn++;
                    Destroy(gameObject);
                    buttonState = 0;
                }
            }
        }

        if (GameManager.turn == 9)
        {
            stageNum++;
            Debug.Log("현재 스테이지 번호 : " + stageNum);
            GameManager.turn = 0;
            GameObject.Find("GameManager").GetComponent<GameManager>().SpawnKeyBoards();
        }
    }
}
