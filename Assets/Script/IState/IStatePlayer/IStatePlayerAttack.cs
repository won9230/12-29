using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatePlayerAttack :  IState<PlayerCtrl>
{
	private bool next1;
	private bool next2;
	public void OnEnter(PlayerCtrl qstate)
	{
		next1 = false;
		next2 = false;
		qstate.playerAnim.Cur_Atk();
	}

	public void OnExit(PlayerCtrl qstate)
	{
		
	}

	public void OnFixedUpdate(PlayerCtrl qstate)
	{

	}

	public void OnUpdate(PlayerCtrl qstate)
	{
		if (qstate.AnimEffectCheck("Cur_Atk_1", 0.2f))
			if (Input.GetKeyDown(KeyCode.Q))
				qstate.playerAnim.Cur_Atk();
			else
				next1 = true;
		if (qstate.AnimEndCheck("Cur_Atk_1"))
			if (next1)
				qstate.ChangeState(PlayerCtrl.eState.Move);
		if (qstate.AnimEffectCheck("Cur_Atk_2", 0.2f))
			if (Input.GetKeyDown(KeyCode.Q))
				qstate.playerAnim.Cur_Atk();
			else
				next2 = true;
		if (qstate.AnimEndCheck("Cur_Atk_2"))
			if (next2)
				qstate.ChangeState(PlayerCtrl.eState.Move);
		if (qstate.AnimEndCheck("Cur_Atk_3"))
			qstate.ChangeState(PlayerCtrl.eState.Move);
	}
}
