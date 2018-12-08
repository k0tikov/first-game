using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {
	
	public void OnDrag(PointerEventData eventData)
	{	
		//перетаскиваем иконку(объект, на чем скрипт) с курсором
		transform.position = Input.mousePosition;
	}
	
	
	public void OnEndDrag(PointerEventData eventData)
	{
		//возвращаем на место, при отпуске
		transform.localPosition = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
