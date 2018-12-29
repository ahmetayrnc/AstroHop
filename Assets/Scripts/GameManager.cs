using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerMovement playerMovement;
    public PlanetCircle planetCircle;
    
    public LevelUI levelUI;
    public MenuUI menuUI;
    public GameUI gameUI;
    public LoseUI loseUI;
    public WinUI winUI;
    
    public int levelPercent;
    public bool gameIsOver;

    public int level;
    
    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        level = 0;
        MainMenu();
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        
        if (levelPercent >= 100)
        {
            WinGame();
        }
    }
    
    public void WinGame()
    {
        gameIsOver = true;
        
        playerMovement.StopMovement();
        playerMovement.anim.SetTrigger("Win");
        
        
        // Make sure everything is painted because my current method is not reliable
        if (PlanetCircle.Instance.inactiveLineParts.Count > 0)
        {
            for (int i = 0; i < PlanetCircle.Instance.inactiveLineParts.Count; i++)
            {
                PlanetCircle.Instance.inactiveLineParts[i].GetComponent<LinePart>().Paint();
            }
        }

        LevelController.Instance.UnlockLevel(level + 1);
        
        winUI.gameObject.SetActive(true);
        
        menuUI.gameObject.SetActive(false);
        levelUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
        
        iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.Success);
        
        //print(level + "completed");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "LEVEL" + level.ToString("000"));
    }

    public void LoseGame()
    {
        gameIsOver = true;
        
        playerMovement.StopMovement();
        playerMovement.anim.SetTrigger("Death");
        
        loseUI.gameObject.SetActive(true);
        
        menuUI.gameObject.SetActive(false);
        levelUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);
        
        iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.Failure);
    }

    public void Levels()
    {
        gameIsOver = true;
        
        playerMovement.StopMovement();
        
        levelUI.gameObject.SetActive(true);
        
        menuUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        gameIsOver = true;

        levelPercent = 0;
        LevelController.Instance.LoadLevel(0);
        
        playerMovement.ResetPlayer();
        playerMovement.StopMovement();
        
        planetCircle.ResetTheCircle();
        
        menuUI.gameObject.SetActive(true);
        
        levelUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);
    }

    public void LoadLastLevel()
    {
        level = LevelController.Instance.LoadLastLevel();
        StartGame();
    }
    
    public void LoadLevel(int levelNo)
    {
        level = LevelController.Instance.LoadLevel(levelNo);
        StartGame();
    }
    
    public void StartGame()
    {
        gameIsOver = false;

        levelPercent = 0;
        
        playerMovement.ResetPlayer();
        playerMovement.StartMovement();
        
        planetCircle.ResetTheCircle();
        
        gameUI.gameObject.SetActive(true);
        
        menuUI.gameObject.SetActive(false);
        levelUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);
        
        PlanetGFXController.Instance.DisplayPlanet(level);
        
        //print(level + "started");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "LEVEL" + level.ToString("000"));
    }
    
    public void StartNextLevel()
    {
        if (level + 1 > LevelController.Instance.maxLevel)
        {
            MainMenu();
            return;
        }
        
        LoadLevel(level + 1);
    }

    public void RestartGame()
    {
        LoadLevel(level);
    }
}
