using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Camera playercamera;
	public PlayerBody playerBody;
	public float runMultiplier;
	public float walkMultiplier;
	public float backwardMultiplier;

	public Vector3 groundMove;
	public Vector3 freeMove;

	public float goFront;
	public float goRight;



	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {

		goFront = Mathf.Clamp (Input.GetAxis ("Vertical"), -0.5f, 1f);
		goRight = Input.GetAxis ("Horizontal");
		
		if (!(goFront == 0) && !(goRight == 0)) {
			goFront*=1/Mathf.Sqrt(2);
			goRight*=1/Mathf.Sqrt(2);
		}

		//Direction
		GetGroundMoveVector ();
		GetFreeMoveVector ();

		//Jump or Flying
		if 	(Input.GetButtonDown ("Jump")) 	playerBody.MoveBody(groundMove,freeMove,true);
		else playerBody.MoveBody(groundMove,freeMove,false);

	}



	void GetGroundMoveVector (){

		//Get movement directions
		groundMove = (goFront*transform.TransformDirection (Vector3.forward))+(goRight*transform.TransformDirection (Vector3.right));


		// 	Walk 
		if (Input.GetAxis("Walk")==1f) 	groundMove *= walkMultiplier;
		//	Run
		if (Input.GetAxis("Run")==1f)	groundMove *=runMultiplier;


		}

	void GetFreeMoveVector (){
		
		//Get movement directions
		freeMove = (goFront*playercamera.transform.TransformDirection (Vector3.forward))+(goRight*playercamera.transform.TransformDirection (Vector3.right));

		
		// 	Walk 
		if (Input.GetAxis("Walk")==1f) 	freeMove *= walkMultiplier;
		//	Run
		if (Input.GetAxis("Run")==1f)	freeMove *=runMultiplier;

		
	}

}


