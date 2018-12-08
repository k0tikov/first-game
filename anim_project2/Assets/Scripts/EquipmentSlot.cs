
public class EquipmentSlot : ItemSlot
{
	public EquipmentType EquipmentType;
	
	
	
	void Start ()
	{
		gameObject.name = EquipmentType.ToString() + " Slot";
	}
	/*protected override OnValidate ()
	{
		base.OnValidate();
		gameObject.name = EquipmentType.ToString() + " Slot";
		
	}*/

}
