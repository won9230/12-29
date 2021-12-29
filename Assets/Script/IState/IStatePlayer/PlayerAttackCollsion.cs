using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollsion : MonoBehaviour
{
	public GameObject Blood;
	public GameObject Hit;
	private void OnTriggerEnter(Collider other) //공격처리
	{
		StartCoroutine(SetActive());
		if (other.CompareTag("BOSS"))
		{
			other.GetComponent<BossCtrl>().TakeHit(10); //공격
			Vector3 vec = other.bounds.ClosestPoint(transform.position);
			GameObject blood = Instantiate(Blood, vec, Quaternion.identity);
			blood.transform.parent = other.transform;
		}

		if (other.CompareTag("ENEMY"))
		{
			EnemyCtrl enemyCtrl = other.GetComponent<EnemyCtrl>();
			if (enemyCtrl.state != EnemyCtrl.eState.DIE && enemyCtrl.attackbool)
			{
				enemyCtrl.attackbool = false;
				enemyCtrl.TakeHit(25);
				enemyCtrl.anim.OnHit();
				Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
				GameObject Hitobj = Instantiate(Hit, vec, Quaternion.identity);
				Hitobj.transform.parent = other.transform;
			}
		}
	}
	IEnumerator SetActive()
	{
		yield return new WaitForSeconds(0.2f);
		this.gameObject.SetActive(false);
	}
}
