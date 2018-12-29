using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyType05 : MonoBehaviour
{
	public Transform enemy;
	public Transform bullet;

	public float shootDuration;
	public float waitDuration;
	public float delayDuration;
	
	private bool shoot;
	
	private Vector3 startPosition;
	private Vector3 startRotation;

	private bool firstEnable = true;
	
	void Start()
	{
		startPosition = enemy.localPosition;
		startRotation = transform.rotation.eulerAngles;
		
		ResetEnemy();
		
		Activate();
	}

	void Update()
	{
		if (GameManager.Instance.gameIsOver)
		{
			shoot = false;
		}
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

	void ResetEnemy()
	{
		shoot = false;
		StopCoroutine(StartShooting());
		enemy.localPosition = startPosition;
		transform.rotation = Quaternion.Euler(startRotation);
		bullet.localPosition = enemy.localPosition;
	}
	
	void Activate()
	{
		shoot = true;
		StartCoroutine(StartShooting());
	}

	IEnumerator StartShooting()
	{
		yield return new WaitForSeconds(delayDuration);
		while (shoot)
		{
			bullet.DOLocalMoveY(1.2f, shootDuration).SetEase(Ease.Linear);
			yield return new WaitForSeconds(waitDuration);
			bullet.localPosition = enemy.localPosition;
		}
	}
}
