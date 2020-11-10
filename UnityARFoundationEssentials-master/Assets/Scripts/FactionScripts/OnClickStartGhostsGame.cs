using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OnClickStartGhostsGame : MonoBehaviour
{
    public void StartGame()
    {
        Analytics.CustomEvent("Ghost Faction chosen");
        SceneManager.LoadScene("GhostFactionGame");
    }
}
