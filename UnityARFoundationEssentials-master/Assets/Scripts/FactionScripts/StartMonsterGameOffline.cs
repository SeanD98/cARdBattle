using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMonsterGameOffline : MonoBehaviour
{
    public void StartOfflineMonsterGame()
    {
        SceneManager.LoadScene("MonsterFactionGameOffline");
    }

}
