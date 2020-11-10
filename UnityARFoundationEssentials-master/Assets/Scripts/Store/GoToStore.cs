using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStore : MonoBehaviour
{
    public void goToStore()
    {
        SceneManager.LoadScene("Store");
    }
}
