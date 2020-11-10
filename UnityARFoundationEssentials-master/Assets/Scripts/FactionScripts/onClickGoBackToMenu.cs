using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onClickGoBackToMenu : MonoBehaviour
{
    public void startGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
