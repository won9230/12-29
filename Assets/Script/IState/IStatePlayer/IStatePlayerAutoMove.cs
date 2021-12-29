using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerAutoMove : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{

	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		qstate.playerAnim.AutoMoveamin();
	}
}
