using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
	private Animator anim;
	private BossCtrl boss;
	private void Start()
	{
		anim = GetComponent<Animator>();
		boss = GetComponent<BossCtrl>();
	}
	public void isMove()
	{
		anim.SetBool("isMove", true);
	}
	public void walkSpeed()
	{
		if (boss.speed <= 0.5f)
			boss.speed += Time.deltaTime;
		if (boss.speed >= 0.5f)
			boss.speed -= Time.deltaTime;
		anim.SetFloat("Speed", boss.speed);
	}	
	public void RunSpeed()
	{
		if (boss.speed <= 1f)
			boss.speed += Time.deltaTime;
		if (boss.speed >= 1f)
			boss.speed -= Time.deltaTime;
		anim.SetFloat("Speed", boss.speed);
	}
	public void StopSpeed()
	{
		if (boss.speed >= 0f)
			boss.speed -= Time.deltaTime;
		anim.SetFloat("Speed", boss.speed);
	}
	public void CancelAnim(string str)
	{
		anim.ResetTrigger(str);
	}
	public void Attack()
	{
		anim.SetTrigger("Attack");
	}
	public void Attack1()
	{
		anim.SetTrigger("Attack1");
	}	
	public void Attack2()
	{
		anim.SetTrigger("Attack2");
	}
	public void Attack3()
	{
		anim.SetTrigger("Attack3");
	}
	public void isFly(bool fly)
	{
		anim.SetBool("isFlyAttack", fly);
	}
	public void FlyAttack1()
	{
		anim.SetTrigger("FlyAttack1");
	}	
	public void FlyAttack2()
	{
		anim.SetTrigger("FlyAttack2");
	}
	public void OnHit()
	{
		anim.SetTrigger("OnHit");
	}
	public void IsDIE()
	{
		anim.SetBool("isDie",true);
	}
	public void IsEnemySummons()
	{
		anim.SetTrigger("isEnemySummons");
	}
}
