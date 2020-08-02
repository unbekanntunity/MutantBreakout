using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    [Header("Requiered")]
    public GameObject chipObj;
    public string playertag;
    public Image invImg;

    //Dopple Jump
    public bool chip_01 = false;
    //Wallrun
    public bool chip_02 = false;
    //Grappling Hook
    public bool chip_03 = false;

    private bool interact;
    public CheckInteract check;

    void Awake()
    {
        chipObj.SetActive(true);
        invImg.enabled = false;
    }


    private void OnTriggerStay(Collider obj)
    {

        if (Input.GetKey(KeyCode.E)) interact = true;
        //Check the tag of the object, which the player looking on  
        if (check.RaycastReturn == "Chip_01")
        {   
            //Check wether the object in the collider is the player or not
            if (obj.tag == playertag && interact)
            {
                chip_01 = true;
                chipObj.SetActive(false);
                invImg.enabled = true;
            }
        }
        if (check.RaycastReturn == "Chip_02")
        {
            //Check wether the object in the collider is the player or not
            if (obj.tag == playertag && interact)
            {
                chip_02 = true;
                chipObj.SetActive(false);
                invImg.enabled = true;
            }
        }
        if (check.RaycastReturn == "Chip_03")
        {
            //Check wether the object in the collider is the player or not
            if (obj.tag == playertag && interact)
            {
                chip_03 = true;
                chipObj.SetActive(false);
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
