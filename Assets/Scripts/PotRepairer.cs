using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PotRepairer : MonoBehaviour
{
    public GameObject potToRepair;

    private void OnRepair1(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Blue);
        } 
    }

    private void OnRepair2(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Green);
        } 
    }

    private void OnRepair3(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Red);
        } 
    }

    public void SetPotToRepair(GameObject potToRepair) {
        this.potToRepair = potToRepair;
    }
}
