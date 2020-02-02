using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public GameObject[] MenuControls;
    public GameObject[] prefabCharacters;

    void Start() {
        for (int i = 0; i < MenuControls.Length; i++) {
            MenuControls[i].SetActive(false);
        }
    }

    void Update() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++) {
                RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
                rt.Create();
                Camera pCam = players[i].GetComponentInChildren<Camera>();
                pCam.targetTexture = rt;
                RawImage rawImage = MenuControls[i].transform.GetChild(3).GetComponent<RawImage>();
                rawImage.texture = rt;
                MenuControls[i].SetActive(true);
        }
    }
}
