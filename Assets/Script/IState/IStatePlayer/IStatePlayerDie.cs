using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerDie : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.playerAnim.IsDie();
	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{
	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		qstate.playerAnim.InitAnim(false);
	}
}
