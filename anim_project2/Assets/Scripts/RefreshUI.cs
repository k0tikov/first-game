using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshUI : MonoBehaviour {

	Inventory inventory;
	// Use this for initialization
	void Start () {
		
		inventory = Inventory.instance;
		//inventory.onItemChangedCallback += RefreshInventory;
		//itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	/*private void RefreshInventory ()
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
	}*/
}
