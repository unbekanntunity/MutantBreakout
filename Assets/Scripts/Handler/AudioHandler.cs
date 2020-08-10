using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//author: B_Live

public class AudioHandler : MonoBehaviour
{
    public string[] audioname;

    public AudioSource[] audioSources;
    public AudioMixer mixer;

    public Slider gameSoundVolume;

    private string search;
    public const string AUDIOVOL_PLAYERPREF = "0.51";
    public const string AUDIOVOLSLIDER_PLAYERPREF = "0.51";

    public ResetSettingsHandler resetSettingsHandler;

    /*to use this funciton you have to ensure that the aurguement have the same name as the string in the audioname array and 
    the audioscource have to be in the same position as the name or the string in the audioname array*/

    private void Awake()
    {

        mixer.SetFloat("AudioVol", PlayerPrefs.GetFloat(AUDIOVOL_PLAYERPREF));
        gameSoundVolume.value = PlayerPrefs.GetFloat(AUDIOVOLSLIDER_PLAYERPREF);
    }

    public void Reset()
    {
        mixer.SetFloat("AudioVol", 0.51f);
        gameSoundVolume.value = 0.51f;
        PlayerPrefs.SetFloat(AUDIOVOL_PLAYERPREF, 0.51f);
        PlayerPrefs.SetFloat(AUDIOVOLSLIDER_PLAYERPREF, 0.51f);
        Debug.Log("Audios resetted");

    }

    public void PlaySound(string audioSource)
    {
        search = audioSource;

        for (int i = 0; i < audioSources.Length; i++)
        {
            if (search == audioname[i])
            {
                audioSources[i].Play();
            }
        }
    }

    public void SetAudioVol(float SliderVolume)
    {
        mixer.SetFloat("AudioVol", Mathf.Log10(SliderVolume) * 20);
        float mixerout = Mathf.Log10(SliderVolume) * 20;
        PlayerPrefs.SetFloat(AUDIOVOL_PLAYERPREF, mixerout);
        PlayerPrefs.SetFloat(AUDIOVOLSLIDER_PLAYERPREF, SliderVolume);
    }
}
