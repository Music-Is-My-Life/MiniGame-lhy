using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] keyBoardPrefabs; //키보드 이미지를 가진 오브젝트 리스트
    public KeyCode[] possibleKeys; //실제 입력할 키보드 리스트 (방향키, 스페이스바)

    //public Transform keySpawnArea; // 키보드가 스폰할 지역 (BackGround 오브젝트)
    public float xOffset = 1.5f; // X축 간격 조절 값

    public static int turn; //지금 어떤 오브젝트를 입력할 차례인지 (0에서 시작)
    private static int stageNum = 1;
    public static List<GameObject> spawnedKeyboards = new List<GameObject>();

    [SerializeField]
    private TextMeshProUGUI stageNumText;
    [SerializeField]
    private TextMeshProUGUI moneyNumText;
    [SerializeField]
    private GameObject EndStagePanel;
    [SerializeField]
    private GameObject StageNumPanel;

    int money = 0;

    private void Start()
    {
        SpawnKeyBoards();
        StageNumPanel.SetActive(true);
    }

    public void SpawnKeyBoards()
    {
        foreach (GameObject keyboard in spawnedKeyboards)
        {
            Destroy(keyboard);
        }
        spawnedKeyboards.Clear();

        int index = 0;   //현재 생성된 키보드 오브젝트가 몇번째로 생성됐는지 나타내는 index변수

        for (float i = -6.0f; i <= 6.0f; i += xOffset) // -6 -4.5 -3 -1.5 0 1.5 3 4.5 6 총 9개 생성
        {
            float xPos = i; // 스폰될 오브젝트의 x좌표
            Vector3 spawnPosition = new Vector3(xPos, 0, 0); //스폰좌표를 vector3로 설정
            int randNum = Random.Range(0, possibleKeys.Length);
            GameObject selectedPrefab = keyBoardPrefabs[randNum]; // 키보드 이미지 프리팹 중에서 랜덤으로 하나 오브젝트 뽑음
            GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity); //뽑은 오브젝트 생성
            spawnedKeyboards.Add(keyObject);
            KeyBoard keyScript = keyObject.GetComponent<KeyBoard>(); //생성된 오브젝트의 키보드 스크립트 가져오기
            keyScript.SetKeySprite(possibleKeys[randNum], index++); //index 변수 증가
        }
    }

    public void increaseStageNum()
    {
        stageNum++;
        stageNumText.SetText(stageNum.ToString());
        moneyManager();

    }

    public void moneyManager()
    {
        moneyNumText.SetText(money.ToString());
        money = 250000 - KeyBoard.mistake;
        Debug.Log("money = " + money);
    }

    public void Update()
    {
        if (stageNum > 5)
        {
            foreach (GameObject keyboard in spawnedKeyboards)
            {
                Destroy(keyboard);
            }
            spawnedKeyboards.Clear();
            StageNumPanel.SetActive(false);
            EndStagePanel.SetActive(true);
            stageNum = 1;
            money = 250000;
            KeyBoard.mistake = 0;
        }

        if (turn == 9)
        {
            turn = 0;
            increaseStageNum();

            if (stageNum < 6)
                SpawnKeyBoards();
        }

        // if (Timer.LimitTime < 0)
        // {
        //     StageNumPanel.SetActive(false);
        //     EndStagePanel.SetActive(true);
        //     stageNum = 1;
        //     Timer.LimitTime = 15f;
            
        //     foreach (GameObject keyboard in spawnedKeyboards)
        //     {
        //         Destroy(keyboard);
        //     }
        //     spawnedKeyboards.Clear();
        // }
        // //

        // if (turn == 9)
        // {
        //     turn = 0;
        //     increaseStageNum();
        //     SpawnKeyBoards();
        // }
    }
}