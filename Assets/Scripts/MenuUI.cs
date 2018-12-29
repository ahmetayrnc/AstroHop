using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{

	public TextMeshProUGUI lastUnlockedLevel;

	void Update()
	{
		lastUnlockedLevel.text = LevelController.Instance.lastUnlockedLevel  < LevelController.Instance.maxLevel ? LevelController.Instance.lastUnlockedLevel + "" : LevelController.Instance.maxLevel + "";
	}
	
	public void StartGame()
	{
		GameManager.Instance.StartGame();
	}

	public void Levels()
	{
		GameManager.Instance.Levels();
	}

	public void LoadLastLevel()
	{
		GameManager.Instance.LoadLastLevel();
	}
}
