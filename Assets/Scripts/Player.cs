using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex;
    void Awake() {
        this.playerIndex = Globals.playerIndex++;
    }
}
