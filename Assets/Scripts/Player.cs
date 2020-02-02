using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex;
    public bool assigned = false;
    public GameObject[] models;
    
    void Awake() {
        this.playerIndex = Globals.playerIndex++;
    }

    void Start() {
        GameObject go = Instantiate(models[this.playerIndex], new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.parent = transform;
    }
}
