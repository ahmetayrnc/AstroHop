using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePart : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public bool painted;

	void Start()
	{
		painted = false;
	}
	
	public void Paint()
	{
		if (painted)
		{
			return;
		}

		painted = true;
		
		Color newColor = spriteRenderer.color;
		newColor.a = 1;
		spriteRenderer.color = newColor;
		
		PlanetCircle.Instance.AddToActiveList(this);
	}
	
	public void Hide()
	{
		painted = false;
		
		Color newColor = spriteRenderer.color;
		newColor.a = 0;
		spriteRenderer.color = newColor;
	}
}
