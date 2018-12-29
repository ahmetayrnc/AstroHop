using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetCircle : MonoBehaviour
{
	public static PlanetCircle Instance;
	
	public GameObject linePartPrefab;
	public Transform lineParent;

	public List<LinePart> activeLineParts;
	public List<LinePart> inactiveLineParts;
	
	void Awake()
	{
		Instance = this;
	}
	
	void Start()
	{
		InstantiateTheCircle();
	}

	public void AddToActiveList(LinePart _linePart)
	{
		inactiveLineParts.Remove(_linePart);

		activeLineParts.Add(_linePart);

		GameManager.Instance.levelPercent = activeLineParts.Count * 100 / 360;
	}
	
	public void InstantiateTheCircle()
	{
		activeLineParts = new List<LinePart>();
		inactiveLineParts = new List<LinePart>();
		
		for (int i = 0; i < 360; i++)
		{
			GameObject go = Instantiate(linePartPrefab, lineParent);
			go.transform.rotation = Quaternion.Euler(Vector3.forward * i);

			LinePart linePart = go.GetComponent<LinePart>();
			
			linePart.Hide();

			inactiveLineParts.Add(linePart);
		}
	}

	public void ResetTheCircle()
	{
		for (int i = 0; i < activeLineParts.Count; i++)
		{
			LinePart linePart = activeLineParts[i];
			
			linePart.Hide();

			inactiveLineParts.Add(linePart);
		}
		activeLineParts.Clear();
	}
}

