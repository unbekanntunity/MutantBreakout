using UnityEngine;
using UnityEngine.UI;

//author: B_Live

public class SensitivityHandler : MonoBehaviour
{
    public float sensMultiplierX = 50f;
    public float sensMultiplierY = 50f;

    const string SENSITIVITYX_PLAYERPREF = "50";
    const string SENSITIVITYY_PLAYERPREF = "50";
    const string REVERSEX_PLAYERPREF = "0";
    const string REVERSEY_PLAYERPREF = "0";


    public Slider sensitivityX;
    public Slider sensitivityY;

    public Toggle reverseXtoggle;
    public Toggle reverseYtoggle;


    private int reverseX;
    private int reverseY;

    public ResetSettingsHandler resetSettingsHandler;


    private void Awake()
    {
        reverseX = PlayerPrefs.GetInt(REVERSEX_PLAYERPREF);
        reverseY = PlayerPrefs.GetInt(REVERSEY_PLAYERPREF);

        sensitivityX.value = PlayerPrefs.GetFloat(SENSITIVITYX_PLAYERPREF);
        sensitivityY.value = PlayerPrefs.GetFloat(SENSITIVITYY_PLAYERPREF);
        if (reverseX == 0)
        {
            sensMultiplierX = PlayerPrefs.GetFloat(SENSITIVITYX_PLAYERPREF);
            reverseXtoggle.isOn = false;
        }
        if (reverseX == 1)
        {
            sensMultiplierX = -PlayerPrefs.GetFloat(SENSITIVITYX_PLAYERPREF);
            reverseXtoggle.isOn = true;
        }

        if (reverseY == 0)
        {
            sensMultiplierY = PlayerPrefs.GetFloat(SENSITIVITYY_PLAYERPREF);
            reverseYtoggle.isOn = false;
        }
        if (reverseY== 1)
        {
            sensMultiplierY = -PlayerPrefs.GetFloat(SENSITIVITYY_PLAYERPREF);
            reverseYtoggle.isOn = true;
        }
    }

    public void Reset()
    {

        reverseXtoggle.isOn = false;
        reverseYtoggle.isOn = false;
        sensitivityX.value = 50f;
        sensitivityY.value = 50f;
        reverseX = 0;
        reverseY = 0;
        sensMultiplierX = 50f;
        sensMultiplierY = 50f;
        PlayerPrefs.SetFloat(SENSITIVITYX_PLAYERPREF, 50f);
        PlayerPrefs.SetFloat(SENSITIVITYY_PLAYERPREF, 50f);
        PlayerPrefs.SetInt(REVERSEX_PLAYERPREF, 0);
        PlayerPrefs.SetInt(REVERSEY_PLAYERPREF, 0);

        Debug.Log("Sensitivity resetted");

    }
    public void SetSensitivityX(float slidersensitivity)
    {
        sensMultiplierX = slidersensitivity;
        if (reverseX == 1)
        {
            sensMultiplierX = -slidersensitivity;
        }
        PlayerPrefs.SetFloat(SENSITIVITYX_PLAYERPREF, slidersensitivity);


    }
    public void SetSensitivityY(float slidersensitivitys)
    {
        sensMultiplierY = slidersensitivitys;
        if (reverseY == 1)
        {
            sensMultiplierY = -slidersensitivitys;
        }
        PlayerPrefs.SetFloat(SENSITIVITYY_PLAYERPREF, slidersensitivitys);
    }

    public void ReverseX()
    {
        sensMultiplierX *= -1;

        if (reverseX == 0)
        {
            reverseX = 1;
            reverseXtoggle.isOn = true;
        }
        else if (reverseX == 1)
        {
            reverseX = 0;

            reverseXtoggle.isOn = false;

        }
        PlayerPrefs.SetInt(REVERSEX_PLAYERPREF, reverseX);
    }
    public void ReverseY()
    {
        sensMultiplierY *= -1;

        if (reverseY == 0)
        {
            reverseY = 1;
            reverseYtoggle.isOn = true;
        }
        else if (reverseY == 1)
        {
            reverseY = 0;

            reverseYtoggle.isOn = false;

        }
        PlayerPrefs.SetInt(REVERSEY_PLAYERPREF, reverseY);
    }
}
