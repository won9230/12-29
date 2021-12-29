using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
	public GameObject boxcoll;
	private EnemyCtrl enemy;
	private void Start()
	{
		enemy = GetComponent<EnemyCtrl>();
	}

	public void Attack1Start()
	{
		boxcoll.SetActive(true);
	}
	public void Attack1End()
	{
		boxcoll.SetActive(false);
	}
	public void AttackTrue()
	{
		enemy.attackbool = true;
	}
}
