using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSettingsHandler : MonoBehaviour
{

    public AudioHandler audioHandler;
    public SensitivityHandler sensitivityHandler;
    public ControlsHandler controlsHandler;
    public ScreenSizeHandler screenSizeHandler;

    public void RestoreDefault()
    {

        audioHandler.Reset();
        sensitivityHandler.Reset();
        controlsHandler.Reset();
        screenSizeHandler.Reset();
    }

}
