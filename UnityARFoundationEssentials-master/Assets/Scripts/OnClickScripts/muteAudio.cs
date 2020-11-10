using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class muteAudio : MonoBehaviour
{

    public Toggle muteMusic;
    public AudioSource music;
    bool paused = false;

    public void mute()
    {
        if (paused == false)
        {
            Analytics.CustomEvent("User Muted Music");
            music.Pause();
            paused = true;
        } else
        {
            music.Play();
            Analytics.CustomEvent("User Played Music");
            paused = false;
        }
    }
}
