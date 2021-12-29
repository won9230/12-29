using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}
	public void isWalk(bool walk)
	{
		anim.SetBool("isWalk", walk);
	}
	public void Attack(bool _attack)
	{
		anim.SetBool("Attack",_attack);
	}
	public void OnHit()
	{
		anim.SetTrigger("OnHit");
	}
	public void OnDie(bool isDie)
	{
		anim.SetBool("isDie", isDie);
	}
}
