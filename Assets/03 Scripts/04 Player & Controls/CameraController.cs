using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform cameraTarget;

	private float x=0.0f;
	private float y=0.0f;

	private float mouseXSpeed =5.0f;
	private float mouseYSpeed =5.0f;


	// Use this for initialization
	void Start () {
		cameraTarget = GetComponentInChildren<Transform> ();
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetMouseButton (0)) {
			x+=Input.GetAxis("Mouse X")*mouseXSpeed;
			y-=Input.GetAxis("Mouse Y")*mouseYSpeed;
		}
		y = ClampAngle (y, -50, 90);

		Quaternion rotation = Quaternion.Euler (y, x, 0);
		transform.rotation = rotation;
	}

	private static float ClampAngle(float angle, float min, float max) {
		if (angle < -360) { angle+=360; }
		else if (angle >360) {angle-=360;}
		return Mathf.Clamp(angle, min, max);

		}
	}
