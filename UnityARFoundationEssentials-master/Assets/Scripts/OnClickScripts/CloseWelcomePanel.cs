using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWelcomePanel : MonoBehaviour
{
    [SerializeField]
    public GameObject WelcomePanel;
    public void Dismiss() => WelcomePanel.SetActive(false);
}
