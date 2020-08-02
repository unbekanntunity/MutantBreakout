using UnityEngine;
using UnityEngine.UI;

public class CheckInteract : MonoBehaviour
{
    [Header("Requiered")]
    public LayerMask interactable;
        
    public Text interacttext;

    public Transform playerCamera;

    public string RaycastReturn;

    public Card card;
    void Awake()
    {
        interacttext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a raycast and start at the playerCamera and ignore all object except the objects with the layer "interactable"
        RaycastHit t_hit = new RaycastHit();
        if (Physics.Raycast(playerCamera.position, playerCamera.forward , out t_hit, 5f, interactable))
        {
            //gets the tag of object which the raycast collided with
            RaycastReturn = t_hit.collider.gameObject.tag;
            if (RaycastReturn == "Door")
            {
                interacttext.text = "Press E to open the door";

                if (card.card == false)
                {
                    interacttext.text = "You need a door card";
                }

            }
            if (RaycastReturn == "Card") interacttext.text = "Press E to take the card";
            
            if(RaycastReturn == "Chip_01" || RaycastReturn == "Chip_02" || RaycastReturn == "Chip_03") interacttext.text = "Press E to take the chip";
            
            interacttext.enabled = true;

        }
        else
        {
            //resets the string and disable the interactiontext if the raycast hit nothing with the interactbale layer
            RaycastReturn = "";
            interacttext.enabled = false;
        }

    }
}
