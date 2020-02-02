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
    public IntVariable trendingIndex;
    
    void Start() {
        if (onTrendChange == null) {
            onTrendChange = new OnTrendChangeEvent();
        }

        SetTrend();
        StartCoroutine(timer());
    }

    void SetTrend() {
        trend = (PotType)Random.Range(0, 3);
        currentTrendDuration = Random.Range(10, 30);
        trendingIndex.value = (int)trend;
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
            potDetector.GetPlayerScore(trend);
        }
    }
}
