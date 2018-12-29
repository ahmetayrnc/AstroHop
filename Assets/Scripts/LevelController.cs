using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public int maxLevel;
    public int lastUnlockedLevel;
    
    private bool[] levelUnlockInfos;

    public Transform levelsParent;
    public GameObject[] levels;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("lastUnlockedLevel"))
        {
            PlayerPrefs.SetInt("lastUnlockedLevel",1);
            PlayerPrefs.Save();
        }
        
        lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel");

        levelUnlockInfos = new bool[levelsParent.childCount];
        
        levels = new GameObject[levelsParent.childCount];

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = levelsParent.GetChild(i).gameObject;
        }
        
        for (int i = 0; i < levelUnlockInfos.Length; i++)
        {
            levelUnlockInfos[i] = false;

            if (i < lastUnlockedLevel)
            {
                levelUnlockInfos[i] = true;
            }
        }

        maxLevel = levels.Length;
    }

    public int LoadLastLevel()
    {
        if (lastUnlockedLevel > levels.Length)
        {
            lastUnlockedLevel = levels.Length;
        }
        
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
            if (i + 1 == lastUnlockedLevel)
            {
                levels[i].SetActive(true);
            }
        }

        return lastUnlockedLevel;
    }
    
    public int LoadLevel(int levelNo)
    {
        if (levelNo > levels.Length)
        {
            lastUnlockedLevel = levels.Length;
        }
        
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
            if (i + 1== levelNo)
            {
                levels[i].SetActive(true);
            }
        }

        return levelNo;
    }

    public void UnlockLevel(int levelNo)
    {
        if (levelNo > levels.Length + 1)
        {
            return;
        }
        
        if (levelNo <= lastUnlockedLevel)
        {
            return;
        }

        lastUnlockedLevel = levelNo;
        PlayerPrefs.SetInt("lastUnlockedLevel", lastUnlockedLevel);
        PlayerPrefs.Save();
        
        for (int i = 0; i < levelUnlockInfos.Length; i++)
        {
            levelUnlockInfos[i] = false;

            if (i < lastUnlockedLevel)
            {
                levelUnlockInfos[i] = true;
            }
        }
    }

    public bool FinishedAllLevels()
    {
        return lastUnlockedLevel > levels.Length;
    }

    public bool IsUnlocked(int levelNo)
    {
        return levelNo <= lastUnlockedLevel;
    }
}
