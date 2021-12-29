using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMoveagent : MonoBehaviour
{
    private Transform bossTr;
    private NavMeshAgent agent;

    private float damping = 1.0f;

    private readonly float traceRunSpeed = 7.0f;
    private readonly float traceWalkSpeed = 4.0f;

    private Vector3 _traceTaget;

    public Vector3 traceTargetWalk
	{
		get { return _traceTaget; }
		set
		{
            _traceTaget = value;
            agent.speed = traceWalkSpeed;
            damping = 7.0f;
            TraceTarget(_traceTaget);
		}
	}
    public Vector3 traceTargetRun
	{
		get { return _traceTaget; }
		set
		{
            _traceTaget = value;
            agent.speed = traceRunSpeed;
            damping = 10.0f;
            TraceTarget(_traceTaget);
		}
	}

    void Start()
    {
        bossTr = this.GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        agent.updateRotation = false;
    }

    void Update()
    {
        if (agent.isStopped == false)
		{
            Quaternion rot;
            if(agent.desiredVelocity != Vector3.zero)
			{
                rot = Quaternion.LookRotation(agent.desiredVelocity);
                bossTr.rotation = Quaternion.Slerp(bossTr.rotation, rot, Time.deltaTime * damping);
			}
		}
    }

    void TraceTarget(Vector3 pos)
	{
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
	}
	public void Stop()
	{
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
	}
    public void ScriptFalse()
	{
        agent.enabled = false;
	}
    public void ScriptTrue()
	{
        agent.enabled = true;
	}
}
