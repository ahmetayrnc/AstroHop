using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{	
	private Vector3 rotationVector;
	
	[HideInInspector]
	public bool jumping;
	[HideInInspector] 
	public bool jumpingUp;
	[HideInInspector] 
	public bool moving;
		
	public float rotationDuration;
	public float maxJumpHeight;
	public float planetSize;
	public Transform player;
	public Animator anim;
	
	void Start()
	{
		Application.targetFrameRate = 60;
		
		rotationVector = new Vector3(0,0,-180);
	}
	
	void Update()
	{
		if (GameManager.Instance.gameIsOver)
		{
			moving = false;
			jumpingUp = false;
			
			anim.SetBool("Moving", false);
			anim.SetBool("JumpingUp", false);
			
			return;
		}
		
		anim.SetBool("Moving", moving && !jumping);
		anim.SetBool("JumpingUp", jumping && jumpingUp);
		
		if (!jumping)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Jump(0.6f);
			}
		}
		else
		{
			if ( Input.GetMouseButtonUp(0) || player.transform.localPosition.y >= (maxJumpHeight + planetSize / 2))
			{
				GoDown();
			}
		}
	}
	
	public void StartMovement()
	{
		moving = true;
		transform.DORotate(rotationVector, rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
	}

	void Jump( float height )
	{
		jumping = true;
		jumpingUp = true;
		
		player.DOLocalMoveY(planetSize / 2 + height, height).SetEase(Ease.OutSine);
	}

	void GoDown()
	{
		jumpingUp = false;
		
		DOTween.Kill(player);
		player.DOLocalMoveY(planetSize / 2, (player.transform.localPosition.y - planetSize / 2) / 2.5f).SetEase(Ease.InSine).OnComplete( () => { jumping = false; } );
	}

	public void StopMovement()
	{
		moving = false;
		DOTween.KillAll();
	}

	public void ResetPlayer()
	{
		anim.SetTrigger("Reset");
		
		transform.rotation = Quaternion.identity;
		player.localPosition = new Vector3(0,planetSize / 2,0);
		jumping = false;
	}
}
