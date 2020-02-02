using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayersModels
{
    public GameObject player1, player2, player3, player4;
}

[System.Serializable]
public class ScoreResumeController : MonoBehaviour
{
    public PlayerType type;
    public TextMesh textMesh;

    public IntVariable total;

    public Transform origin;
    public GameObject[] potsPrefabs;

    bool once = false;

    public void Start()
    {
        textMesh.text = total.value.ToString();
        StartCoroutine(potSpawner(500));
    }

    IEnumerator potSpawner(float delay) {
        for (int i = 0; i < total.value; i++) {    
            GameObject pot = Instantiate(potsPrefabs[Random.Range(0, 3)], origin.position, Quaternion.identity);
            yield return new WaitForSeconds(delay * 0.001f);
        }
    }
}
