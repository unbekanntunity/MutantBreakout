using TMPro;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public ControlsHandler controlsHandler;

    public void AssignText(TMP_Text textcontainer)
    {
        controlsHandler.AssignText(controlsHandler.newkey, controlsHandler.input, textcontainer);
    }

    public void AssignKey(string key)
    {

        controlsHandler.AssignKey(controlsHandler.newkey, controlsHandler.input, key);

    }

}
