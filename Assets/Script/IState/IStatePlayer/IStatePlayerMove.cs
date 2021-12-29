using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerMove : IState<PlayerCtrl>
{

	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.rigidbody.isKinematic = false;
		qstate.playerAnim.Cur_Atk_Can();
	}
	public void OnExit(PlayerCtrl qstate)
	{
	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{
	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		qstate.DoMove();
		qstate.AutoMove();
	}
}
