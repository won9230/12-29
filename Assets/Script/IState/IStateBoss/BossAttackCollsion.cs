using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCollsion : MonoBehaviour
{
	public GameObject Hit;
	private void OnTriggerEnter(Collider other) //공격처리
	{
		//this.gameObject.SetActive(false);
		//if (other.CompareTag("PLAYER"))
		//{
		//	PlayerCtrl playerCtrl = other.GetComponent<PlayerCtrl>();
		//	if (playerCtrl.isParrying)
		//	{
		//		playerCtrl.TakeHit(5); //공격
		//	}
		//	else
		//	{
		//		playerCtrl.TakeHit(10);
		//		playerCtrl.playerAnim.OnHit();
		//	}
		//}
		if (other.CompareTag("PLAYER"))
		{
			PlayerCtrl playerCtrl = other.GetComponent<PlayerCtrl>();
			if (playerCtrl.isParrying)
			{
				other.GetComponent<PlayerCtrl>().TakeHit(1); //공격
				Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);

				GameObject blood = Instantiate(Hit, vec, Quaternion.identity);
				blood.transform.parent = other.transform;
				this.gameObject.SetActive(false);

			}
			else
			{
				if (!playerCtrl.dead)
				{
					other.GetComponent<PlayerCtrl>().TakeHit(10);

					Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
					GameObject blood = Instantiate(Hit, vec, Quaternion.identity);
					blood.transform.parent = other.transform;
					this.gameObject.SetActive(false);
					playerCtrl.playerAnim.OnHit();
				}
			}
		}
	}
}