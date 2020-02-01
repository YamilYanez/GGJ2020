﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public enum PlayerType
{
    player1, player2, player3, player4
}

public class PlayerScore
{
    PotType potType;
    int score;
}

public class Score
{
    private Dictionary<PlayerType, int> score = new Dictionary<PlayerType, int>();
    
    public void Reset()
    {
        score = new Dictionary<PlayerType, int>();
    }

    public void AddScoreToPlayer(PlayerType player)
    {
        if (!score.ContainsKey(player))
            score.Add(player, 0);
        score[player]++;
    }

    public int getScoreFromPlayer(PlayerType player)
    {
        return score[player];
    }
}

public static class Globals 
{
    public static Score Score { get; set; } = new Score();
}