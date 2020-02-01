using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public List<Transform> stops;
    public GameObject[] npcs;

    public int delay = 500;
    public Transform npcDefaultPosition;

    void Start() {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        Init(npcs);
    }

    void Init(GameObject[] npcs) {
        for (int i = 0; i < npcs.Length; i++) {
            var npc = npcs[i].GetComponent<NPC>();
            npc.readyToMove.RemoveAllListeners();
            npc.readyToMove.AddListener(assignNextGoal);
            npc.currentGoal = stops[0].position;
            npc.GetComponent<MoveAgentTo>().MoveToPosition(stops[0]);
        }
    }

    void assignNextGoal(NPC npc) {
        if (npc.currentGoalIndex >= stops.Count) resetNPCPosition(npc);
        Transform transform = stops[npc.currentGoalIndex++];
        npc.currentGoal = transform.position;
        npc.GetComponent<MoveAgentTo>().MoveToPosition(transform);
    }

    public void restartNPCRoute() {
        Init(npcs);
    }

    void resetNPCPosition(NPC npc) {
        npc.currentGoalIndex = 0;
        npc.currentGoal = npc.transform.position;
        npc.transform.position = npcDefaultPosition.position;
    }
}
