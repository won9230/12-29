using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossAttack2 : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		//.StopCoroutine(qstate.AttackPattern());
		qstate.StartCoroutine(qstate.Attack2());
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
