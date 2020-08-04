using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SkillButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public SkillTree skilltree;

    public GameObject tabbutton;
    public GameObject buttonbackgroundimage;
    public Image buttonSprite;

    public Image background;

    public bool unlockable = true;

    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        skilltree.onTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        skilltree.onTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skilltree.onTabExit(this);
    }

    void Start()
    {
        background = buttonbackgroundimage.GetComponent<Image>();
        skilltree.Subscribe(this);
    }

    public void Select()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }

    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }

    }
}