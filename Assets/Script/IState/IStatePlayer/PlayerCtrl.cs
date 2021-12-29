using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerAnim))]
public class PlayerCtrl : LivingEntity
{
	public enum eState
	{
		Ready, 
		Move, 
		AutoMove,
		Attack, 
		Attack1,
		Attack2,
		Attack3,
		Parrying,
		DIE  
	}
	
	private IStateMachine<PlayerCtrl> m_sm;
	private Dictionary<eState, IState<PlayerCtrl>> m_states = new Dictionary<eState, IState<PlayerCtrl>>();
	public static PlayerCtrl instance = null;
	//컴포넌트
	[HideInInspector]public new Rigidbody rigidbody;
	[HideInInspector]public PlayerAnim playerAnim;
	private Animator animator;
	private NavMeshAgent agent;
	public RectTransform mainMap;
	//공격
	public GameObject Cur_AttackColl;//기본공격
	public GameObject Skill_AttackColl;//스킬공격
	public GameObject Skill_AttackColl1;
	private float globalCooltiome = 0.5f;
	private float Attack1Cooltime = 10f;
	private float Attack2Cooltime = 10f;
	private float Attack3Cooltime = 10f;
	//플레이어 애니메이션

	//플레이어 속도
	private float walkSpeed = 4f; //걷기 속도
	private float runSpeed = 14f; //뛰기 속도
	private float anySpeed; //속도 변경
	float autoDistance; //자동이동 거리
	Vector3 autoVector;

	//기타
	[SerializeField] private new Transform camera; //카메라
	[HideInInspector] public bool isAuto;
	[SerializeField] private Transform swordSapwnPosition;
	[SerializeField] private GameObject[] swordObject;
	private GameObject eqSwordObject;
	public GameObject enemy;
	[HideInInspector] public bool isParrying;
	private Transform startTransform;

	private void Awake() //싱글톤
	{
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(this.gameObject);
	}
	protected override void Start()
	{
		m_states.Add(eState.Ready, new IStatePlayerReady());
		m_states.Add(eState.Move, new IStatePlayerMove());
		m_states.Add(eState.AutoMove, new IStatePlayerMove());
		m_states.Add(eState.Attack, new IStatePlayerAttack());
		m_states.Add(eState.Attack1, new IStatePlayerAttack1());
		m_states.Add(eState.Attack2, new IStatePlayerAttack2());
		m_states.Add(eState.Attack3, new IStatePlayerAttack3());
		m_states.Add(eState.Parrying, new IStatePlayerParrying());
		m_states.Add(eState.DIE, new IStatePlayerDie());
		
		rigidbody = GetComponent<Rigidbody>();
		playerAnim = GetComponent<PlayerAnim>();
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		AgentScrpit(false);

		isAuto = false;

		anySpeed = walkSpeed;

		m_sm = new IStateMachine<PlayerCtrl>(this, m_states[eState.Ready]);
		//초기화 저장
		startTransform = this.transform;
		playerAnim.InitAnim(false);
	}
	public void ChangeState(eState state) //스테이트 체인지
	{
		//Debug.LogWarning(state);
		m_sm.SetState(m_states[state]);
	}
	private void FixedUpdate()
	{
		m_sm.OnFixedUpdate();
	}
	private void Update()
	{ 
		m_sm.OnUpdate();
		globalCooltiome += Time.deltaTime;
		Attack1Cooltime += Time.deltaTime; //쿨타임
		Attack2Cooltime += Time.deltaTime;
		Attack3Cooltime += Time.deltaTime;
		if (hp <= 0) //죽는거 감지
		{
			dead = true;
			ChangeState(eState.DIE);
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			Enemysummons();
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			Init();
		}
	}
	public void DoMove() //Move 처리
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 moveH = transform.right * h;
		Vector3 moveV = transform.forward * v;
		Vector3 velocity = (moveH + moveV).normalized * anySpeed;
		rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
		bool eStateAuto = m_sm.CurState == m_states[eState.AutoMove];
		if(!eStateAuto) //오토일때는 플레이어 회전안함
			transform.rotation = Quaternion.Euler(0,camera.eulerAngles.y,0);
		playerAnim.OnMovement(h, v);

