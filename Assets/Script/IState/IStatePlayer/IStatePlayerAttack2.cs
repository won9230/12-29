using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerAttack2 : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.playerAnim.Attack2();
	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (qstate.AnimEndCheck("Attack2Anim"))
		{
			qstate.ChangeState(PlayerCtrl.eState.Move);
		}
	}
}
