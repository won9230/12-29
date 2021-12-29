using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	#region Singleton

	public static EquipmentManager instance;
	private void Awake()
	{
		instance = this;
	}
	#endregion

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;
	Inventory inventory;
	Equipment[] currentEquipment;
	public WeaponSlot weaponSlot;

	private void Start()
	{
		inventory = Inventory.instance;
		

		int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
	}
	public void Equip(Equipment newItem)
	{
		int slotIndex = (int)newItem.equipSlot;

		Equipment oldItem = null;

		if(currentEquipment[slotIndex] != null)
		{
			oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);
		}
		if (onEquipmentChanged != null)
		{
			onEquipmentChanged.Invoke(newItem, oldItem);
			inventory.Add(oldItem);
		}
		currentEquipment[slotIndex] = newItem;
		weaponSlot.AddItem(newItem);
	}

	public void Unequip(int slotIndex)
	{
		if(currentEquipment[slotIndex] != null)
		{
			Equipment oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);

			currentEquipment[slotIndex] = null;
			weaponSlot.ClearSlot();
			if (onEquipmentChanged != null)
			{
				onEquipmentChanged.Invoke(null, oldItem);
			}
			PlayerCtrl.instance.DestroyWeapon();
		}	
	}
	public void UnequipAll()
	{
		for (int i = 0; i < currentEquipment.Length; i++)
		{
			Unequip(i);
		}
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			UnequipAll();
		}
	}
}
