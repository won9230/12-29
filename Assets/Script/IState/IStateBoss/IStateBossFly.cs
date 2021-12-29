using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossFly : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.Fly());
	}

	public void OnExit(BossCtrl qstate)
	{

	}

	public void OnFixedUpdate(BossCtrl qstate)
	{

	}

	public void OnUpdate(BossCtrl qstate)
	{
		if (qstate.hp <= 0)
			qstate.ChangeState(BossCtrl.eState.DIE);
	}
}
