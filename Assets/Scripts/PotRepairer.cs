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
            potSpot.Craft(PotType.Type1);
        } 
    }

    private void OnRepair2(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Type2);
        } 
    }

    private void OnRepair3(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Type3);
        } 
    }

    public void SetPotToRepair(GameObject potToRepair) {
        this.potToRepair = potToRepair;
    }
}
