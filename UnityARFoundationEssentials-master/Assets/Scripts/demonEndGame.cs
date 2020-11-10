using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class demonEndGame : MonoBehaviour
{
    public void endGame()
    {
        Analytics.CustomEvent("Game ended", new Dictionary<string, object>
        {
            {"Coins earned", DemonBattlescript.coinsInt },
            {"XP Earned", DemonBattlescript.xp },
            {"Account Level", DemonBattlescript.accountLevelInt }
        });

        SceneManager.LoadScene("MainMenu");
    }
}
