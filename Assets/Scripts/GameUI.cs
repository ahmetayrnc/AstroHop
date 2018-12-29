using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public TextMeshProUGUI percentText;
	public TextMeshProUGUI levelText;
	
	void Update()
	{
		percentText.text = GameManager.Instance.levelPercent + "%";
		levelText.text = "Level " + GameManager.Instance.level + "";
	}
}
