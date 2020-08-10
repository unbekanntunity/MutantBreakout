using TMPro;
using UnityEngine;
using UnityEngine.UI;

//author: B_Live

public class SkillHandler : MonoBehaviour
{
    public Skill[] skills;
    public SkillButtons[] skillButtons;
    public Button tempbutton;
    public Image tempImage;

    public Skill activeSkill;
    public SkillButtons activeButton;

    public bool[] UnlockableSkills;

    public string[] skillnotification;

    public GameObject[,] skillLevels;

    public GameObject[] skillLevel0;
    public GameObject[] skillLevel1;

    public TMP_Text[] ReqText;

    public CheckInteract checkInteract;
    public Button upgradeButton;
    public TMP_Text upgradeButtonText;
    public TMP_Text displayskillpoints;

    public int skillpoints;

    private int currentSkillLevel = 0;

    public bool IsUpgrading = false;

    private void Awake()
    {
        for (int i = 0; i < ReqText.Length; i++) ReqText[i].enabled = false;

        skillLevels = new GameObject[,] { { null, null }, { null, null }, { null, null }, { null, null } };
        for (int i = 0; i < ReqText.Length; i++) ReqText[i].color = new Color(1, 0, 0);

        for (int i = 0; i < skillLevel0.Length; i++) skillLevels[i, 0] = skillLevel0[i];
        for (int i = 0; i < skillLevel1.Length; i++) skillLevels[i, 1] = skillLevel1[i];

        for (int i = 0; i < skillLevel1.Length; i++) skillLevels[i, 1].SetActive(false);

        if(skillpoints > 1)
        {
            displayskillpoints.text = skillpoints + " points";
        }
        else
        {
            displayskillpoints.text = skillpoints + " point";
        }
        
    }

    private void Update()
    {
        for (int i = 0; i < skillButtons.Length; i++) {
            if (skillButtons[i].conditions != skillButtons[i].conditionskill.Length)
            {
                skillButtons[i].backgroundImage.color = new Color(0.4941177f, 0.4941177f, 0.4941177f);
            }
        }

        for(int i = 0; i < ReqText.Length; i++)ReqText[i].enabled = false;

        for (int i = 0; i < skillLevels.Length; i++)
        {
            if (UnlockableSkills[i])
            {
                skillButtons[i].backgroundImage.color = new Color(0.4941177f, 0.4941177f, 0.4941177f);
            }

        }

        if (UnlockableSkills[activeButton.skillButtonID] || skillpoints < activeButton.reqSkillpoints || activeButton.conditions != activeButton.conditionskill.Length)
        {
            upgradeButton.interactable = false;
            activeButton.backgroundImage.color = new Color(0.4941177f, 0.4941177f, 0.4941177f);

            for (int i = 0; i < activeButton.conditionskill.Length; i++)
            {
                ReqText[i].enabled = true;
                ReqText[i].text = "" + skills[activeButton.conditionskill[i]];
            }
            if (skillpoints < activeButton.reqSkillpoints)
            {
                activeButton.reqPoints.color = new Color(1, 0, 0);
            }

        }
        else 
        {
            for (int i = 0; i < activeButton.conditionskill.Length; i++)
            {
                ReqText[i].enabled = true;
                ReqText[i].text = "" + skills[activeButton.conditionskill[i]];
            }
            upgradeButton.interactable = true;
            upgradeButtonText.text = "Upgrade";
            activeButton.reqPoints.color = new Color(0, 1, 0);
            activeButton.backgroundImage.color = new Color(1, 1, 1);

        }
    }

    public void Upgrade()
    {
        IsUpgrading = true;
        if (skillpoints >= activeButton.reqSkillpoints && activeButton.conditions == activeButton.conditionskill.Length)
        {

            UnlockableSkills[activeButton.skillButtonID] = true;
            activeButton.backgroundImage.color = new Color(0.4941177f, 0.4941177f, 0.4941177f);
            checkInteract.notification.alpha = 1;
            checkInteract.timer = 3;
            checkInteract.timerIsRunning = true;
            checkInteract.notification.text = skillnotification[activeButton.skillButtonID];
            checkInteract.notification.enabled = true;
            skillpoints -= activeButton.reqSkillpoints;

        }
        if (skillpoints > 1)
        {
            displayskillpoints.text = skillpoints + " points";
        }
        else
        {
            displayskillpoints.text = skillpoints + " point";
        }

        for (int i = 0; i < skillLevels.Length / 2 && currentSkillLevel < 2; i++)
        {
            tempbutton = skillLevels[i, currentSkillLevel].GetComponent<Button>();
            tempImage = skillLevels[i, currentSkillLevel].GetComponentInChildren<Image>();
            tempbutton.interactable = false;
            tempImage.color = new Color(0.4941177f, 0.4941177f, 0.4941177f);
        }

        currentSkillLevel += 1;


        for (int i = 0; i < skillLevels.Length / 2 && currentSkillLevel < 2; i++)
        {
            skillLevels[i, currentSkillLevel].SetActive(true);
        }


    }

}
