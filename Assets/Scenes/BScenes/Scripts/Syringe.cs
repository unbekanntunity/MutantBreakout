using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Syringe : MonoBehaviour
{
    [Header("Requiered")]
    public GameObject syringeObj;
    public string playertag;
    public Image invImg;

    public bool syringe_01 = false;
    public bool syringe_02 = false;
    public bool syringe_03 = false;

    private bool interact;
    public CheckInteract check;

    void Awake()
    {
        syringeObj.SetActive(true);
        invImg.enabled = false;
    }


    private void OnTriggerStay(Collider obj)
    {
        
        if (Input.GetKey(KeyCode.E)) interact = true;
        if (check.RaycastReturn == "Syringe_01")
        {
            if (obj.tag == playertag && interact)
            {
                syringe_01 = true;
                syringeObj.SetActive(false);
                invImg.enabled = true;
            }
        }
        if (check.RaycastReturn == "Syringe_02")
        {
            if (obj.tag == playertag && interact)
            {
                syringe_02 = true;
                syringeObj.SetActive(false);
                invImg.enabled = true;
            }
        }
        if (check.RaycastReturn == "Syringe_03")
        {
            if (obj.tag == playertag && interact)
            {
                syringe_03 = true;
                syringeObj.SetActive(false);
                invImg.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == playertag)
        {
            interact = false;
        }
    }
}
