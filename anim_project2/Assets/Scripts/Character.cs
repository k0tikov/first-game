using UnityEngine;


public class Character : MonoBehaviour 
{

	public CharacterStat Strength;
	public CharacterStat Agility;
	public CharacterStat Intelligence;
	public CharacterStat Vitality;
	
	
	private Character inventoryManager;
	public Inventory inventory;
	public EquipmentPanel equipmentPanel;
	public StatPanel statPanel;
	public GameObject closeHUD;
	
	void Awake ()
	{
		statPanel.SetStats(Strength, Agility, Intelligence, Vitality);
		statPanel.UpdateStatValues();
		
		inventory.OnItemRightClickedEvent += EquipFromInventory;
		equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
	}
	

	void Update ()
	{
		
		if (Input.GetButtonDown("HUD"))
		{ 
			closeHUD.SetActive(!closeHUD.activeSelf);
		}
	}
	
	
	private void EquipFromInventory(Item item)
	{
		Debug.Log("i pressed it");
		if (item is EquippableItem)
		{
			Equip((EquippableItem)item);
			Debug.Log("this shit is working");
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
		{
			EquippableItem previousItem;
			if (equipmentPanel.AddItem(item, out previousItem))
			{
				if (previousItem != null)
				{
					inventory.AddItem(previousItem);
					previousItem.Unequip(this);
					statPanel.UpdateStatValues();
				}
				item.Equip(this);
				statPanel.UpdateStatValues();
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
			item.Unequip(this);
			statPanel.UpdateStatValues();
			inventory.AddItem(item);
		}
	}

}
