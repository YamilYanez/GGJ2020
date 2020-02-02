using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnTrendChangeEvent : UnityEvent<PotType> { }

public class TrendingController : MonoBehaviour
{
    public PotType trend;
    public int currentTrendDuration;
    public OnTrendChangeEvent onTrendChange;
    
    void Start() {
        if (onTrendChange == null) {
            onTrendChange = new OnTrendChangeEvent();
        }

        SetTrend();
        StartCoroutine(timer());
    }

    void SetTrend() {
        Debug.Log("SCORES");
        Debug.Log(Globals.Score.getScoreFromPlayer(PlayerType.player1));
        trend = (PotType)Random.Range(0, 3);
        currentTrendDuration = Random.Range(10, 30);
        onTrendChange.Invoke(trend);
    }

    IEnumerator timer() {
        while(true) {
            yield return new WaitForSeconds(currentTrendDuration);
            GetPlayersScore();
            SetTrend();
        }
    }

    void GetPlayersScore() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++) {
            PotDetector potDetector = players[i].GetComponent<PotDetector>();
            Debug.Log(trend);
            potDetector.GetPlayerScore(trend);
        }
    }
}
