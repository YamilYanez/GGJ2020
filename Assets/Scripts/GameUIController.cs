using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PotSprites {
    public Sprite[] sprites;
}

public class GameUIController : MonoBehaviour
{
    public IntVariable trendingIndex;
    public Image potPlayer1;
    public Image potPlayer2;
    public Image potPlayer3;
    public Image potPlayer4;

    public Image potCountP1;
    public Image potCountP2;
    public Image potCountP3;
    public Image potCountP4;

    public Sprite[] numbers;
    public PotSprites[] pots;

    public IntVariable potCountPlayer1;
    public IntVariable potCountPlayer2;
    public IntVariable potCountPlayer3;
    public IntVariable potCountPlayer4;

     void Update() {
         UpdatePots();
         UpdateScores();
    }

    void UpdatePots() {
        potPlayer1.sprite = pots[0].sprites[trendingIndex.value];
        potPlayer2.sprite = pots[1].sprites[trendingIndex.value];
        potPlayer3.sprite = pots[2].sprites[trendingIndex.value];
        potPlayer4.sprite = pots[3].sprites[trendingIndex.value];
    }

    void UpdateScores() {
        potCountP1.sprite = numbers[potCountPlayer1.value];
        potCountP2.sprite = numbers[potCountPlayer2.value];
        potCountP3.sprite = numbers[potCountPlayer3.value];
        potCountP4.sprite = numbers[potCountPlayer4.value];
    }
}
