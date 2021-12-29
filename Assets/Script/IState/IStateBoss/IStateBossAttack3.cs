using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossAttack3 : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.Attack3());
	}

	public void OnExit(BossCtrl qstate)
	{
	}

	public void OnFixedUpdate(BossCtrl qstate)
	{
	}

	public void OnUpdate(BossCtrl qstate)
	{
	}
}
