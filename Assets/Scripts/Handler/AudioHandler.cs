using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public string[] audioname;

    public AudioSource[] audioSources;
    public AudioMixer audiomixer;
    public AudioMixer musicmixer;

    public Slider gameSoundVolume;
    public Slider gameMusicVolume;


    private string search;
    public const string AUDIOVOL_PLAYERPREF = "0.51";
    public const string AUDIOVOLSLIDER_PLAYERPREF = "0.51";

    public const string MUSICVOL_PLAYERPREF = "0.51";
    public const string MUSICVOLSLIDER_PLAYERPREF = "0.51";

    public ResetSettingsHandler resetSettingsHandler;

    /*to use this funciton you have to ensure that the aurguement have the same name as the string in the audioname array and 
    the audioscource have to be in the same position as the name or the string in the audioname array*/

    private void Awake()
    {
        audiomixer.SetFloat("AudioVol", PlayerPrefs.GetFloat(AUDIOVOL_PLAYERPREF));
        gameSoundVolume.value = PlayerPrefs.GetFloat(AUDIOVOLSLIDER_PLAYERPREF);
        musicmixer.SetFloat("MusicVol", PlayerPrefs.GetFloat(MUSICVOL_PLAYERPREF));
        gameMusicVolume.value = PlayerPrefs.GetFloat(MUSICVOLSLIDER_PLAYERPREF);
    }

    public void Reset()
    {
        audiomixer.SetFloat("AudioVol", 0.51f);
        gameSoundVolume.value = 0.51f;
        musicmixer.SetFloat("MusicVol", 0.51f);
        gameMusicVolume.value = 0.51f;
        PlayerPrefs.SetFloat(AUDIOVOL_PLAYERPREF, 0.51f);
        PlayerPrefs.SetFloat(AUDIOVOLSLIDER_PLAYERPREF, 0.51f);
        PlayerPrefs.SetFloat(MUSICVOL_PLAYERPREF, 0.51f);
        PlayerPrefs.SetFloat(MUSICVOLSLIDER_PLAYERPREF, 0.51f);
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
        audiomixer.SetFloat("AudioVol", Mathf.Log10(SliderVolume) * 20);
        float mixerout = Mathf.Log10(SliderVolume) * 20;
        PlayerPrefs.SetFloat(AUDIOVOL_PLAYERPREF, mixerout);
        PlayerPrefs.SetFloat(AUDIOVOLSLIDER_PLAYERPREF, SliderVolume);
        PlayerPrefs.Save();
    }

    public void SetMusicVol(float SliderVolume)
    {
        musicmixer.SetFloat("MusicVol", Mathf.Log10(SliderVolume) * 20);
        float mixerout = Mathf.Log10(SliderVolume) * 20;
        PlayerPrefs.SetFloat(MUSICVOL_PLAYERPREF, mixerout);
        PlayerPrefs.SetFloat(MUSICVOLSLIDER_PLAYERPREF, SliderVolume);
        PlayerPrefs.Save();
    }
}
