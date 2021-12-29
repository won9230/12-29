using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossDIE : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.IsDIE();
		qstate.bossMoveagent.Stop();
		qstate.bossMoveagent.ScriptTrue();
		qstate.StopAllCoroutines();
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
