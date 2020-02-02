using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class OnTrendChangeEvent : UnityEvent<PotType> { }

public class TrendingController : MonoBehaviour
{
    public int maxTrendings = 5;
    int trendingCount = 0;
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
        int rand = -1;
        do {
            rand = Random.Range(0, 3);
        } while (rand == (int)trend);
        
        trend = (PotType)rand;
        currentTrendDuration = Random.Range(10, 15);
        trendingIndex.value = (int)trend;
        onTrendChange.Invoke(trend);
        trendingCount++;
    }

    IEnumerator timer() {
        while(true) {
            yield return new WaitForSeconds(currentTrendDuration);
            GetPlayersScore();
            yield return new WaitForSeconds(0.5f);
            if (trendingCount >= maxTrendings) SceneManager.LoadScene(2);
            SetTrend();
            // recalculateScores(trend);
        }
    }

    void GetPlayersScore() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++) {
            PotDetector potDetector = players[i].GetComponent<PotDetector>();
            potDetector.GetPlayerScore(trend);
        }
    }

    void recalculateScores(PotType nextTrending) {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++) {
            PotDetector potDetector = players[i].GetComponent<PotDetector>();
            potDetector.recalculateScore(nextTrending);
        }
    }
}
