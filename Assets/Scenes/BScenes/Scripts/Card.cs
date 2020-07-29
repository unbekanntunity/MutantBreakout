using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("Requiered")]
    public GameObject cardObj;
    public string playertag;
    public Image invImg;

    public bool card = false;

    private bool interact;
    

    // Start is called before the first frame update
    void Awake()
    {
        cardObj.SetActive(true);
        invImg.enabled = false;
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider obj)
    {
        if (Input.GetKey(KeyCode.E)) interact = true;
        if (obj.tag == playertag && interact)
        {
            card = true;
            cardObj.SetActive(false);
            invImg.enabled = true;
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
