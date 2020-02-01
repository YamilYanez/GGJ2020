using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PotInTrend {
    Type1, Type2, Type3
}

[System.Serializable]
public class OnTrendChangeEvent : UnityEvent<PotInTrend> { }

public class TrendingController : MonoBehaviour
{
    public PotInTrend trend;
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
        trend = (PotInTrend)Random.Range(0, 3);
        currentTrendDuration = Random.Range(10, 30);
        onTrendChange.Invoke(trend);
    }

    IEnumerator timer() {
        while(true) {
            yield return new WaitForSeconds(currentTrendDuration);
            SetTrend();
        }
    }
}
