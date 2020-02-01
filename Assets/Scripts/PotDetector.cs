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

    // Start is called before the first frame update
    void Start()
    {
        pots = GameObject.FindGameObjectsWithTag("Pot");
        potDestroyer = GetComponent<PotDestroyer>();
        potRepairer = GetComponent<PotRepairer>();  
    }

    void Update() {
        if (pots == null || pots.Length == 0) return;
        GameObject closest = GetClosestPot(pots);
        if (closest != null) {
            bool isDestroyed = closest.GetComponent<PotSpotController>().type == PotType.None;
            Debug.Log(isDestroyed);
            if (!isDestroyed) {
                Debug.Log(closest);
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
}
