using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossTrace : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		if (!qstate.attackPatternbool)
			qstate.StartCoroutine(qstate.AttackPattern());
		qstate.bossHp.SetActive(true);
		if (qstate.hp <= qstate.maxHp * 0.3f && !qstate.isEnemySummons)
		{
			qstate.isEnemySummons = true;
			qstate.StopAllCoroutines();
			qstate.ChangeState(BossCtrl.eState.EnemySummons);
		}
	}

	public void OnExit(BossCtrl qstate)
	{

	}

	public void OnFixedUpdate(BossCtrl qstate)
	{

	}

	public void OnUpdate(BossCtrl qstate)
	{
		qstate.MoveCheak();
	}
}
