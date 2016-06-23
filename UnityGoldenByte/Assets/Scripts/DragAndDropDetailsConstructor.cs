using UnityEngine;
using System.Collections;

public class DragAndDropDetailsConstructor : MonoBehaviour {

	Color mouseOverColor = Color.green;
	Color originalColor;
	void Start()
	{
		originalColor = GetComponents<Renderer>()[0].material.color;
	}
	void OnMouseEnter()
	{
		GetComponents<Renderer>()[0].material.color = mouseOverColor;
	}

	void OnMouseExit()
	{
		GetComponents<Renderer>()[0].material.color = originalColor;
	}

	void OnMouseDown()
	{
		var screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		var offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
		if(Input.GetMouseButton(1))
		{
			var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			transform.position = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			//transform.position = curPosition;
		}
	}
}
