using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PotDestroyer : MonoBehaviour
{
    public GameObject potToDestroy;
    public IntVariable trendingIndex;
    public IntVariable[] scores;
    Player player;
    GameObject[] players;

    void Start() {
        player = GetComponent<Player>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update() {
        if (Application.loadedLevelName != "Base") return;
        else {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
    }

    private void OnBreak(InputValue val) {
        if (potToDestroy != null) {
            PotSpotController potSpot = potToDestroy.GetComponent<PotSpotController>();
            for (int i = 0; i < players.Length; i++) {
                int playerIndex = players[i].GetComponent<Player>().playerIndex;
                if (playerIndex == (int)potSpot.owner && potSpot.type == (PotType)trendingIndex.value) {
                    scores[playerIndex].value--;
                }
            }
            potSpot.Hit();
        }
    }

    public void SetPotToDestroy(GameObject potToDestroy) {
        this.potToDestroy = potToDestroy;
    }
}