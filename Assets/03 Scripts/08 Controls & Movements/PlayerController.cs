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
		
        // Simulating a circle area for direction vector possible values
		if (!(goFront == 0) && !(goRight == 0)) {
			goFront*=1/Mathf.Sqrt(2);
			goRight*=1/Mathf.Sqrt(2);
		}


        //Get movement directions on the ground
        groundMove = (goFront * transform.TransformDirection(Vector3.forward)) + (goRight * transform.TransformDirection(Vector3.right));
        //Get movement directions in free mode
        freeMove = (goFront * playercamera.transform.TransformDirection(Vector3.forward)) + (goRight * playercamera.transform.TransformDirection(Vector3.right));

        // 	Walk 
        if (Input.GetAxis("Walk") == 1f) { goFront *= walkMultiplier; goRight *= walkMultiplier; groundMove *= walkMultiplier; freeMove *= walkMultiplier; }
        //	Run
        if (Input.GetAxis("Run") == 1f) { goFront *= runMultiplier; goRight *= runMultiplier;  groundMove *= runMultiplier; freeMove *= runMultiplier; }

        //Jump or Flying
        if 	(Input.GetButtonDown ("Jump")) 	playerBody.MoveBody(goFront, goRight, groundMove, freeMove,true);
		else playerBody.MoveBody(goFront, goRight, groundMove, freeMove,false);

	}


}


