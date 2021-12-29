using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
	public GameObject[] Effect;
	public Transform skillpos1;

	private void Start()
	{
		for (int i = 0; i < Effect.Length; i++)
			Effect[i].SetActive(false);
	}
	public void AE_Attack1_true()
	{
		PlayerCtrl.instance.Cur_AttackColl.SetActive(true);
	}
	public void AE_Attack1_false()
	{
		PlayerCtrl.instance.Cur_AttackColl.SetActive(false);
	}
	public void Sk_Attack_true()
	{
		PlayerCtrl.instance.Skill_AttackColl.SetActive(true);
	}
	public void Sk_Attack_false()
	{
		PlayerCtrl.instance.Skill_AttackColl.SetActive(false);
	}
	public void Sk_Attack1_true()
	{
		PlayerCtrl.instance.Skill_AttackColl1.SetActive(true);
	}	
	public void Sk_Attack1_false()
	{
		PlayerCtrl.instance.Skill_AttackColl1.SetActive(false);
	}
	public void Cur_Atk_Eft1_Start()
	{
		Effect[0].SetActive(true);
	}	
	public void Cur_Atk_Eft1_End()
	{
		Effect[0].SetActive(false);
	}	
	public void Cur_Atk_Eft2_Start()
	{
		Effect[1].SetActive(true);
	}	
	public void Cur_Atk_Eft2_End()
	{
		Effect[1].SetActive(false);
	}	
	public void Cur_Atk_Eft3_Start()
	{
		Effect[2].SetActive(true);
	}	
	public void Cur_Atk_Eft3_End()
	{
		Effect[2].SetActive(false);
	}
	public void Anim_Attack1_true()
	{
		Effect[3].SetActive(true);
		Instantiate(Effect[3],skillpos1.position,transform.rotation);
	}
	public void Anim_Attack1_false()
	{
		Effect[3].SetActive(false);
	}
	public void Anim_Attack2_1_Start()
	{
		Effect[4].SetActive(true);
	}	
	public void Anim_Attack2_1_End()
	{
		Effect[4].SetActive(false);
	}
	public void Anim_Attack2_2_Start()
	{
		Effect[5].SetActive(true);
	}
	public void Anim_Attack2_2_End()
	{
		Effect[5].SetActive(false);
	}
	public void Anim_Attack2_3_Start()
	{
		Effect[6].SetActive(true);
	}
	public void Anim_Attack2_3_End()
	{
		Effect[6].SetActive(false);
	}
	public void Anim_Attack2_4_Start()
	{
		Effect[7].SetActive(true);
	}
	public void Anim_Attack2_4_End()
	{
		Effect[7].SetActive(false);
	}	
	public void Anim_Attack3_1_Start()
	{
		Effect[8].SetActive(true);
	}	
	public void Anim_Attack3_1_End()
	{
		Effect[8].SetActive(false);
	}
}
