using TMPro;
using UnityEngine;

public class ControlsHandler : MonoBehaviour
{
    public bool checkKey;
    public KeyCode newkey;
    public string input;

    public KeyCode[] keyCode;
    public string[] keyName;

    public TMP_Text text;
    public string key;

    public void Awake()
    {
        keyCode[0] = KeyCode.Space;
        keyCode[1] = KeyCode.Q;
        keyCode[2] = KeyCode.LeftShift;
    }

    void OnGUI()
    {
        if (checkKey)
        {
            Event e = Event.current;
            if (e.isKey && e.ToString() != "")
            {
                newkey = e.keyCode;
                input = "" + e.keyCode;
                //Debug.Log(e.ToString());
                Debug.Log(key);
                Debug.Log(text);
                AssignKey(newkey, input, key);
                AssignText(newkey, input, text);
                checkKey = false;
            }
        }
    }

    public void AssignText(KeyCode key, string keyText, TMP_Text textcontainer)
    {
        textcontainer.text = input.ToUpper();
    }

    public void AssignKey(KeyCode key, string keyText, string targetKey)
    {
        for (int i = 0; i < keyName.Length; i++)
        {
            
            if (targetKey == keyName[i])
            {
                keyCode[i] = key;
            }
        }
    }
}
