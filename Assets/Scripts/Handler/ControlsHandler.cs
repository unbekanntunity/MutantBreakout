using TMPro;
using UnityEngine;

//author: B_Live

public class ControlsHandler : MonoBehaviour
{
    public bool checkKey;
    public KeyCode newkey;
    public string input;

    public KeyCode[] keyCode;
    public string[] keyName;
    public TMP_Text[] keytext;

    public TMP_Text text;
    public string key;

    const string KEYCCOEDS_PLAYPREFS = "KEYCODEJUMP_PLAYERPREF, KEYCODEPAUSE_PLAYERPREF, KEYCODECROUCH_PLAYERPREF";
    public string[] KEYCODES = KEYCCOEDS_PLAYPREFS.Split(',');

    const string KEYNAME_PLAYPREFS = "Space, Q, LeftShift";
    public string[] KEYNAME = KEYNAME_PLAYPREFS.Split(',');

    const string GAMEINITIALKEYS_PLAYERPREF = "0";

    public ResetSettingsHandler resetSettingsHandler;

    public void Awake()
    {
        if (PlayerPrefs.GetInt(GAMEINITIALKEYS_PLAYERPREF) == 0)
        {
            PlayerPrefs.SetInt(KEYCODES[0], 32);
            PlayerPrefs.SetInt(KEYCODES[1], 113);
            PlayerPrefs.SetInt(KEYCODES[2], 304);
            PlayerPrefs.SetInt(GAMEINITIALKEYS_PLAYERPREF, 1);

        }

        for (int i = 0; i < KEYNAME.Length; i++)
        {
            keytext[i].text = PlayerPrefs.GetString(KEYNAME[i]);
        }

        keyCode[0] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[0]);
        keyCode[1] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[1]);
        keyCode[2] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[2]);

    }

    public void Reset()
    {
        PlayerPrefs.SetInt(KEYCODES[0], 32);
        PlayerPrefs.SetInt(KEYCODES[1], 113);
        PlayerPrefs.SetInt(KEYCODES[2], 304);
        keyCode[0] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[0]);
        keyCode[1] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[1]);
        keyCode[2] = (KeyCode)PlayerPrefs.GetInt(KEYCODES[2]);
        Debug.Log("Controls resetted");
    }

    void OnGUI()
    {
        if (checkKey)
        {
            Event e = Event.current;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                newkey = KeyCode.LeftShift;
                input = "LeftShift";
                AssignKey(newkey, input, key);
                AssignText(newkey, input, text, key);
                checkKey = false;
            }
            else if (e.isKey && e.ToString() != "")
            {
                newkey = e.keyCode;
                input = "" + e.keyCode;
                AssignKey(newkey, input, key);
                AssignText(newkey, input, text, key);
                checkKey = false;
            }
        }
    }

    public void AssignText(KeyCode key, string keyText, TMP_Text textcontainer, string targetKey)
    {
        for (int i = 0; i < keyName.Length; i++)
        {
            if (targetKey == keyName[i])
            {
                keytext[i].text = input.ToUpper();
                PlayerPrefs.SetString(KEYNAME[i], input.ToUpper());

            }
        }
    }

    public void AssignKey(KeyCode key, string keyText, string targetKey)
    {
        for (int i = 0; i < keyName.Length; i++)
        {

            if (targetKey == keyName[i])
            {
                keyCode[i] = key;
                PlayerPrefs.SetInt(KEYCODES[i], (int)key);

            }
        }
    }
}
