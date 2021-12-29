using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack1 : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) //공격처리
	{
		this.gameObject.SetActive(false);
		if (other.CompareTag("BOSS"))
			other.GetComponent<BossCtrl>().TakeHit(10); //공격
	}
}
