using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot mainMenu;

    public static float MasterVomlume { get; set; }
    public static float MusicVomlume { get; set; }
    public static float SFXVomlume { get; set; }

    public void Pause()
    {
        if (!GameManager.isInGame)
        {
            mainMenu.TransitionTo(0f);
        }

        if (GameManager.isPaused)
        {
            paused.TransitionTo(0.1f);
            return;
        }

        unpaused.TransitionTo(0.1f);
    }

    public static void PlayBuildSound()
    {
        //TODO: Play sound
    }

    public static void PlayRemoveSound()
    {
        //TODO: Play sound
    }
    public static void PlayHoverSound()
    {
        //TODO: Play sound
    }
    public static void PlayButtonClickSound()
    {
        //TODO: Play sound
    }

}
