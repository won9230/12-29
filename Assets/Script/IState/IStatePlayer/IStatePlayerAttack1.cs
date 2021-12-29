using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerAttack1 : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.playerAnim.Attack1();
	}

	public void OnExit(PlayerCtrl qstate)
	{
	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{
	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (qstate.AnimEndCheck("Skill_H"))
			qstate.ChangeState(PlayerCtrl.eState.Move);
	}
}
