using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDemonGameOffline : MonoBehaviour
{
    public void StartOfflineDemonGame()
    {
        SceneManager.LoadScene("DemonFactionGameOffline");
    }
}
