using UnityEngine;
using UnityEngine.UI;

//author: B_Live

public class ScreenSizeHandler : MonoBehaviour
{
    public Toggle fullscreen;
    public Toggle windowed;

    public Image fullscreenImage;
    public Image windowedImage;

    const string SCREENSIZE_PLAYERPREF = "windowed";

    public ResetSettingsHandler resetSettingsHandler;


    public void Awake()
    {
        if (PlayerPrefs.GetString(SCREENSIZE_PLAYERPREF) == "windowed")
        {
            Windowed(true);
        }
        else
        {
            Fullscreen(true);
        }

    }
    public void Reset()
    {

        PlayerPrefs.SetString(SCREENSIZE_PLAYERPREF, "windowed");
        windowedImage.enabled = true;
        fullscreenImage.enabled = false;
        fullscreen.isOn = false;
        windowed.isOn = true;
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void Fullscreen(bool IsFullScreen)
    {
        if (IsFullScreen)
        {
            PlayerPrefs.SetString(SCREENSIZE_PLAYERPREF, "fullscreen");
            windowedImage.enabled = false;
            fullscreenImage.enabled = true;

            windowed.isOn = false;
            fullscreen.isOn = true;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }

    public void Windowed(bool IsWindowed)
    {
        if (IsWindowed)
        {
            PlayerPrefs.SetString(SCREENSIZE_PLAYERPREF, "windowed");
            windowedImage.enabled = true;
            fullscreenImage.enabled = false;

            windowed.isOn = true;
            fullscreen.isOn = false;
            
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
}
