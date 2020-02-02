using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrendingImageSelector : MonoBehaviour
{

    public Sprite[] spritePool;
    Image currentImage;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<Image>();
        if(currentImage == null)
            Debug.Log("Image component not found");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrendChange(PotType type) {
        int index = (int)type;
        Debug.Log(index);
        if(index >= spritePool.Length)
            return;
        if(currentImage != null)
            currentImage.sprite = spritePool[index];
    }
}
