using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public string[] audioname;

    public AudioSource[] audioSources;
    public AudioMixer mixer;

    private string search;
   
    /*to use this funciton you have to ensure that the aurguement have the same name as the string in the audioname array and 
    the audioscource have to be in the same position as the name or the string in the audioname array*/
    
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

        Debug.Log(mixerout);
    }
}
