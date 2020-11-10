using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseUpgradeFactionScript : MonoBehaviour
{
    public static chooseUpgradeFactionScript instance;

    [SerializeField]
    public Button GhostButton;
    [SerializeField]
    public Button MonsterButton;
    [SerializeField]
    public Button DemonButton;

    [SerializeField]
    public GameObject Panel;

    public int faction = 0;

    public  void GhostSelected()
    {
        faction = 1;
        Destroy(Panel, 1);
    }

    public void MonsterSelected()
    {
        faction = 2;
        Destroy(Panel, 1);
    }

    public void DemonSelected()
    {
        faction = 3;
        Destroy(Panel, 1);
    }
}
