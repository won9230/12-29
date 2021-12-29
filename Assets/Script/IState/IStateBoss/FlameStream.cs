using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStream : MonoBehaviour
{
	private ParticleSystem flame;
	private void Start()
	{
		flame = GetComponent<ParticleSystem>();
		Destroy(this.gameObject, 5f);
		StartCoroutine(StartFlame());
	}
	IEnumerator StartFlame()
	{
		flame.Play();
		yield return new WaitForSeconds(2f);
		flame.Stop();
	}
	private void OnParticleCollision(GameObject other)
	{
		if (other.CompareTag("PLAYER"))
		{
			PlayerCtrl playerCtrl = other.GetComponent<PlayerCtrl>();
			if (playerCtrl.isParrying)
				other.GetComponent<PlayerCtrl>().TakeHit(0); //공격
			else
				other.GetComponent<PlayerCtrl>().TakeHit(1);
		}
	}
}
