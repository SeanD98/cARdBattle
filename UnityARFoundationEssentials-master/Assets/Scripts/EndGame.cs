using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void endGame()
    {
        Analytics.CustomEvent("Game ended", new Dictionary<string, object>
        {
            {"Coins earned", MonsterBattlescript.coinsInt },
            {"XP Earned", MonsterBattlescript.xp },
            {"Account Level", MonsterBattlescript.accountLevelInt }
        });

        SceneManager.LoadScene("MainMenu");
    }
}
