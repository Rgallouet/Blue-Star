using UnityEngine;
using System.Collections;


public enum SpriteDirectionSet
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}

public class PlayerController : MonoBehaviour {

    // Checking for movement request
    public LeftJoystick leftJoystick; // the game object containing the LeftJoystick script
    private Vector3 leftJoystickInput; // holds the input of the Left Joystick
    
    // movement characteristics
    public float moveSpeed; // movement speed of the player character
    public float angleOffsetDueToIsometricView; // offset for isometric view - to be moved to private readonly after debugging

    // movement tracker
    public float tempAngle; // facing direction
    public float xMovementLeftJoystick; // current speed on x after isometric correction
    public float yMovementLeftJoystick; // current speed on y after isometric correction

    // animation
    private Animator animator; // the animator controller of the player character
    private Rigidbody2D rigidBody; // rigid body component of the player character

    //Childs
    public GameObject lightObject;
    public GameObject characterObject;
    public SpriteDirectionSet spriteDirectionSet;

    // Skin modifications
    public BodyAppearanceSwapper bodyAppearanceSwapper;


    // Use this for initialization
    void Start () {
        leftJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponentsInChildren<LeftJoystick>()[0];
        rigidBody = gameObject.GetComponentInChildren<Rigidbody2D>();
        animator= gameObject.GetComponentsInChildren<Animator>()[0];
        spriteDirectionSet = SpriteDirectionSet.BottomRight;
    }



	// Update is called once per frame
	void FixedUpdate () {
        // get input from joystick
        leftJoystickInput = leftJoystick.GetInputDirection();

        // if there is no input on the left joystick
        if (leftJoystickInput == Vector3.zero && animator != null)
        {
            animator.SetFloat("MovingSpeed", 0f);
        }

        // if there is only input from the left joystick
        if (leftJoystickInput != Vector3.zero)
        {
            // calculate the player's direction based on angle
            tempAngle = Mathf.Atan2(leftJoystickInput.y, leftJoystickInput.x);
            xMovementLeftJoystick = leftJoystickInput.magnitude* Mathf.Cos(tempAngle+ angleOffsetDueToIsometricView);
            yMovementLeftJoystick = leftJoystickInput.magnitude* Mathf.Sin(tempAngle+ angleOffsetDueToIsometricView);

            // Moving in the direction of the joystick
            leftJoystickInput = new Vector3(xMovementLeftJoystick, yMovementLeftJoystick, 0);
            leftJoystickInput = transform.TransformDirection(leftJoystickInput);
            leftJoystickInput *= moveSpeed;

            // rotate the player to face the direction of input
            if (tempAngle > 0 && tempAngle <= 1.57079 && spriteDirectionSet != SpriteDirectionSet.TopRight)
            {
                if (spriteDirectionSet != SpriteDirectionSet.BottomRight) bodyAppearanceSwapper.MirrorSpriteAppearrance();
                characterObject.transform.localScale = new Vector3(1, 1, 1);
                ChangeSpriteDirectionSetTo(SpriteDirectionSet.TopRight);

            }
            else if (tempAngle > 1.57079 && spriteDirectionSet != SpriteDirectionSet.TopLeft)
            {
                if (spriteDirectionSet != SpriteDirectionSet.BottomLeft) bodyAppearanceSwapper.MirrorSpriteAppearrance();
                characterObject.transform.localScale = new Vector3(-1, 1, 1);
                ChangeSpriteDirectionSetTo(SpriteDirectionSet.TopLeft);
            }
            else if (tempAngle < 0 && tempAngle >= -1.57079 && spriteDirectionSet != SpriteDirectionSet.BottomRight)
            {
                if (spriteDirectionSet != SpriteDirectionSet.TopRight) bodyAppearanceSwapper.MirrorSpriteAppearrance();
                characterObject.transform.localScale = new Vector3(1, 1, 1);
                ChangeSpriteDirectionSetTo(spriteDirectionSet = SpriteDirectionSet.BottomRight);
            }
            else if (tempAngle < -1.57079 && spriteDirectionSet != SpriteDirectionSet.BottomLeft)
                
            {
                if (spriteDirectionSet != SpriteDirectionSet.TopLeft) bodyAppearanceSwapper.MirrorSpriteAppearrance();
                characterObject.transform.localScale = new Vector3(-1, 1, 1);
                ChangeSpriteDirectionSetTo(SpriteDirectionSet.BottomLeft);
            }


            if (animator != null)
            {
                animator.SetFloat("MovingSpeed", leftJoystickInput.magnitude);
            }

            // move the player
            rigidBody.transform.Translate(leftJoystickInput * Time.fixedDeltaTime);
        }
    }


    public void ChangeSpriteDirectionSetTo(SpriteDirectionSet newDirection) 
    {
        spriteDirectionSet = newDirection;
        if (lightObject != null)
        {
            switch (newDirection) 
            {
                case SpriteDirectionSet.TopLeft: 
                    lightObject.transform.rotation = new Quaternion(0, 0, 0.235f, 0.972f);
                    lightObject.transform.localPosition = new Vector3(0.2f, -0.1f, 0);
                    break;

                case SpriteDirectionSet.TopRight: 
                    lightObject.transform.rotation = new Quaternion(0, 0, 0.235f, -0.972f);
                    lightObject.transform.localPosition = new Vector3(-0.2f, -0.1f, 0);
                    break;

                case SpriteDirectionSet.BottomRight: 
                    lightObject.transform.rotation = new Quaternion(0, 0, 0.972f,-0.235f);
                    lightObject.transform.localPosition = new Vector3(-0.2f, 0.3f, 0);
                    break;

                case SpriteDirectionSet.BottomLeft: 
                    lightObject.transform.rotation = new Quaternion(0, 0, 0.972f, 0.235f);
                    lightObject.transform.localPosition = new Vector3(0.2f, 0.3f, 0);
                    break;

            }
        }
    }
}


