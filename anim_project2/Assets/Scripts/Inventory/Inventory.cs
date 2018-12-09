using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	#region Singleton
	public static Inventory instance;
	void Awake ()
	{
		
		if (instance != null)
		{
			Debug.LogWarning("More than one instance");
			return;
		}
		instance = this;
		
		for (int i = 0; i < itemSlots.Length; i++)
		{
			itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
		}
	}
	#endregion
	
	[SerializeField] List <Item> items;
	[SerializeField] Transform itemsParent;
	[SerializeField] ItemSlot[] itemSlots;
	
	public event Action<Item> OnItemRightClickedEvent;
	
	public Inventory inventory;
	
	private void  OnValidate ()
	{
		inventory = Inventory.instance;
		//inventory.onItemChangedCallback += RefreshUI;
		if (itemsParent != null)
			itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
		
		RefreshUI();
	}

	
	public bool ItemPickUp (Item item)
	{
		if (IsFull())
		{
			return false;
		}
		
		items.Add(item);
		// (onItemChangedCallback != null)
			//ItemChangedCallback.Invoke();
		RefreshUI ();
		return true;
	}

	public bool AddItem (Item item)
	{
		if (IsFull())
		{
			return false;
		}
		
		items.Add(item);
		RefreshUI ();
		return true;
	}
	
	public bool RemoveItem (Item item)
	{
		if (items.Remove(item))
		{
			Debug.Log("REMOVING");
			// (onItemChangedCallback != null)
			//ItemChangedCallback.Invoke();
			RefreshUI ();
			return true;
		}
		//Debug.LogWarning("ITS WORKING");
		return false;
	}
	
	public bool IsFull ()
	{
		return items.Count >= itemSlots.Length;
	}
	
	private void RefreshUI ()
	{
		
		int i = 0;
		for (; i < items.Count && i < itemSlots.Length; i++)
		{
			itemSlots[i].Item = items[i];

		}
		
		for (; i < itemSlots.Length; i++)
		{
			itemSlots[i].Item = null;
		}
		
	}
}
