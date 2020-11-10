using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStoreOnCreate : MonoBehaviour
{
    [SerializeField]
    public GameObject errorPanel;
    // Start is called before the first frame update
    void Start()
    {
        errorPanel.SetActive(false);
    }
}
