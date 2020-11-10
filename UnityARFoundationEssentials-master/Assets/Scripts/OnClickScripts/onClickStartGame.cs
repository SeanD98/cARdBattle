using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class onClickStartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame(string sceneName)
    {
        Analytics.CustomEvent("Game Started");
        Dictionary<string, object> analyticData = new Dictionary<string, object>()
        {
            {"Test1", 1 },
            {"test2", 2 }
        };

        AnalyticsEvent.Custom("Game Started", analyticData);
        SceneManager.LoadScene(sceneName);

    }
}
