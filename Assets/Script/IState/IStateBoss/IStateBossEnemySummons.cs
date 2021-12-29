﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossEnemySummons : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.EnemySummons());
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
