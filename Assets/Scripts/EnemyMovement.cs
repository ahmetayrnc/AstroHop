using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	public Transform enemy;
	
	public float rotationAmount;
	public float rotationDuration;
	
	[Range(0,5)]
	public int enemyType;

	private Vector3 rotationVectorLeft;
	private Vector3 rotationVectorRight;
	private Vector3 rotationVector;
	
	private Vector3 startPosition;
	private Vector3 startRotation;

	private bool firstEnable = true;
	
	void Start()
	{
		rotationVector = new Vector3(0,0,rotationAmount) + transform.rotation.eulerAngles;
		rotationVectorLeft = new Vector3(0,0,180) + transform.rotation.eulerAngles;
		rotationVectorRight = new Vector3(0,0,-180) + transform.rotation.eulerAngles;
		
		startPosition = enemy.localPosition;
		startRotation = transform.rotation.eulerAngles;
		
		RestartMovement();
	}
	
	void OnEnable()
	{
		if (firstEnable)
		{
			firstEnable = false;
			return;
		}
		
		if (!firstEnable)
		{
			RestartMovement();
		}
	}
	
	void StartMovement0()
	{	
		transform.DORotate(rotationVectorLeft, rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
	}
	
	void StartMovement1()
	{
		transform.DORotate(rotationVectorRight, rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
	}

	void StartMovement2()
	{
		transform.DORotate(rotationVector, rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
	}
	
	public void RestartMovement()
	{
		enemy.localPosition = startPosition;
		transform.rotation = Quaternion.Euler(startRotation);
		
		switch (enemyType)
		{
			case 1:
				StartMovement1();
				break;
			case 2:
				StartMovement2();
				break;
			default:
				StartMovement0();
				break;
		}
	}
}
