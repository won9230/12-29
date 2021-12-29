using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
	public EquipmentSlot equipSlot;
	public GameObject gameObject;
	public WeaponSlot weaponSlot;
	//public int damageModifier;

	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);
		PlayerCtrl.instance.ChangeWeapon(gameObject);
		RemoveFormInventory();
	}
}
public enum EquipmentSlot { Weapon }
