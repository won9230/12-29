using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerParrying : IState<PlayerCtrl>
{
	public void OnEnter(PlayerCtrl qstate)
	{
		qstate.isParrying = true;
		qstate.playerAnim.Parrying(true);
	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (Input.GetKeyUp(KeyCode.Z))
		{
			qstate.isParrying = false;
			qstate.playerAnim.Parrying(false);
			qstate.ChangeState(PlayerCtrl.eState.Move);
		}
		Vector3 vec = new Vector3(qstate.transform.position.x, qstate.transform.position.y, qstate.transform.position.z);
		qstate.transform.position = vec;
	}
}
