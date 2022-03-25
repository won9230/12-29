using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossCtrl : LivingEntity
{
    public enum eState
	{
        Patrol,
        TraceReady,
        Trace,
        Attack,
        Attack1,
        Attack2,
        Attack3,
        EnemySummons,
        Fly,
        FlyAttack1,
        FlyAttack2,
        Landing,
        DIE,
	}

    private IStateMachine<BossCtrl> m_sm;
    private Dictionary<eState, IState<BossCtrl>> m_states = new Dictionary<eState, IState<BossCtrl>>();

    private Transform playerTr;
    private Transform bossTr;
    public GameObject bossHp;
    [HideInInspector] public BossMoveagent bossMoveagent;
    [HideInInspector] public BossAnim bossAnim;

    public float traceDist = 15.0f;
    public float attackDist = 7.0f;
    [HideInInspector] public float speed = 0f;
    [HideInInspector] public bool attackPatternbool = false;
    [HideInInspector]public bool isEnemySummons = false;

    public GameObject enemy;
  

    protected override void Start()
    {
        m_states.Add(eState.Patrol, new IStateBossPatrol());
        m_states.Add(eState.TraceReady, new IStateBossTraceReady());
        m_states.Add(eState.Trace, new IStateBossTrace());
        m_states.Add(eState.Attack, new IStateBossAttack());
        m_states.Add(eState.Attack1, new IStateBossAttack1());     
        m_states.Add(eState.Attack2, new IStateBossAttack2());
        m_states.Add(eState.Attack3, new IStateBossAttack3());
        m_states.Add(eState.EnemySummons, new IStateBossEnemySummons());     
        m_states.Add(eState.Fly, new IStateBossFly());
        m_states.Add(eState.FlyAttack1, new IStateBossFlyAttack1());
        m_states.Add(eState.FlyAttack2, new IStateBossFlyAttack2());
        m_states.Add(eState.Landing, new IStateBossLand());
        m_states.Add(eState.DIE, new IStateBossDIE());
        m_sm = new IStateMachine<BossCtrl>(this, m_states[eState.Patrol];)

        playerTr = PlayerCtrl.instance.transform;
        bossTr = this.transform;
        bossMoveagent = GetComponent<BossMoveagent>();
        bossAnim = GetComponent<BossAnim>();

        bossHp.SetActive(false);
        hp = maxHp;
    }
    public void ChangeState(eState state)
	{
        //Debug.LogWarning(state);
        m_sm.SetState(m_states[state]);
	}
    public bool CheakState(eState state)
	{
        return m_sm.CurState == m_states[state];
	}
	private void FixedUpdate()
	{
        m_sm.OnFixedUpdate();
	}
	void Update()
    {
        m_sm.OnUpdate();
        if (hp <= 0)
            ChangeState(eState.DIE);

    }
    public float dist()
	{
        return (playerTr.position - bossTr.position).sqrMagnitude;
	}
    public void ChackTraceReady()
	{
        if(dist() <= traceDist * traceDist)
            ChangeState(eState.TraceReady);
	}
    public IEnumerator TraceReady()
	{
        bossAnim.isMove();
        yield return new WaitForSeconds(3f);
        ChangeState(eState.Trace);
	}
    public void MoveCheak()
	{
        if (dist() <= traceDist * traceDist)
		{
            bossAnim.walkSpeed();
            bossMoveagent.traceTargetWalk = playerTr.position;

		}
        if(dist() >= traceDist * traceDist)
		{
            bossAnim.RunSpeed();
            bossMoveagent.traceTargetRun = playerTr.position;
		}
        if(dist() <= attackDist * attackDist)
		{
            ChangeState(eState.Attack);
		}
	}
    public IEnumerator Cur_Attack()
	{
        bossMoveagent.Stop();
        bossAnim.Attack();
        yield return new WaitForSeconds(1.5f);
        if(CheakState(eState.Attack))
            ChangeState(eState.Trace);
	}
    public IEnumerator AttackPattern()
	{
        attackPatternbool = true;
        int i;
      //  Debug.Log("AttackPattern코루틴 시작");
        yield return new WaitForSeconds(5f);
        if (hp >= maxHp * 0.5f)
            i = Random.Range(0,3);
        else
            i = Random.Range(0,6);
		switch (i)
		{
			case 0:
				ChangeState(eState.Attack1);
				break;
			case 1:
				ChangeState(eState.Attack2);
				break;
            case 2:
                ChangeState(eState.Attack3);
                break;
            case 3:
                if (!CheakState(eState.Attack))
                    ChangeState(eState.Fly);
                else
                    ChangeState(eState.Attack2);
                break;
            case 4:
                if (!CheakState(eState.Attack))
                    ChangeState(eState.Fly);
                else
                    ChangeState(eState.Attack1);
                break;  
            case 5:
                if (!CheakState(eState.Attack))
                    ChangeState(eState.Fly);
                else
                    ChangeState(eState.Attack1);
                break;
		}
        attackPatternbool = false;
    }
    public IEnumerator Attack1()
	{
        bossMoveagent.Stop();
        bossAnim.Attack2();
        yield return new WaitForSeconds(2.5f);
        ChangeState(eState.Trace);
	}
    public IEnumerator Attack2()
	{
        bossMoveagent.Stop();
        bossAnim.CancelAnim("Attack");
        bossAnim.Attack1();
        yield return new WaitForSeconds(1f);
        bossAnim.Attack1();
        yield return new WaitForSeconds(1f);  
        bossAnim.Attack1();
        yield return new WaitForSeconds(1.5f);
        ChangeState(eState.Trace);
    }
    public IEnumerator Attack3()
	{
        bossMoveagent.Stop();
        bossAnim.Attack3();
        yield return new WaitForSeconds(3.5f);
        ChangeState(eState.Trace);
	}
    public IEnumerator Fly()
	{
        bossMoveagent.ScriptFalse();
        speed = 0;
        bossMoveagent.enabled = false;
        bossAnim.isFly(true);
        yield return new WaitForSeconds(2f);
        transform.DOLocalMoveY(bossTr.position.y + 7, 2).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(3f);
        int i = Random.Range(0,2);
		switch (i)
		{
            case 0:
                ChangeState(eState.FlyAttack1);
                break;
            case 1:
                ChangeState(eState.FlyAttack2);
                break;
		}
	}
    public IEnumerator FlyAttack1()
	{
        bossAnim.FlyAttack1();
        yield return new WaitForSeconds(1f);
        bossAnim.FlyAttack1();
        yield return new WaitForSeconds(1f);
        bossAnim.FlyAttack1();
        yield return new WaitForSeconds(1.5f);
        ChangeState(eState.Landing);
	}
    public IEnumerator FlyAttack2()
    {
        bossAnim.FlyAttack2();
        yield return new WaitForSeconds(3f);
        ChangeState(eState.Landing);
    }
    public IEnumerator Landing()
	{
        bossAnim.isFly(false);
        yield return new WaitForSeconds(1f);
        transform.DOLocalMoveY(bossTr.position.y-7, 1).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(1f);
        bossMoveagent.enabled = true;
        bossMoveagent.ScriptTrue();
        ChangeState(eState.Trace);
	}
    public IEnumerator EnemySummons()
    {
        bossAnim.IsEnemySummons();
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
		{
            yield return new WaitForSeconds(0.3f);
            Enemysummons();
        }
        ChangeState(eState.Trace);
    }
    private void Enemysummons()
    {
        float enemyX = transform.position.x + Random.Range(-5, 5);
        float enemyY = transform.position.y + Random.Range(1, 3);
        float enemyZ = transform.position.z + Random.Range(-5, 5);
        Vector3 pos = new Vector3(enemyX, enemyY, enemyZ);
        GameObject go = Instantiate(enemy, pos, Quaternion.identity);
    }
    public void TargetLookRotation()
	{
        Vector3 vec = playerTr.transform.position - transform.position;
        Quaternion qua = Quaternion.LookRotation(vec);
        transform.rotation = qua;
	}
    public void IsDIE()
	{
        bossAnim.IsDIE();
	}
    private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackDist);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, traceDist);
	}
}
