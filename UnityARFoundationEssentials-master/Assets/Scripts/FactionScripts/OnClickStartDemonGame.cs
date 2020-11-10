using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OnClickStartDemonGame : MonoBehaviour
{
    public void StartGame()
    {
        Analytics.CustomEvent("Demon Faction chosen");
        SceneManager.LoadScene("DemonFactionGame");
    }
}
