using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    private static FloatingText popupText;
    private static GameObject canvas;
    public static void Initialise()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<FloatingText>("Prefabs/TextPopUpParent");
    }
    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        //instance.SetText = text;
    }
}
