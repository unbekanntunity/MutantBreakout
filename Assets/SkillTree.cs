using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public List<SkillButton> skillbuttons;
    public SkillButton selectedTab;

    public TMP_Text skillname;
    public Image skillicon;

    void Update()
    {
        Debug.Log(selectedTab);    
    }
    public void Subscribe(SkillButton button)
    {
        if (skillbuttons == null)
        {
            skillbuttons = new List<SkillButton>();
        }
        skillbuttons.Add(button);
    }

    public void onTabEnter(SkillButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = Color.red;
        }

        skillname.text = selectedTab.name;
        skillicon.sprite = selectedTab.buttonSprite.sprite;
    }

    public void onTabExit(SkillButton button)
    {
        ResetTabs();
    }

    public void onTabSelected(SkillButton button)
    {

        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;

        selectedTab.Select();
        ResetTabs();
        button.background.color = Color.grey;

        skillname.text = selectedTab.name;
        skillicon.sprite = selectedTab.buttonSprite.sprite;
    }

    public void ResetTabs()
    {
        foreach (SkillButton button in skillbuttons)
        {
            if (selectedTab != null && button == selectedTab || button.background.color == Color.grey) { continue; }
            button.background.color = Color.white;
        }
    }
}
