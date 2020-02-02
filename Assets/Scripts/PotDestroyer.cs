using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PotDestroyer : MonoBehaviour
{
    public GameObject potToDestroy;

    private void OnBreak(InputValue val) {
        if (potToDestroy != null) {
            PotSpotController potSpot = potToDestroy.GetComponent<PotSpotController>();
            potSpot.Hit();
        }
    }

    public void SetPotToDestroy(GameObject potToDestroy) {
        this.potToDestroy = potToDestroy;
    }
}