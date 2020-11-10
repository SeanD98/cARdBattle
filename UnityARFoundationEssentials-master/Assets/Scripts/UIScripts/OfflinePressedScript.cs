using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OfflinePressedScript : MonoBehaviour
{
   public  void goToOfflineFactionChoice(string sceneName)
    {
        Analytics.CustomEvent("Offline Mode Chosen");
        SceneManager.LoadScene(sceneName);
    }
}
