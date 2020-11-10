using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OnlinePressedScript : MonoBehaviour
{
    public void goToOnlineFactionChoice(string sceneName)
    {
        Analytics.CustomEvent("Online Mode Chosen");
        SceneManager.LoadScene(sceneName);
    }
}
