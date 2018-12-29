using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGFXController : MonoBehaviour
{

	public static PlanetGFXController Instance;
	
	public Transform planetParent;

	public Transform[] planetGFXs;

	public int currentPlanet;

	void Awake()
	{
		Instance = this;
	}
	
	void Start()
	{
		if (!PlayerPrefs.HasKey("currentPlanet"))
		{
			PlayerPrefs.SetInt("currentPlanet",0);
			PlayerPrefs.Save();
		}

		currentPlanet = PlayerPrefs.GetInt("currentPlanet");

		DisplayPlanet(0);
		
	}

	public void DisplayPlanet( int planetNo )
	{	
		if (planetNo >= planetParent.childCount)
		{
			planetNo = planetNo % planetParent.childCount;
		}
		
		for (int i = 0; i < planetParent.childCount; i++)
		{
			planetParent.GetChild(i).gameObject.SetActive(false);
			if (i == planetNo)
			{
				planetParent.GetChild(i).gameObject.SetActive(true);
			}
		}
	}
}
