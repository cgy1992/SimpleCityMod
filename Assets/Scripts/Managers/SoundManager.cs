using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public AudioMixer masterMixer;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot mainMenu;

    public static float MasterVomlume { get; set; }
    public static float MusicVomlume { get; set; }
    public static float SFXVomlume { get; set; }

    public static AudioMixer MasterMixer;
    public static AudioMixerSnapshot Paused;
    public static AudioMixerSnapshot Unpaused;
    public static AudioMixerSnapshot MainMenu;

    public void Start()
    {
        MasterMixer = masterMixer;
        Paused = paused;
        Unpaused = unpaused;
        MainMenu = mainMenu;
    }

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

    public static void SetMasterVolume(float _newVolume)
    {
        float result;

        MasterMixer.GetFloat("MasterVolume", out result);
        MasterMixer.SetFloat("MasterVolume", result * _newVolume);
    }

    public static void SetMusicVolume(float _newVolume)
    {
        float result;

        MasterMixer.GetFloat("MusicVolume", out result);
        MasterMixer.SetFloat("MusicVolume", result * _newVolume);
    }

    public static void SetSFXVolume(float _newVolume)
    {
        float result;

        MasterMixer.GetFloat("SFXVolume", out result);
        MasterMixer.SetFloat("SFXVolume", result * _newVolume);
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
