using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
	public Transform blackScreen;
	private Transform parent;
	public int levelNo;

	void Start()
	{
		parent = transform.parent;
		
		for (int i = 0; i < parent.childCount; i++)
		{
			if (parent.GetChild(i).Equals(transform))
			{
				levelNo = i + 1;
				break;
			}
		}	
	}
		
	void Update()
	{
		if (levelNo <= LevelController.Instance.lastUnlockedLevel)
		{
			blackScreen.gameObject.SetActive(false);
		}
		else
		{
			blackScreen.gameObject.SetActive(true);
		}
	}
}
