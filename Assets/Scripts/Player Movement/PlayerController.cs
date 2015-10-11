using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float rotateSpeed;
	public float forwardSpeed;
	private CharacterController playerController;



	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetButtonDown("Jump") && playerController.isGrounded){
			playerController.Move(Vector3.up);
			}
		// transform.Rotate(0,Input.GetAxis("Horizontal")*rotateSpeed,0);

		Vector3 forward = transform.TransformDirection (Vector3.forward);
		Vector3 right = transform.TransformDirection (Vector3.right);
		float speed_f = forwardSpeed * (Input.GetAxis ("Vertical"));
		float speed_r = forwardSpeed * (Input.GetAxis ("Horizontal"));
	

			   if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") < 0) {
			playerController.SimpleMove (0.4f * speed_f * forward);
			playerController.SimpleMove (0.4f * speed_r * right);
		} else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") < 0) {
			playerController.SimpleMove (0.8f * speed_f * forward);
			playerController.SimpleMove (0.8f * speed_r * right);
		} else if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") > 0) {
			playerController.SimpleMove (0.5f * speed_f * forward);
			playerController.SimpleMove (0.5f * speed_r * right);
		} else {
			playerController.SimpleMove (speed_f * forward);
			playerController.SimpleMove (speed_r * right);
		}
		
	
}
}
