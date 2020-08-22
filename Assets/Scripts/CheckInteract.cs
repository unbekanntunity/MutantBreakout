using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInteract : MonoBehaviour
{
    public LayerMask interactable;

    public TMP_Text notification;
    public Text interacttext;

    public Transform playerCamera;

    public SkillHandler skillHandler;

    public Image door_icon;

    public string[] compareTags;
    public string[] notificationText;
    public Image[] Icons;

    public string RaycastReturn;
    public GameObject RaycastObjReturn;

    private Animator doorAnim;
    private TMP_Text doorTxt;


    private bool doorcard;
    public float timer;
    public bool timerIsRunning;

    void Awake()
    {
        interacttext.enabled = false;
        doorcard = false;

        for (int i = 0; i < Icons.Length; i++) Icons[i].enabled = false;

    }
    void Update()
    {
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

                for (int i = 0; i < compareTags.Length; i++)
                {
                    if (RaycastReturn == compareTags[i])
                    {


                        if (RaycastObjReturn.GetComponent<Animator>() != null && RaycastObjReturn.GetComponentInChildren<TMP_Text>() != null && doorcard)
                        {
                            doorAnim = RaycastObjReturn.GetComponent<Animator>();
                            doorAnim.enabled = true;

                            doorTxt = RaycastObjReturn.GetComponentInChildren<TMP_Text>();

                            doorTxt.text = "Opened";
                            doorTxt.color = Color.green;
                            doorAnim.SetBool("InNear", true);
                        }
                        else
                        {
                            if (RaycastReturn == "Card") doorcard = true;

                            ResetTimer();
                            if (i > 0) Icons[i - 1].enabled = true;

                            RaycastObjReturn.SetActive(false);
                            notification.text = notificationText[i];
                            notification.enabled = true;

                            skillHandler.UnlockableSkills[(i - 1)] = true;
                        }
                    }
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

    private void ResetTimer()
    {

        notification.alpha = 1;
        timer = 3;
        timerIsRunning = true;
    }
}