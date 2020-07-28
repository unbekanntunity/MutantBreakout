using UnityEngine;
using UnityEngine.UI;

public class CheckInteract : MonoBehaviour
{
    [Header("Requiered")]
    public LayerMask interactable;
        
    public Text interacttext;
    public Text requieredtext;

    public Transform playerCamera;

    public string RaycastReturn;

    public Card card;
    // Start is called before the first frame update
    void Start()
    {
        interacttext.enabled = false;
        requieredtext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit t_hit = new RaycastHit();
        if (Physics.Raycast(playerCamera.position, playerCamera.forward , out t_hit, 10f, interactable))
        {
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
            
            if(RaycastReturn == "Syringes") interacttext.text = "Press E to take the syringe";
            
            interacttext.enabled = true;

        }
        else
        {
                     
            RaycastReturn = "";
            interacttext.enabled = false;
        }

    }
}
