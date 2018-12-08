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
		
	}
	#endregion
	
	public Transform equipmentSlotsParent;
	public EquipmentSlot[] equipmentSlots;
	
	EquipmentPanel equipmentPanel;
	
	void Start ()
	{
		
		equipmentPanel = EquipmentPanel.instance;
		//equipmentPanel.onItemChangedCallback += RefreshUI;
		
		equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
	}

}
