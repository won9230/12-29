using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossAttack1 : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		//qstate.StopCoroutine(qstate.AttackPattern());
		qstate.StartCoroutine(qstate.Attack1());
	}

	public void OnExit(BossCtrl qstate)
	{

	}

	public void OnFixedUpdate(BossCtrl qstate)
	{

	}

	public void OnUpdate(BossCtrl qstate)
	{
		qstate.bossAnim.StopSpeed();
	}

}
