using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] keyBoardPrefabs;
    public KeyCode[] possibleKeys;

    public Transform keySpawnArea;
    public float xOffset = 1.5f; // X축 간격 조절 값

    private void Start()
    {
        SpawnKeyBoards(keySpawnArea);
    }

    void SpawnKeyBoards(Transform keySpawnArea)
    {

        for (float i = -3.0f; i <= 3.0f; i+=1.5f)
        {
            float xPos = keySpawnArea.position.x + i * xOffset;
            Vector3 spawnPosition = new Vector3(xPos, keySpawnArea.position.y, keySpawnArea.position.z);
            GameObject selectedPrefab = keyBoardPrefabs[Random.Range(0, keyBoardPrefabs.Length)];
            GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            KeyBoard keyScript = keyObject.GetComponent<KeyBoard>();
            keyScript.SetKey(possibleKeys[Random.Range(0, possibleKeys.Length)]);
        }
    }
}