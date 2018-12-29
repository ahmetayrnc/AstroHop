using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircleCollider : MonoBehaviour {
	
	public PlayerMovement playerMovement;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (GameManager.Instance.gameIsOver)
		{
			return;
		}
		
		if (other.CompareTag("LinePart"))
		{
			if (!playerMovement.jumping)
			{
				other.transform.GetComponentInParent<LinePart>().Paint();
			}
		}
	}
}
