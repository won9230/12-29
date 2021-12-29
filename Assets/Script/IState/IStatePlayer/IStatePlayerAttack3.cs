using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerAttack3 : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.playerAnim.Attack3();
	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (qstate.AnimEndCheck("Attack3Anim"))
		{
			qstate.ChangeState(PlayerCtrl.eState.Move);
		}
	}
}
