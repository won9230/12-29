using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
{
	private Rigidbody rb;
	public float speed = 1000f;
	public GameObject Effect;
	private void Start()
	{
		rb =  GetComponent<Rigidbody>();
	}
	private void Update()
	{
		rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PLAYER"))
		{
			PlayerCtrl playerCtrl = other.GetComponent<PlayerCtrl>();
			if (playerCtrl.isParrying)
			{
				playerCtrl.TakeHit(5); //공격
			}
			else
			{
				playerCtrl.TakeHit(10);
				Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
				GameObject blood = Instantiate(Effect, vec, Quaternion.identity);
				blood.transform.parent = other.transform;
				this.gameObject.SetActive(false);
				playerCtrl.playerAnim.OnHit();
			}
		}
	}
}
