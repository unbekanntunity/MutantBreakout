using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public TMP_Text skillname;
    public Image skillicon;
    public TMP_Text skilldescription;

    public bool DoppleJumpisUnlocked;
    public bool WallrunisUnlocked;
    public bool GrabblingHookisUnlocked;

    public List<SkillButton> skillbuttons;
    public SkillButton selectedTab;


    private void Awake()
    {
        DoppleJumpisUnlocked = false;
        WallrunisUnlocked = false;
        GrabblingHookisUnlocked = false;
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
            skillname.text = button.name;
            skillicon.sprite = button.buttonSprite.sprite;
            skilldescription.text = button.GetComponent<Text>().text;
        }


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
        skilldescription.text = selectedTab.GetComponent<Text>().text;
        // selectedTab.unlockable = false;

        // UnlockSkill();

    }

    public void ResetTabs()
    {
        foreach (SkillButton button in skillbuttons)
        {
            if (selectedTab != null && button == selectedTab || button.background.color == Color.grey) { continue; }
            button.background.color = Color.white;
        }
    }

    /* public void UnlockSkill()
     {
         if (selectedTab.tag == "SkillLayer1")
         {
             if (selectedTab.name.Contains("DoppleJump"))
             {
                 DoppleJumpisUnlocked = true;
                 SkillLayer1.Remove(selectedTab);

             }else if (selectedTab.name.Contains("Wallrun"))
             {
                 WallrunisUnlocked = true;
                 SkillLayer1.Remove(selectedTab);

             }
             else if (selectedTab.name.Contains("Wallrun"))
             {
                 GrabblingHookisUnlocked = true;
                 SkillLayer1.Remove(selectedTab);

             }

             foreach(SkillButton button in SkillLayer1)
             {
                 button.unlockable = false;
                 if(button.unlockable == false)
                 {
                     button.background.color = Color.grey;
                 }
             }
         }
     }*/
}