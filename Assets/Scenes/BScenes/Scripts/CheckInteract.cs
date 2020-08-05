using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInteract : MonoBehaviour
{
    public LayerMask interactable;

    public TMP_Text notification;
    public Text interacttext;

    public Transform playerCamera;

    public SkillTree skilltree;
    public AudioHandler audioHandler;

    public Image door_icon;


    public Image DJ_icon;
    public Image WR_icon;
    public Image GH_icon;

    public string RaycastReturn;
    public GameObject RaycastObjReturn;

    private Animator doorAnim;
    private TMP_Text doorTxt;


    private bool doorcard;
    private float timer;
    private bool timerIsRunning;

    void Awake()
    {
        interacttext.enabled = false;
        doorcard = false;
        door_icon.enabled = false;
        GH_icon.enabled = false;
        DJ_icon.enabled = false;
        WR_icon.enabled = false;

    }
    void Update()
    {

        //Set a timer for the notifications
        if (timerIsRunning)
        {

            if (timer > 0)
            {
                //start the fade effect if a certain is passed
                if (notification.alpha > 0 && timer < 1.5f)
                {
                    notification.alpha -= 0.05f;
                }
                timer -= Time.deltaTime;
            }
            else
            {
                notification.enabled = false;
                notification.alpha = 0.1f;
                timer = 3;
                timerIsRunning = false;
            }
        }


        //Creates a raycast and start at the playerCamera and ignore all object except the objects with the layer "interactable"
        RaycastHit t_hit = new RaycastHit();
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out t_hit, 6f, interactable))
        {

            //gets the tag of object which the raycast collided with
            RaycastReturn = t_hit.collider.gameObject.tag;
            if (RaycastReturn == "Door")
            {
                interacttext.text = "Press E to open the door";
                if (doorcard == false)
                {
                    interacttext.text = "You need a door card";

                }

            }

            if (RaycastReturn == "Card")
            {
                interacttext.text = "Press E to take the card";

            }

            if (RaycastReturn == "Chip_01" || RaycastReturn == "Chip_02" || RaycastReturn == "Chip_03") interacttext.text = "Press E to take the chip";

            interacttext.enabled = true;
        }
        else
        {
            //resets the string and disable the interactiontext if the raycast hit nothing with the interactbale layer
            RaycastReturn = "";
            interacttext.enabled = false;
        }



    }

    //if a objects stay in the collider of the player this code will executed
    private void OnTriggerStay(Collider obj)
    {
        //Creates a raycast which checks the type of the interactable object 
        RaycastHit t_hit = new RaycastHit();
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out t_hit, 6f, interactable))
        {

            RaycastObjReturn = t_hit.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                notification.enabled = true;

                if (RaycastReturn == "Door" && doorcard == true)
                {
                    doorAnim = RaycastObjReturn.GetComponent<Animator>();
                    doorAnim.enabled = true;

                    doorTxt = RaycastObjReturn.GetComponentInChildren<TMP_Text>();

                    doorTxt.text = "Opened";
                    doorTxt.color = Color.green;
                    doorAnim.SetBool("InNear", true);

                    audioHandler.PlaySound("DoorOpen");


                }

                if (RaycastReturn == "Door" && doorcard == false)
                {
                    notification.alpha = 1;
                }

                if (RaycastReturn == "Card")
                {
                    notification.alpha = 1;
                    timer = 3;
                    timerIsRunning = true;

                    doorcard = true;
                    door_icon.enabled = true;
                    RaycastObjReturn.SetActive(false);
                    notification.text = "You received the door card";
                    notification.enabled = true;
                    RaycastObjReturn.SetActive(false);
                }

                if (RaycastReturn == "Chip_01")
                {
                    notification.alpha = 1;
                    timer = 3;
                    timerIsRunning = true;

                    DJ_icon.enabled = true;
                    RaycastObjReturn.SetActive(false);
                    skilltree.DoppleJumpisUnlocked = true;
                    notification.text = "You can use dopplejumps now";
                    notification.enabled = true;
                }
                if (RaycastReturn == "Chip_02")
                {
                    notification.alpha = 1;
                    timer = 3;
                    timerIsRunning = true;

                    WR_icon.enabled = true;
                    RaycastObjReturn.SetActive(false);
                    skilltree.WallrunisUnlocked = true;
                    notification.text = "You can wall along the wall now";
                    notification.enabled = true;

                }
                if (RaycastReturn == "Chip_03")
                {
                    notification.alpha = 1;
                    timer = 3;
                    timerIsRunning = true;

                    GH_icon.enabled = true;
                    RaycastObjReturn.SetActive(false);
                    skilltree.GrabblingHookisUnlocked = true;
                    notification.text = "You can use a grabbling hook now";
                    notification.enabled = true;
                }
            }
        }
        else
        {
            RaycastObjReturn = null;
        }
    }

    //if a objects leaves the collider of the player this code will executed
    private void OnTriggerExit(Collider obj)
    {
        if (doorAnim != null && doorTxt != null && obj.gameObject.tag == "Door")
        {
            doorAnim.SetBool("InNear", false);
            doorTxt.text = "Closed";
            doorTxt.color = Color.red;
        }
    }
}