using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayersModels
{
    public GameObject player1, player2, player3, player4;
}

[System.Serializable]
public class ScoreResumeController : MonoBehaviour
{
    public PlayerType type;
    public TextMesh textMesh;
    public void Start()
    {
        Globals.Score.AddScoreToPlayer(PlayerType.player1);
        Globals.Score.AddScoreToPlayer(PlayerType.player1);
        Globals.Score.AddScoreToPlayer(PlayerType.player1);
        Globals.Score.AddScoreToPlayer(PlayerType.player1);

        Globals.Score.AddScoreToPlayer(PlayerType.player2);

        Globals.Score.AddScoreToPlayer(PlayerType.player3);
        Globals.Score.AddScoreToPlayer(PlayerType.player3);
        Globals.Score.AddScoreToPlayer(PlayerType.player3);
        Globals.Score.AddScoreToPlayer(PlayerType.player3);
        Globals.Score.AddScoreToPlayer(PlayerType.player3);


        Globals.Score.AddScoreToPlayer(PlayerType.player4);
        Globals.Score.AddScoreToPlayer(PlayerType.player4);


        textMesh.text = Globals.Score.getScoreFromPlayer(type).ToString();
    }
}
