using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ReadyToMoveEvent : UnityEvent<NPC> { }

public class NPC : MonoBehaviour
{
    public Vector3 currentGoal;
    public int currentGoalIndex;
    public float minDistance;

    public float delay = 500;
    public ReadyToMoveEvent readyToMove;

    void Awake() {
        if (readyToMove == null) {
            readyToMove = new ReadyToMoveEvent();
        }
    }

    void Update() {
        float dist = Vector3.Distance(transform.position, currentGoal);
        
        if (dist <= minDistance) {
            readyToMove.Invoke(this);
        }
    }

    IEnumerator moveToNextPoint() {
        yield return new WaitForSeconds(delay * 0.001f);
    }
}
