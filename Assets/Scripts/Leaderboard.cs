using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public ManejadorRanking manejadorRanking;
    public Text leaderboardText;

    private void Start()
    {
        UpdateLeaderboard();
    }

    public void UpdateLeaderboardUI()
    {
        List<PlayerScore> leaderboard = manejadorRanking.GetLeaderboard();
        leaderboardText.text = "";
        foreach (PlayerScore playerScore in leaderboard)
        {
            leaderboardText.text += playerScore.playerName + ": " + playerScore.score + "\n";
        }
    }
}