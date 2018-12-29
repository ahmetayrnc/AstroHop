using TMPro;
using UnityEngine;

public class LoseUI : MonoBehaviour
{
	public TextMeshProUGUI levelText;
	
	void Update()
	{
		levelText.text = "Level " + GameManager.Instance.level;
	}
	
	public void RestartGame()
	{
		GameManager.Instance.RestartGame();
	}
	
	public void Levels()
	{
		GameManager.Instance.Levels();
	}
}
