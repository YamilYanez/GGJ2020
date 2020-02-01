using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotDestroyer : MonoBehaviour
{
    public UnityEvent onPotDestroyed;

    void Start() {
        if (onPotDestroyed == null) {
            onPotDestroyed = new UnityEvent();
        }
    }

    
}
