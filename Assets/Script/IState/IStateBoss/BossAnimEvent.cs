using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimEvent : MonoBehaviour
{
	public GameObject[] effect;
	public GameObject[] Trail;
	public GameObject attackColl;
	private ParticleSystem[] fireballParticle;
	public Transform fire;
	public Transform flyfire;
	public Transform flame;
	public Transform flyflame;
	public Transform boss;

	private void Start()
	{
		for (int i = 0; i < effect.Length; i++)
			effect[i].SetActive(false);
		for (int i = 0; i < Trail.Length; i++)
			Trail[i].SetActive(false);
	}
	public void Anim_CreativeEffect()
	{
		effect[0].SetActive(true);
		GameObject Fireball1 = Instantiate(effect[0],fire.position,boss.rotation);
		fireballParticle = Fireball1.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < fireballParticle.Length; i++)
			fireballParticle[i].Play();
	}
	public void Anim_FlyCreativeEffect()
	{
		float y = Random.Range(-10, 11);
		Quaternion qua = Quaternion.Euler(Random.Range(-50,-70),-90,0);
		effect[0].SetActive(true);
		GameObject Fireball2 = Instantiate(effect[0], flyfire.position,boss.rotation);
		fireballParticle = Fireball2.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < fireballParticle.Length; i++)
			fireballParticle[i].Play();
	}
	public void Anim_Creativebreath()
	{
		effect[1].SetActive(true);
		GameObject Firebreath1 = Instantiate(effect[1], flame.position, boss.rotation);
		Firebreath1.transform.parent = flame.transform;
	}
	public void Anim_FlyCreativebreath()
	{
		effect[2].SetActive(true);
		GameObject Firebreath2 = Instantiate(effect[2], flyflame.position, flyflame.rotation);
		Firebreath2.transform.parent = flyflame.transform;
	}
	public void Anim_TrueLeftTrail()
	{
		for (int i = 0; i < 4; i++)
			Trail[i].SetActive(true);
	}
	public void Anim_FalseLeftTrail()
	{
		for (int i = 0; i < 4; i++)
			Trail[i].SetActive(false);
	}
	public void Anim_TrueRightTrail()
	{
		for (int i = 4; i < 8; i++)
			Trail[i].SetActive(true);
	}
	public void Anim_FalseRightTrail()
	{
		for (int i = 4; i < 8; i++)
			Trail[i].SetActive(false);
	}
	public void Anim_AttackColl_true()
	{
		attackColl.SetActive(true);
	}
	public void Anim_AttackColl_false()
	{
		attackColl.SetActive(false);
	}
}
