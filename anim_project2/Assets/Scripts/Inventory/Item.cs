using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	//переопределяем все настройки для имени и присваиваем явно наименование
	public Sprite icon;	//иконка пустая Item icon
	//public bool isDefaultItem = false;

	//public int id;
	//public Color color;



}
