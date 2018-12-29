using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour {

	public void MainMenu()
	{
		GameManager.Instance.MainMenu();
	}

	public void StartLevel(int levelNo)
	{
		if (LevelController.Instance.IsUnlocked(levelNo))
		{
			GameManager.Instance.LoadLevel(levelNo);
		}
	}
}
