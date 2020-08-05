using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public string[] audioname;

    public AudioSource[] audioSources;
    public AudioMixer mixer;

    private string search;
   
    const string AUDIOVOL_PLAYERPREF = "0.51";

    /*to use this funciton you have to ensure that the aurguement have the same name as the string in the audioname array and 
    the audioscource have to be in the same position as the name or the string in the audioname array*/

    private void Awake()
    {
        mixer.SetFloat("AudioVol", PlayerPrefs.GetFloat(AUDIOVOL_PLAYERPREF));
    }

    public void PlaySound(string audioSource)
    {
        search = audioSource;

        for(int i = 0; i < audioSources.Length; i++)
        {
            if(search == audioname[i])
            {
                audioSources[i].Play();
            }
        }
    }
        
    public void SetAudioVol(float SliderVolume)
    {
        mixer.SetFloat("AudioVol", Mathf.Log10( SliderVolume) * 20);
        float mixerout = Mathf.Log10(SliderVolume) * 20;
        PlayerPrefs.SetFloat(AUDIOVOL_PLAYERPREF, mixerout);
        Debug.Log(mixerout);
    }
}
