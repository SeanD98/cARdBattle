using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class endGameGhost : MonoBehaviour
{
    public void endGame()
    {
        Analytics.CustomEvent("Game ended", new Dictionary<string, object>
        {
            {"Coins earned", GhostBattlescript.coinsInt },
            {"XP Earned", GhostBattlescript.xp },
            {"Account Level", GhostBattlescript.accountLevelInt }
        });

        SceneManager.LoadScene("MainMenu");
    }
}
