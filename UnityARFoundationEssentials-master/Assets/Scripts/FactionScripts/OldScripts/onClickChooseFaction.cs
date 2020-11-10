using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onClickChooseFaction : MonoBehaviour
{

    public void startGame()
    {
        Destroy(GameObject.Find("MenuMusic"));
        SceneManager.LoadScene(2);
    }
}
