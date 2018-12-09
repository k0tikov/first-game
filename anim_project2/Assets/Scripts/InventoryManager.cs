﻿using UnityEngine;

public class InventoryManager : MonoBehaviour 
{
	
	public Inventory inventory;
	public EquipmentPanel equipmentPanel;
	
	
	void Awake ()
	{
		inventory.OnItemRightClickedEvent += EquipFromInventory;
		equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
	}
	
	
	private void EquipFromInventory(Item item)
	{
		if (item is EquippableItem)
		{
			Equip((EquippableItem)item);
		}
	}
	
	private void UnequipFromEquipPanel(Item item)
	{
		if (item is EquippableItem)
		{
			Unequip((EquippableItem)item);
		}
	}
	
	
	public void Equip (EquippableItem item)
	{
		if (inventory.RemoveItem(item))
			Debug.Log("this shit is working");
		{
			EquippableItem previousItem;
			if (equipmentPanel.AddItem(item, out previousItem))
			{
				
				//nventory.AddItem(previousItem);
				if (previousItem != null)
				{
					inventory.AddItem(previousItem);
				}
			}
			else
			{
					inventory.AddItem(item);
			}
		}
	}
	
	public void Unequip(EquippableItem item)
	{
		if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
		{
			inventory.AddItem(item);
		}
	}

}