		PlayerRun();
		PlayerAttack();
		Parrying();
	}
	public void Parrying()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			ChangeState(eState.Parrying);
		}

	}
	private void PlayerRun() 
	{
		if (Input.GetKey(KeyCode.LeftShift))
			anySpeed = runSpeed;
		if (Input.GetKeyUp(KeyCode.LeftShift))
			anySpeed = walkSpeed;
	}
	private void PlayerAttack()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			anySpeed = walkSpeed;
			ChangeState(eState.Attack);
		}
		if (Input.GetKeyDown(KeyCode.E) && Attack1Cooltime >= 4f && globalCooltiome >= 0.5f)
		{
			anySpeed = walkSpeed;
			ChangeState(eState.Attack1);
			Attack1Cooltime = 0;
		}
		if (Input.GetKeyDown(KeyCode.R) && Attack2Cooltime >= 7f && globalCooltiome >= 0.5f)
		{
			anySpeed = walkSpeed;
			ChangeState(eState.Attack2);
			Attack2Cooltime = 0f;
		}		
		if (Input.GetKeyDown(KeyCode.T) && Attack3Cooltime >= 7f && globalCooltiome >= 0.5f)
		{
			anySpeed = walkSpeed;
			ChangeState(eState.Attack3);
			Attack3Cooltime = 0f;
		}
	}
	public void AutoMove()
	{
		isAuto = UI.instance.isPause;
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (isAuto)
		{
			if (Input.GetMouseButtonDown(1) && m_sm.CurState != m_states[eState.AutoMove])
			{
				autoVector = MainMap.instance.MainMapPosition();
				if (autoVector.x > 0 && autoVector.x < 300 && autoVector.z > 0 && autoVector.z < 300)
				{
					ChangeState(eState.AutoMove);
					AgentScrpit(true);
					agent.isStopped = false;
					agent.SetDestination(autoVector);
				}
				
			}
		}
		if(h > 0.1f || v > 0.1f || h < -0.1f || v < -0.1f)
		{
			if (m_sm.CurState == m_states[eState.AutoMove])
			{
				agent.isStopped = true;
				ChangeState(eState.Move);
			}
			AgentScrpit(false);
		}
		else
		{
			if (m_sm.CurState == m_states[eState.AutoMove]) 
			{
				autoDistance = Vector3.Distance(this.transform.position,autoVector);
				if (autoDistance <= 0.5f)
				{
					playerAnim.AutoStopamin();
					agent.isStopped = true;
					ChangeState(eState.Move);
					AgentScrpit(false);
				}
				else
					playerAnim.AutoMoveamin();
			}
		}
	}

	public bool AnimEndCheck(string Anim)
	{
		return animator.GetCurrentAnimatorStateInfo(0).IsName(Anim) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f;
	} //애니메이션 끝나는거 체크
	public bool AnimEffectCheck(string Anim, float sce)
	{
		return animator.GetCurrentAnimatorStateInfo(0).IsName(Anim) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.99f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= sce;
	} //애니메이션 이펙트 체크
	public void AgentScrpit(bool a)
	{
		agent.enabled = a;
	}
	public void ChangeWeapon(GameObject _sword)
	{
		if(eqSwordObject != null)
			Destroy(eqSwordObject);
		eqSwordObject = Instantiate(_sword, swordSapwnPosition) as GameObject;
		eqSwordObject.transform.parent = swordSapwnPosition;
	}
	public void DestroyWeapon()
	{
		Destroy(eqSwordObject);
	}
	private void Enemysummons()
	{
		float enemyX = transform.position.x + Random.Range(-5, 5);
		float enemyY = transform.position.y + Random.Range(1,3);
		float enemyZ = transform.position.z + Random.Range(-5, 5);
		Vector3 pos = new Vector3(enemyX, enemyY, enemyZ);
		GameObject go = Instantiate(enemy, pos, Quaternion.identity);
	}
	private void Init()
	{
		this.transform.position = startTransform.position;
		hp = 100;
		dead = false;
		ChangeState(eState.Ready);
	}
}
