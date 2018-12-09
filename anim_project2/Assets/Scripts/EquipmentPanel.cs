using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour 
{

	#region Singleton
	public static EquipmentPanel instance;
	void Awake ()
	{
		
		if (instance != null)
		{
			Debug.LogWarning("More than one instance");
			return;
		}
		instance = this;
		for (int i = 0; i < equipmentSlots.Length; i++)
		{
			equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
		}
	}
	#endregion
	
	public Transform equipmentSlotsParent;
	public EquipmentSlot[] equipmentSlots;
	
	//EquipmentPanel equipmentPanel;
	public event Action<Item> OnItemRightClickedEvent;

	private void OnValidate ()
	{
		//equipmentPanel = EquipmentPanel.instance;
		//equipmentPanel.onItemChangedCallback += RefreshUI;
		equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
	}
	
	public bool AddItem (EquippableItem item, out EquippableItem previousItem)
	{
		//Debug.LogWarning("ITS WORKING");
		for (int i = 0; i < equipmentSlots.Length; i++)
		{
			if (equipmentSlots[i].EquipmentType == item.EquipmentType)
			{
				previousItem = (EquippableItem)equipmentSlots[i].Item;
				equipmentSlots[i].Item = item;
				return true;
			}
		}
		previousItem = null;
		return false;
	}
	public bool RemoveItem (EquippableItem item)
	{
		for (int i = 0; i < equipmentSlots.Length; i++)
		{
			if (equipmentSlots[i].Item == item)
			{
				equipmentSlots[i].Item = null;
				return true;
			}
		}
		return false;
	}
}

