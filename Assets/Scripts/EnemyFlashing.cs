using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyFlashing : MonoBehaviour
{
	public float activeDuration;
	public float inactiveDuration;
	
	public Transform enemy;

	private SpriteRenderer enemyGFX;
	private Collider2D enemyCollider;
	private bool firstEnable = true;
	
	void Start()
	{
		enemyCollider = enemy.GetComponent<BoxCollider2D>();
		enemyGFX = enemy.GetComponent<SpriteRenderer>();
		
		ResetEnemy();
		
		Activate();
	}

	private void OnEnable()
	{
		if (firstEnable)
		{
			firstEnable = false;
			return;
		}
		
		ResetEnemy();
		
		Activate();
	}

	void Activate()
	{
		enemyGFX.DOFade(1, 0.2f).SetLoops(5,LoopType.Yoyo).OnComplete(() =>
		{
			enemyCollider.enabled = true;
			StartCoroutine(Deactivate());
		});
	}

	IEnumerator Deactivate()
	{
		yield return new WaitForSeconds(activeDuration);
		
		enemyGFX.DOFade(0, 0.2f).SetLoops(5,LoopType.Yoyo).OnComplete(ResetEnemy);
		
		yield return new WaitForSeconds(inactiveDuration);
		Activate();
		
	}
	
	void ResetEnemy()
	{
		enemyCollider.enabled = false;
		Color newColor = enemyGFX.color;
		newColor.a = 0;
		enemyGFX.color = newColor;
	}
}
