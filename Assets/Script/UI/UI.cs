using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public Slider playerSlhp;
	public Slider bossSlhp;
	public GameObject playerFillArea;
	public GameObject bossFillArea;
	public GameObject mainMap;

	public static UI instance = null;

	//[HideInInspector] public PlayerCtrl player;
	[HideInInspector] public BossCtrl boss;

	private float playerMaxHp;
	private float playerCurHp;
	private float bossMaxHp;
	private float bossCurHp;
	[HideInInspector] public bool isPause = false;

	private void Awake() //싱글톤
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(this.gameObject);
	}
	private void Start()	
	{
		mainMap.SetActive(false);
		boss = FindObjectOfType<BossCtrl>().GetComponent<BossCtrl>();
		playerMaxHp = PlayerCtrl.instance.maxHp; //플레이어 MaxHp
		playerCurHp = PlayerCtrl.instance.hp; //플레이어 Hp
		bossMaxHp = boss.maxHp; //보스 MaxHp
		bossCurHp = boss.hp; //보스 Hp
		//슬라이더
		playerSlhp.maxValue = playerMaxHp;
		bossSlhp.maxValue = bossMaxHp;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	private void Update()
	{
		PlayerHp();
		BossHp();
		MainMap();
		GameStart();
		GameStop();
	}
	private void PlayerHp() //플레이어 Hp관련
	{
		playerCurHp = PlayerCtrl.instance.hp;
		playerSlhp.value = playerCurHp;
		if (playerSlhp.value <= 0)
			playerFillArea.SetActive(false);
		else
			playerFillArea.SetActive(true);
		
	}
	private void BossHp() //보스 Hp관련
	{
		bossCurHp = boss.hp;
		bossSlhp.value = bossCurHp;
		if (bossSlhp.value <= 0)
			bossFillArea.SetActive(false);
		else
			bossFillArea.SetActive(true);
	}
	private void MainMap() //미니맵
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			isPause = !isPause;
			if (isPause)
			{
				Time.timeScale = 0f;
				mainMap.SetActive(isPause);
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Time.timeScale = 1f;
				mainMap.SetActive(isPause);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
	}
	private void GameStop()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			Time.timeScale = 0f;
		}
	}
	private void GameStart()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Time.timeScale = 1f;
		}
	}
}