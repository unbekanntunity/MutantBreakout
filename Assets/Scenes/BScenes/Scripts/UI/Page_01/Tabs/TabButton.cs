using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public TabGroup tabGroup;

    public GameObject tabbutton;
    public GameObject buttonimage;

    public Image background;

    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.onTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.onTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.onTabExit(this);
    }

    void Start()
    {
        background = buttonimage.GetComponent<Image>();
        tabGroup.Subscribe(this);
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