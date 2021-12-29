using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemParent;
	public GameObject inventoryUI;

	Inventory inventory;
	bool isInven = false;

	InventorySlot[] slots;
	private void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
		inventoryUI.SetActive(false);

		slots = itemParent.GetComponentsInChildren<InventorySlot>();
	}
	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			isInven = !isInven;
			if (isInven)
			{
				Time.timeScale = 0f;
				inventoryUI.SetActive(true);
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Time.timeScale = 1f;
				inventoryUI.SetActive(false);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
	}
	void UpdateUI()
	{
		for(int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
