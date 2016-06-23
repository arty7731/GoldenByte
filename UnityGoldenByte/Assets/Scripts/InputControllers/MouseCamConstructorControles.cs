using UnityEngine;
using System.Collections;

public class MouseCamConstructorControles : MonoBehaviour
{
	[SerializeField]
	GameObject lookGameObject;
	[SerializeField]
	float distance = 10.0F;
	[SerializeField]
	float sensitivity = 0.5F;

	[SerializeField]
	float sSensitivity = 1F;
	[SerializeField]
	float minDistance = 2F;
	[SerializeField]
	float maxDistance = 20F;

	[SerializeField]
	float yMinLimit = -20F;
	[SerializeField]
	float yMaxLimit = 80F;

	float x = 0.0F;
	float y = 0.0F;

void Start()
	{
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	void LateUpdate()
	{
		distance -= (Input.GetAxis("Mouse ScrollWheel") * sSensitivity * 2);
		if (distance < minDistance) distance = minDistance;
		if (distance > maxDistance) distance = maxDistance;
		var rotation = Quaternion.Euler(y, x, 0);
		var position = rotation * new Vector3(0.0F, 0.0F, -distance) + lookGameObject.transform.position;

		transform.rotation = rotation;
		transform.position = position;

		if (Input.GetMouseButton(0))
		{
			x += Input.GetAxis("Mouse X") * (sensitivity * 10);
			y -= Input.GetAxis("Mouse Y") * (sensitivity * 10);

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
}
