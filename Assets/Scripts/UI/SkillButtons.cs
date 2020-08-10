using TMPro;
using UnityEngine;
using UnityEngine.UI;

//author: B_Live

public class SkillButtons : MonoBehaviour
{
    public SkillHandler skillHandler;

    public Image skillImage;
    public TMP_Text skillNameText;
    public TMP_Text skillDescText;
    public Image backgroundImage;
    public int skillButtonID;
    public int reqSkillpoints;

    public int[] conditionskill;
    public int conditions = 0;
    public TMP_Text reqPoints;

    public void PressSkillButton()
    {
        conditions = 0;
        skillHandler.activeSkill = transform.GetComponent<Skill>();
        skillHandler.activeButton = transform.GetComponent<SkillButtons>();
        skillImage.sprite = skillHandler.skills[skillButtonID].skillSprite;
        skillNameText.text = skillHandler.skills[skillButtonID].skillName;
        skillDescText.text = skillHandler.skills[skillButtonID].skillDesc;

        if(reqSkillpoints > 1)
        {
            reqPoints.text = "need " + reqSkillpoints + " points";
        }
        else
        {
            reqPoints.text = "need " + reqSkillpoints + " point";
        }

        for (int i = 0; i < skillHandler.activeButton.conditionskill.Length; i++)
        {

            if (skillHandler.UnlockableSkills[skillHandler.activeButton.conditionskill[i]])
            {
                skillHandler.ReqText[1].text = "" + skillHandler.skills[skillHandler.activeButton.conditionskill[i]];
                skillHandler.activeButton.conditions += 1;
                skillHandler.ReqText[i].color = new Color(0, 1, 0);
            }
        }



    }



}
