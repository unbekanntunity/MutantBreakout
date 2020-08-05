using TMPro;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public ControlsHandler controlsHandler;

 

    public void SetKey(string keyname)
    {
        controlsHandler.key = keyname;

        controlsHandler.checkKey = true;
    } 

    public void SetText(TMP_Text textname)
    {
        controlsHandler.text = textname;
    }

   

    public void AssignText(TMP_Text textcontainer)
    {
        controlsHandler.AssignText(controlsHandler.newkey, controlsHandler.input, textcontainer);
    }

    public void AssignKey(string key)
    {

        controlsHandler.AssignKey(controlsHandler.newkey, controlsHandler.input, key);

    }

}
