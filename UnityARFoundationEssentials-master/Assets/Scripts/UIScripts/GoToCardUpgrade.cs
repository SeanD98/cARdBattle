using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GoToCardUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Analytics.CustomEvent("Card Upgrade store viewed");
    }
}
