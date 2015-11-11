using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float rotateSpeed;
	public float forwardSpeed;
	public float run;
	private CharacterController playerController;



	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		// transform.Rotate(0,Input.GetAxis("Horizontal")*rotateSpeed,0);

		Vector3 forward = transform.TransformDirection (Vector3.forward);
		Vector3 right = transform.TransformDirection (Vector3.right);

		if (Input.GetAxis("Run")==1f && playerController.isGrounded){run=1.5f;} else {run=1.0f;}


		float speed_f = forwardSpeed * (Input.GetAxis ("Vertical"));
		float speed_r = forwardSpeed * (Input.GetAxis ("Horizontal"));
	
		//Saut
		if (Input.GetButtonDown("Jump") && playerController.isGrounded){playerController.Move(Vector3.up);}
		//Run




		//Deplacement
			   if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") < 0) {
			playerController.SimpleMove (0.4f * speed_f * forward*run);
			playerController.SimpleMove (0.4f * speed_r * right*run);
		} else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") < 0) {
			playerController.SimpleMove (0.8f * speed_f * forward*run);
			playerController.SimpleMove (0.8f * speed_r * right*run);
		} else if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") > 0) {
			playerController.SimpleMove (0.5f * speed_f * forward*run);
			playerController.SimpleMove (0.5f * speed_r * right*run);
		} else {
			playerController.SimpleMove (speed_f * forward*run);
			playerController.SimpleMove (speed_r * right*run);
		}
		
	
}
}
