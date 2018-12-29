using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{

	public TextMeshProUGUI levelText;

	void Update()
	{
		levelText.text = "Level " + (GameManager.Instance.level + 1  <= LevelController.Instance.maxLevel ? GameManager.Instance.level + 1 + "" : "MAX");
	}
	
	public void NextLevel()
	{
		GameManager.Instance.StartNextLevel();
	}

	public void Levels()
	{
		GameManager.Instance.Levels();
	}
}
