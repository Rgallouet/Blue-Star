using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public LeftJoystick leftJoystick; // the game object containing the LeftJoystick script
    public float moveSpeed = 1.0f; // movement speed of the player character
    private Animator animator; // the animator controller of the player character
    private Vector3 leftJoystickInput; // holds the input of the Left Joystick
    private Rigidbody rigidBody; // rigid body component of the player character

    // Use this for initialization
    void Start () {
        leftJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponentsInChildren<LeftJoystick>()[0];
        rigidBody = gameObject.GetComponentsInChildren<Rigidbody>()[0];
        //animator= gameObject.GetComponentsInChildren<Animator>()[0];
    }



	// Update is called once per frame
	void FixedUpdate () {
        // get input from both joysticks
        leftJoystickInput = leftJoystick.GetInputDirection();

        float xMovementLeftJoystick = leftJoystickInput.y + leftJoystickInput.x; // The horizontal movement from joystick 01, mapped to angle
        float zMovementLeftJoystick = leftJoystickInput.y - leftJoystickInput.x; // The vertical movement from joystick 01, mapped to angle	

        // if there is no input on the left joystick
        if (leftJoystickInput == Vector3.zero && animator != null)
        {
            animator.SetBool("isRunning", false);
        }

        // if there is only input from the left joystick
        if (leftJoystickInput != Vector3.zero)
        {
            // calculate the player's direction based on angle
            float tempAngle = Mathf.Atan2(zMovementLeftJoystick, xMovementLeftJoystick);
            xMovementLeftJoystick *= Mathf.Abs(Mathf.Cos(tempAngle));
            zMovementLeftJoystick *= Mathf.Abs(Mathf.Sin(tempAngle));

            leftJoystickInput = new Vector3(xMovementLeftJoystick, 0, zMovementLeftJoystick);
            leftJoystickInput = transform.TransformDirection(leftJoystickInput);
            leftJoystickInput *= moveSpeed;

            // rotate the player to face the direction of input
            Vector3 temp = transform.position;
            temp.x += xMovementLeftJoystick;
            temp.z += zMovementLeftJoystick;
            Vector3 lookDirection = temp - transform.position;

            if (animator != null)
            {
                animator.SetBool("isRunning", true);
            }

            // move the player
            rigidBody.transform.Translate(leftJoystickInput * Time.fixedDeltaTime);
        }
    }


}


