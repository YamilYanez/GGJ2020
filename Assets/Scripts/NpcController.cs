using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public List<Transform> stops;
    public GameObject[] npcs;

    public int delay = 500;

    void Start() {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        for (int i = 0; i < npcs.Length; i++) {
            var npc = npcs[i].GetComponent<NPC>();
            npc.readyToMove.AddListener(assignNextGoal);
            npc.currentGoal = stops[0].position;
            npc.GetComponent<MoveAgentTo>().MoveToPosition(stops[0]);
        }
    }

    void assignNextGoal(NPC npc) {
        if (npc.currentGoalIndex >= stops.Count) return;
        Transform transform = stops[npc.currentGoalIndex++];
        npc.currentGoal = transform.position;
        npc.GetComponent<MoveAgentTo>().MoveToPosition(transform);
    }
}
