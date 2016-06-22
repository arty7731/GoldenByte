using UnityEngine;
using System.Collections;

public class MouseCamConstructorControles : MonoBehaviour {


	public GameObject TrackedGameObject;
	public float sensitivity = 0.5F;
	private Camera LookCamera;
	private Vector3 MousePosStart;
	private float MyAngle = 0F;

	// Use this for initialization
	void Start ()
	{
		LookCamera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MousePosStart = Input.mousePosition;
	}

	void FixedUpdate()
	{
		if (Input.GetMouseButton(0) && MousePosStart != Input.mousePosition)
		{
			MyAngle = 0;

			MyAngle = sensitivity * (Input.mousePosition.x - MousePosStart.x);
			var rotationCamera = LookCamera.transform.rotation;
			LookCamera.transform.RotateAround(TrackedGameObject.transform.position, LookCamera.transform.up, MyAngle);
			
			MyAngle = sensitivity * (Input.mousePosition.y - MousePosStart.y);
			LookCamera.transform.RotateAround(TrackedGameObject.transform.position, LookCamera.transform.right, -MyAngle);

			//var rotationCam = LookCamera.transform.rotation;
			//if (rotationCam.x > 90)
			//{
			//	LookCamera.transform.rotation = Quaternion.Euler(90, LookCamera.transform.rotation.y, LookCamera.transform.rotation.z);
			//}
			//else if (rotationCam.x < 0)
			//{
			//	LookCamera.transform.rotation = Quaternion.Euler(0, LookCamera.transform.rotation.y, LookCamera.transform.rotation.z);

			//}
		}

		var scrollMove = Input.GetAxis("Mouse ScrollWheel");
		if (scrollMove != 0)
		{
			LookCamera.transform.position = new Vector3(LookCamera.transform.position.x, LookCamera.transform.position.y, LookCamera.transform.position.z + scrollMove * 10);
		}
		
	}
}
