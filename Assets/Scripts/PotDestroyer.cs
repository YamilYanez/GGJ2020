using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotDestroyer : MonoBehaviour
{
    Controls control;
    public UnityEvent onPotDestroyed;
    public GameObject potToDestroy;

    void Awake() {
        control = new Controls();
        control.Player.Destroy.permformed += ctx => OnPotDestroyed();
    }

    void Start() {
        if (onPotDestroyed == null) {
            onPotDestroyed = new UnityEvent();
        }
    }

    void OnPotDestroyed() {
        if (potToDestroy != null) {
            PotSpot potSpot = potToDestroy.GetComponent<PotSpot>();
            // potSpot.Destroy();
            onPotDestroyed.Invoke();
        } 
    }

    void SetPotToDestroy(GameObject potToDestroy) {
        this.potToDestroy = potToDestroy;
    }
}
