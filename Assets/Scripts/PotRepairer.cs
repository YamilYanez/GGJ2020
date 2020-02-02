using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PotRepairer : MonoBehaviour
{
    public GameObject potToRepair;
    public IntVariable[] scores;
    public IntVariable trendingPot;
    Player player;

    void Start() {
        player = GetComponent<Player>();
    }

    public void checkScore(PotType newPot) {
        if ((int)newPot == trendingPot.value) {
            scores[player.playerIndex].value++;
        }
    }

    private void OnRepair1(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Type1, player.playerIndex);
            checkScore(potSpot.type);
        } 
    }

    private void OnRepair2(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Type2, player.playerIndex);
            checkScore(potSpot.type);
        } 
    }

    private void OnRepair3(InputValue val) {
        if (potToRepair != null) {
            PotSpotController potSpot = potToRepair.GetComponent<PotSpotController>();
            potSpot.Craft(PotType.Type3, player.playerIndex);
            checkScore(potSpot.type);
        } 
    }

    public void SetPotToRepair(GameObject potToRepair) {
        this.potToRepair = potToRepair;
    }
}
