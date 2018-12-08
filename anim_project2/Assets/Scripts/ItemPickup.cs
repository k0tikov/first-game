using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;	//объект айтем


	public override void Interact(){
		base.Interact();
		PickUp();
	}



		//поднимаем объект
	void PickUp(){

		Debug.Log("Picking up " + item.name);
		
		//FindObjectOfType<Inventory>().Add(item);
		//add to inventory
				//вызов функции ADD из класса инвентарь при клике на объект
		bool wasPickedUp = Inventory.instance.AddItem(item);
				//если удачный метод поднятия (мы смогли добавить объект в инвентарь, то удаляем этот объект со сцены
		if (wasPickedUp)
			Destroy(gameObject);
	}
}
