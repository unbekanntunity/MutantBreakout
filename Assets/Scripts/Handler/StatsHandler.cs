using JetBrains.Annotations;
using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsHandler : MonoBehaviour
{
    public TMP_Text GameStarted;
    public TMP_Text DeathCounter;
    public TMP_Text KillCounter;

    const string GAMEINITIAL_PLAYERPREF = "0";
    const string GAMESTARTEDDATE_PLAYERPREF = "";
    const string DEATH_PLAYERPREF = "0";
    const string KILLS_PLAYERPREF = "0";

    private string gameStartedDate = "";
    private int death = 0;
    private int kills = 0;

    private void Awake()
    {
        if(PlayerPrefs.GetInt(GAMEINITIAL_PLAYERPREF) == 0)
        {
            PlayerPrefs.SetInt(GAMEINITIAL_PLAYERPREF, 1);
            PlayerPrefs.SetString(GAMESTARTEDDATE_PLAYERPREF, "" + System.DateTime.Now);
        }

        
        gameStartedDate = PlayerPrefs.GetString(GAMESTARTEDDATE_PLAYERPREF);
        kills = PlayerPrefs.GetInt(KILLS_PLAYERPREF) - 1;
        death = PlayerPrefs.GetInt(DEATH_PLAYERPREF) - 1;
    }


    public void Start()
    {
        GameStarted.text = "Game started: " + gameStartedDate;
        DeathCounter.text = "Deaths: " + death;
        KillCounter.text = "Kills: " + kills;
    }

    public void SetKillConter(GameObject target)
    {
        if(target.tag == "Enemy")
        {
            kills += 1;
            PlayerPrefs.SetInt(KILLS_PLAYERPREF, kills);
        }
        if(target.tag == "Player")
        {
            death += 1;
            PlayerPrefs.SetInt(DEATH_PLAYERPREF, death);
        }
    }

}
