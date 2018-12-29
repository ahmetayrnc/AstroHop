using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public PlayerMovement playerMovement;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (GameManager.Instance.gameIsOver)
		{
			return;
		}
		
		if (other.CompareTag("Enemy"))
		{
			GameManager.Instance.LoseGame();
		}

		//else if (other.CompareTag("LinePart"))
		//{
		//	if (!playerMovement.jumping)
		//	{
		//		other.transform.GetComponentInParent<LinePart>().Paint();
		//	}
		//}
	}
}
