using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OnClickStartMonsterGame : MonoBehaviour
{
    public void StartGame()
    {
        Analytics.CustomEvent("Monster Faction Chosen");
        AnalyticsEvent.Custom("Monster Faction Chosen");
        SceneManager.LoadScene("MonsterFactionGame");
    }
}
