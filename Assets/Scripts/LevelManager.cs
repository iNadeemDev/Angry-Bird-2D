using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject[] Menus;

    private int CurrentLevel;

    public static LevelManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DisableAllLevels();
        //LoadNextLevel();
    }

    public void DisableAllLevels()
    {
        foreach (var level in Levels)
        {
            level.SetActive(false);
        }
    }

    public void HideStartMenu()
    {
        Menus[0].SetActive(false);
    }

    public void StartMenuColorEnter()
    {
        GameObject.FindWithTag("PlayButton").GetComponent<Image>().color = Color.red;
    }

    public void StartMenuColorExit()
    {
        GameObject.FindWithTag("PlayButton").GetComponent<Image>().color = Color.white;

    }
    public void ShowScoreBoard()
    {
        //GameObject.FindWithTag("ScoreBoard").SetActive(true);
        LevelManager.instance.Menus[2].SetActive(true);
    }

    public void LoadNextLevel()
    {
        if (CurrentLevel < Levels.Length)
        {
            DisableAllLevels();
            Levels[CurrentLevel].SetActive(true);
            CurrentLevel++;
        }


    }
}
