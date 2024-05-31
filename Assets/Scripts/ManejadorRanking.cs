using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public List<PlayerScore> leaderboard = new List<PlayerScore>
    {
        new PlayerScore("Player1", 1500),
        new PlayerScore("Player2", 1200),
        new PlayerScore("Player3", 1000),
        new PlayerScore("Player4", 900),
        new PlayerScore("Player5", 800)
    };

    public List<PlayerScore> GetLeaderboard()
    {
        return leaderboard;
    }
}