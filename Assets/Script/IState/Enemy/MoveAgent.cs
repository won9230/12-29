using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{

	private	NavMeshAgent agent;
	private Transform enemyTr;

	private readonly float traceSpeed = 4.0f;
	private float damping = 1.0f;

	private Vector3 _traceTarget;

	public Vector3 traceTarget
	{
		get { return _traceTarget; }
		set
		{
			_traceTarget = value;
			agent.speed = traceSpeed;
			damping = 7.0f;
			TraceTarget(_traceTarget);
		}
	}
	private void Start()
	{
		enemyTr = GetComponent<Transform>();
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
		agent.updateRotation = false;
	}
	private void Update()
	{
		if (agent.isStopped == false)
		{
			Quaternion rot;
			if (agent.desiredVelocity != Vector3.zero)
			{
				rot = Quaternion.LookRotation(agent.desiredVelocity);
				enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
			}
		}
	}
	private void TraceTarget(Vector3 pos)
	{
		if (agent.isPathStale) return;
		agent.SetDestination(pos);
		agent.isStopped = false;
	}
	public void Stop()
	{
		agent.isStopped = true;
		agent.velocity = Vector3.zero;
	}
}
