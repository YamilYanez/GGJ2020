using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnPotDetectedEvent : UnityEvent<GameObject> { }

public class PotDetector : MonoBehaviour
{
    public float detectionRadius;
    GameObject[] pots;

    public OnPotDetectedEvent onPotDetected;

    // Start is called before the first frame update
    void Start()
    {
        pots = GameObject.FindGameObjectsWithTag("Pot");

        if (onPotDetected == null) {
            onPotDetected = new OnPotDetectedEvent();
        }
    }

    void Update() {
        GameObject closest = GetClosestPot(pots);
        if (closest) {
            onPotDetected.Invoke(closest);
        } else {
            onPotDetected.Invoke(null);
        }
    }

    GameObject GetClosestPot(GameObject[] pots) {
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
