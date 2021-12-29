 ﻿using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class EnemyCtrl : LivingEntity
 {
 	public enum eState
 	{
 		Ready,
 		Trace, //추격
 		Attack, //공격
 		DIE, //죽음
 	}
	public eState state = eState.Ready;
 
 	[HideInInspector] public Transform playerTr; //플레이어 위치
 	[HideInInspector] public Transform enemyTr; //내위치
 
 	[HideInInspector]public EnemyAnim anim; //애니메이션
 	public float attackDist = 1.0f; //공격 사거리
 	public bool iswalk = false; //걷고있다
	[HideInInspector]public MoveAgent moveagent; //내비매쉬
	[HideInInspector] public bool attackbool;
	protected override void Start()
	{

 		playerTr = PlayerCtrl.instance.transform;
 		enemyTr = GetComponent<Transform>();
 		anim = GetComponent<EnemyAnim>();
 		moveagent = GetComponent<MoveAgent>();
		attackbool = true;
		StartCoroutine(CheckState());
		StartCoroutine(Action());
	}
	public void Update()
	{
		if(state == eState.DIE)
 		{
			iswalk = false;
			moveagent.Stop();
			anim.OnDie(true);
			ObjDestroy();
 		}
 	}
	public void ObjDestroy()
	{
		Destroy(this.gameObject, 3.0f);
	}

	IEnumerator CheckState()
	{
		while (true)
		{
			if (hp <= 0) 
			{ 
				state = eState.DIE;
				StopAllCoroutines();
			}

			if (state != eState.Ready && state != eState.DIE)
			{
				if (dead) yield break;
				float dist = (playerTr.position - enemyTr.position).sqrMagnitude;
				if (dist <= attackDist * attackDist)
					state = eState.Attack;
				else
					state = eState.Trace;
			}
			yield return new WaitForSeconds(0.3f);
		}
	}
	IEnumerator Action()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.3f);
			switch (state)
			{
				case eState.Ready:
					anim.isWalk(!iswalk);
					yield return new WaitForSeconds(1f);
					state = eState.Trace;
					break;
				case eState.Trace:
					anim.Attack(false);
					moveagent.traceTarget = playerTr.position;
					anim.isWalk(iswalk);
					break;
				case eState.Attack:
						moveagent.Stop();
						anim.Attack(true);
						yield return new WaitForSeconds(1f);
					break;
			}
		}
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, attackDist);
	} //범위 기즈모
}