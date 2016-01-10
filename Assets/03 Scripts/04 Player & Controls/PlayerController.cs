using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public PlayerBody playerBody;
	public float runMultiplier;
	public float walkMultiplier;
	public float backwardMultiplier;


	private CharacterController playerController;
	private Vector3 move;



	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	}



	// Update is called once per frame
	void Update () {

		//Direction
		GetMoveVector ();

		//Jump or Flying
		if 	(Input.GetButtonDown ("Jump")) 	playerBody.MoveBody(move,true);
		else playerBody.MoveBody(move,false);

	}



	void GetMoveVector (){

		//Get movement directions
		move = (Input.GetAxis ("Vertical")*transform.TransformDirection (Vector3.forward))+(Input.GetAxis ("Horizontal")*transform.TransformDirection (Vector3.right));
		
		// Normalize vector to prevent speed cheat
		if (move.magnitude > 1f) move.Normalize();

		// 	Walk 
		if (Input.GetAxis("Walk")==1f && playerController.isGrounded) 	move *= walkMultiplier;
		//	Run
		if (Input.GetAxis("Run")==1f && playerController.isGrounded	)	move *=runMultiplier;
		// 	Reduce backstepping speed
		if (move.z < 0f												) 	move.z *=backwardMultiplier;

		}

}


