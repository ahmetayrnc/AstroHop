using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyType03 : MonoBehaviour
{
	public Transform enemy;

	[Tooltip("-1 for right / +1 for left / 0 no movement")]
	public int direction;
	public float jumpHeight;
	public float rotationDuration;
	public float rotationAmount;
	
	private bool firstEnable = true;
	private Vector3 startPosition;
	private Vector3 startRotation;
	
	void Start()
	{
		startPosition = enemy.localPosition;
		startRotation = transform.rotation.eulerAngles;
		
		ResetEnemy();
		
		Activate();
	}
	
	void OnEnable()
	{
		if (firstEnable)
		{
			firstEnable = false;
			return;
		}
		
		ResetEnemy();
		
		Activate();
	}
	
	public void Activate()
	{
		enemy.DOLocalMoveY(startPosition.y + jumpHeight, rotationDuration / 2).SetEase(Ease.OutSine).OnComplete(() =>
		{
			enemy.DOLocalMoveY(startPosition.y, rotationDuration / 2).SetEase(Ease.InSine);
		}); 
		transform.DORotate(startRotation + Vector3.forward * (rotationAmount * direction), rotationDuration).SetEase(Ease.Linear).SetLoops( -1, LoopType.Incremental).OnStepComplete(
			() => 
			{
				enemy.DOLocalMoveY(startPosition.y + jumpHeight, rotationDuration / 2).SetEase(Ease.OutSine).OnComplete(() =>
					{
						enemy.DOLocalMoveY(startPosition.y, rotationDuration / 2).SetEase(Ease.InSine);
					}); 
			});
	}

	public void ResetEnemy()
	{
		enemy.localPosition = startPosition;
		transform.rotation = Quaternion.Euler(startRotation);
	}
	
}
