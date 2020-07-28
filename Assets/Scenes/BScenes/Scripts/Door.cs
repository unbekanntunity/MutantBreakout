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

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = doorObj.GetComponent<Animator>();
        doorAnim.enabled = true;
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider obj)
    {
        if (Input.GetKey(KeyCode.E)) interact = true;
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
