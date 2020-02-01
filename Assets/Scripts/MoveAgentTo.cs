using UnityEngine;
using UnityEngine.AI;

public class MoveAgentTo : MonoBehaviour
{
    public void MoveToPosition(Transform transform) {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = transform.position;        
    }
}
