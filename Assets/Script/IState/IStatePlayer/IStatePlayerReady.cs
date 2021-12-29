using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerReady : IState<PlayerCtrl>
{
	Rigidbody rigidbody;
	public void OnEnter(PlayerCtrl qstate)
	{
		rigidbody = qstate.GetComponent<Rigidbody>();
		rigidbody.isKinematic = true;

	}

	public void OnExit(PlayerCtrl qstate)
	{

	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			qstate.ChangeState(PlayerCtrl.eState.Move);
		qstate.playerAnim.InitAnim(true);
	}
}
