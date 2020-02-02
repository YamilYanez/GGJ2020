using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnStart(InputValue val) {
        SceneManager.LoadScene(1);
    }

    private void OnMoveLeft(InputValue val) {
        Debug.Log("Move");
    }

    private void OnMoveRight(InputValue val) {
        Debug.Log("MR");
    }
}

