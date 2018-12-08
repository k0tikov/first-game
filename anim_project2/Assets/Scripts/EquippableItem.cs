using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equippable Item")]
public class EquippableItem : Item
{
	public int StrengthBonus;
	public int AgilityBonus;
	public int IntelligenceBonus;
	public int VitalityBonus;
	[Space]
	public float StrengthPercentBonus;
	public float AgilityPercentBonus;
	public float IntelligencePercentBonus;
	public float VitalityPercentBonus;
	[Space]
	public EquipmentType EquipmentType;
}
	
public enum EquipmentType
{
	Helmet,
	Chest,
	Gloves,
	Boots,
	Weapon1,
	Weapon2,
	Accessory1,
	Accessory2,
}


