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
		
	}
	#endregion
	
	public Transform itemsParent;
	public ItemSlot[] itemSlots;
	public List <Item> items;
	
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;
	
	Inventory inventory;
	
	
	void Start ()
	{
		
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += RefreshUI;
		
		itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
	}
	//private void OnValidate ()
	//{
		//if (itemsParent != null)
		//itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
		//RefreshUI();
	//}
	

	public bool AddItem (Item item)
	{
		if (IsFull())
			return false;
		
		
		items.Add(item);
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
		
		return true;
	}
	
	public bool RemoveItem (Item item)
	{
		if (items.Remove(item))
		{
			if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
		
			return true;
		}
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
		Debug.LogWarning("ITS WORKING");
	}
}
