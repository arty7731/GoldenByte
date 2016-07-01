using UnityEngine;
using System.Collections;

public class DragAndDropDetailsConstructor : MonoBehaviour {

	Color mouseOverColor = Color.green;
	Color originalColor;
	private Vector3 screenSpace;
	private Vector3 offset;

	void Start()
	{
		//origin color
		originalColor = GetComponents<Renderer>()[0].material.color;
	}
	void OnMouseEnter()
	{
		//change material color
		GetComponents<Renderer>()[0].material.color = mouseOverColor;
		//disable component move camera
		if (Input.GetMouseButton(0)) Camera.main.GetComponent<MouseCamConstructorControles>().enabled = false;
	}

	void OnMouseExit()
	{
		//return origin color
		GetComponents<Renderer>()[0].material.color = originalColor;
		//enabled component move camera
		if (!Input.GetMouseButton(0)) Camera.main.GetComponent<MouseCamConstructorControles>().enabled = true;
	}

	void OnMouseDown()
	{
		screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	}

	void OnMouseDrag()
	{
		Debug.Log(transform.position);
		if (Input.GetMouseButton(0))
		{
			var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Debug.Log("offset " + offset + " if");
			Debug.Log("curScreenSpace " + Camera.main.ScreenToWorldPoint(curScreenSpace) + " if");
			transform.position = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			Debug.Log("transform.position " + transform.position + " if");
		}
	}
}
