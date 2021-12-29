using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
	private BossCtrl bossCtrl;

	private void Start()
	{
		bossCtrl = GetComponent<BossCtrl>();
	}
	private void OnTriggerEnter(Collider other)
	{
		float hp = bossCtrl.hp;
		if(hp <= 0.0f)
			bossCtrl.ChangeState(BossCtrl.eState.DIE);
	}
}
