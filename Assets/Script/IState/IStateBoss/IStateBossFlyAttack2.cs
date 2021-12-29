using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossFlyAttack2 : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.FlyAttack2());
	}

	public void OnExit(BossCtrl qstate)
	{

	}

	public void OnFixedUpdate(BossCtrl qstate)
	{

	}

	public void OnUpdate(BossCtrl qstate)
	{
		qstate.TargetLookRotation();
	}
}
