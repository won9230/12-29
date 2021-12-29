using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossAttack : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.Cur_Attack());
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
