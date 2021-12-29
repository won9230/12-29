using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	private EnemyCtrl enemyCtrl;

	private void Start()
	{
		enemyCtrl = GetComponent<EnemyCtrl>();
	}
}
