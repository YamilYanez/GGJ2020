using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotDetector : MonoBehaviour
{
    public float detectionRadius;
    GameObject[] pots;
    PotDestroyer potDestroyer;
    PotRepairer potRepairer;
    Player player;

    public IntVariable[] scores;

    // Start is called before the first frame update
    void Start()
    {
        pots = GameObject.FindGameObjectsWithTag("Pot");
        potDestroyer = GetComponent<PotDestroyer>();
        potRepairer = GetComponent<PotRepairer>();
        player = GetComponent<Player>();
        resetScores();
    }

    void Update() {
        if (pots == null || pots.Length == 0) return;
        GameObject closest = GetClosestPot(pots);
        if (closest != null) {
            bool isDestroyed = closest.GetComponent<PotSpotController>().type == PotType.None;
            if (!isDestroyed) {
                potDestroyer.SetPotToDestroy(closest);
            } else {
                potRepairer.SetPotToRepair(closest);
            }
        } else {
            potDestroyer.SetPotToDestroy(null);
            potRepairer.SetPotToRepair(null);
        }
    }

    GameObject GetClosestPot(GameObject[] pots) {
        if (pots == null || pots.Length == 0) return null;
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(GameObject potentialTarget in pots)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr && dSqrToTarget <= detectionRadius)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    public void GetPlayerScore(PotType potInTrend) {
        int score = 0;
        for (int i = 0; i < pots.Length; i++) {
            PotSpotController pot = pots[i].GetComponent<PotSpotController>();
            Debug.Log(pot.owner);
            Debug.Log(pot.type);
            if (player.playerIndex == (int)pot.owner && pot.type == potInTrend) {
                score++;
            }
        }
        Globals.Score.AddScoreToPlayer((PlayerType)player.playerIndex, score);
        resetScores();
    }

    public void resetScores() {
        for (int i = 0; i < scores.Length; i++) {
            scores[i].value = 0;
        }
    }
}
