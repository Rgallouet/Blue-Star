using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {





	public Transform cameraTarget; //put the Player

	private float x;
	private float y;

	private int mouseXSpeed =5;
	private int mouseYSpeed =5;

	public float maxViewDistance =25;
	public float minViewDistance =0;

	public int zoomRate =30;
	public int lerpRate=7;

	public float heightChar=1f;

	private float distance=3;
	private float desiredDistance;
	private float correctedDistance;
	private float currentDistance;




	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;

		currentDistance = distance;
		desiredDistance = distance;
		correctedDistance = distance;

	}
	
	// Update is called once per frame
	void LateUpdate () {










		//ScrollWheel
		desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance);
		desiredDistance = Mathf.Clamp (desiredDistance, minViewDistance, maxViewDistance);
		correctedDistance = desiredDistance;

		//Looking Around with Camera only
		if (Input.GetMouseButton (0)) 
			{	float x_previous=x;
				float y_previous=y;
				x += Input.GetAxis ("Mouse X") * mouseXSpeed;
				y -= Input.GetAxis ("Mouse Y") * mouseYSpeed;	} 

		//Looking Around with Character
		else if (Input.GetMouseButton (1)) 
			{	x += Input.GetAxis ("Mouse X") * mouseXSpeed;
				y -= Input.GetAxis ("Mouse Y") * mouseYSpeed;
				Quaternion rotation_target = Quaternion.Euler (0,transform.eulerAngles.y,0);
				cameraTarget.rotation=rotation_target;			}

		//When not looking around and moving, get the camera back to the player's forward direction
		else if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) 
			{	x=Mathf.LerpAngle(transform.eulerAngles.y,cameraTarget.eulerAngles.y,lerpRate*Time.deltaTime);	} 

		//Blocking y direction angles when too low or high
		y = ClampAngle (y, -50, 90);
		Quaternion rotation = Quaternion.Euler (y, x, 0);

		//Getting position of the center of character (with Heigth)
		Vector3 cameraTargetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y + heightChar, cameraTarget.position.z);
		//Setting the desired position for the camera 
		Vector3 position = cameraTargetPosition - (rotation * Vector3.forward * desiredDistance);

		RaycastHit collisionHit;
		bool DistanceIsCorrected = false;

		// See if collision between Camera and min distance from Character
		if (Physics.Linecast (cameraTargetPosition - (rotation *Vector3.forward*minViewDistance), position, out collisionHit)) {
			Debug.Log ("collision");
			position = collisionHit.point;
			correctedDistance= Vector3.Distance (cameraTargetPosition,position);
			DistanceIsCorrected = true;	
		} 

		currentDistance= (!DistanceIsCorrected || correctedDistance > currentDistance) ? Mathf.Lerp (currentDistance,correctedDistance, Time.deltaTime*zoomRate) : correctedDistance;

		position = cameraTargetPosition - (rotation * Vector3.forward * currentDistance+ new Vector3 (0, -heightChar,0));


		transform.rotation = rotation;
		transform.position= position;

	}

	private static float ClampAngle(float angle, float min, float max) {
		if (angle < -360) { angle+=360; }
		else if (angle >360) {angle-=360;}
		return Mathf.Clamp(angle, min, max);

		}
	}
