using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard
{
    private int score;
    private int kills;
    private int attempts;

    private static ScoreBoard instance;
    private ScoreBoard() { }
    public static ScoreBoard GetInstance()
    {
        if (instance == null)
        {
            instance = new ScoreBoard();
        }
        return instance;
    }




    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log("Score: " + this.score);

        if (GameObject.FindWithTag("ScoreTag") != null)
        {
            GameObject.FindWithTag("ScoreTag").GetComponent<TMPro.TextMeshProUGUI>().text = "Scores: " + this.score;
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    public void AddKills(int kills)
    {
        this.kills += kills;

        if (GameObject.FindWithTag("KillsTag") != null)
        {
            GameObject.FindWithTag("KillsTag").GetComponent<TMPro.TextMeshProUGUI>().text = "Kills: " + this.kills;
        }
    }

    public int GetKills()
    {
        return this.kills;
    }
    public void AddAttempts(int attempts)

    {
        this.attempts += attempts;

        if (GameObject.FindWithTag("AttemptsTag") != null)
        {
            GameObject.FindWithTag("AttemptsTag").GetComponent<TMPro.TextMeshProUGUI>().text = "Attempts: " + this.attempts;
        }
    }

    public int GetAttempts()
    {
        return this.attempts;
    }
    public void ResetSCoreBoard()
    {
        this.score = 0;
        this.kills = 0;
        this.attempts = 0;
    }
}
