﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
	public Item item;
	public override void Interact()
	{
		base.Interact();
		PickUp();
	}
	public void PickUp()
	{
		//Debug.Log("Picking up " + item.name);
		bool wasPockUp = Inventory.instance.Add(item);
		if(wasPockUp)
			Destroy(gameObject);
	}
}
