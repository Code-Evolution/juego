using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public ManejadorRanking manejadorRanking;
    public Text leaderboardText;


    public void mostrar(){
        Debug.Log("hola");
    }

    private void UpdateLeaderboard()
    {
        List<PlayerScore> leaderboard = manejadorRanking.GetLeaderboard();
        leaderboardText.text = "";
        foreach (PlayerScore playerScore in leaderboard)
        {
            leaderboardText.text += playerScore.playerName + ": " + playerScore.score + "\n";
        }
    }
}