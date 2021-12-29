using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
	public GameObject HitEffect;

	private void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "ENEMY")
		{
			float randomposX = Random.Range(-0.3f, 0.3f);
			float randomposY = Random.Range(0.8f, 1.2f);
			float randomposZ = Random.Range(-0.3f, 0.3f);
			Vector3 pos = new Vector3(this.transform.position.x + randomposX, this.transform.position.y + randomposY, this.transform.position.z + randomposZ);
			GameObject Hit = Instantiate(HitEffect, pos, Quaternion.identity);
			Hit.transform.parent = this.gameObject.transform;
		}
	}


}
