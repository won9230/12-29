﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateBossTraceReady : IState<BossCtrl>
{
	public void OnEnter(BossCtrl qstate)
	{
		qstate.StartCoroutine(qstate.TraceReady());
		
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
