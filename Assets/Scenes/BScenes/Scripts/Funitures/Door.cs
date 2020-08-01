using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Requiered")]
    public Animator doorAnim;
    public GameObject doorObj;
    public TMP_Text doorTxt;
    public string playertag;

    public Card card;
    
    private bool interact;

    void Awake()
    {
        doorAnim = doorObj.GetComponent<Animator>();
        doorAnim.enabled = true;
    }


    private void OnTriggerStay(Collider obj)
    {
        if (Input.GetKey(KeyCode.E)) interact = true;
        //Checks wether the object in the collider is the player or not
        if (obj.tag == playertag && interact && card.card)
        {
            doorTxt.text = "Opened";
            doorTxt.color = Color.green;
            doorAnim.SetBool("InNear", true);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == playertag)
        {
            interact = false;

            doorAnim.SetBool("InNear", false);
        }
    }
}
