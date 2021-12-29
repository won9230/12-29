using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
	public Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void OnMovement(float h, float v) //움직임 애니
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			animator.SetFloat("horizontal", h);
			animator.SetFloat("vertical", v);
		}
		else
		{
			animator.SetFloat("horizontal", h * 0.5f);
			animator.SetFloat("vertical", v * 0.5f);
		}
	}
	public void AutoMoveamin()
	{
		animator.SetFloat("vertical", 1f);
	}	
	public void AutoStopamin()
	{
		animator.SetFloat("vertical", 0f);
	}
	public void Cur_Atk() //공격
	{
		animator.SetTrigger("Cur_Atk");
	}
	public void Cur_Atk_Can()
	{
		animator.ResetTrigger("Cur_Atk");
	}
	public void OnHit()
	{
		animator.SetTrigger("OnHit");
	}
	public void Attack1()
	{
		animator.SetTrigger("Attack1");
	}
	public void IsDie()
	{
		animator.SetTrigger("isDie");
	}
	public void Attack2()
	{
		animator.SetTrigger("Attack2");
	}
	public void Attack3()
	{
		animator.SetTrigger("Attack3");
	}
	public void Parrying(bool _parrying)
	{
		animator.SetBool("Parrying", _parrying);
	}
	public void InitAnim(bool _Init)
	{
		animator.SetBool("Init", _Init);
	}
}
