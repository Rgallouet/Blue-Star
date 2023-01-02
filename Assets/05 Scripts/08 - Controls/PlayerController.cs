using UnityEngine;
using System.Collections;
using System;

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
    public float tempAmplitude; // movement amplitude
    public float xMovementLeftJoystick; // current speed on x after isometric correction
    public float yMovementLeftJoystick; // current speed on y after isometric correction



    private Rigidbody2D rigidBody; // rigid body component of the player character

    //Childs
    public GameObject lightObject;
    public GameObject characterObject;
    public SpriteDirectionSet spriteDirectionSet;

    // Skin modifications
    public BodyAppearanceSwapper bodyAppearanceSwapperFront;
    public BodyAppearanceSwapper bodyAppearanceSwapperBack;

    // animation
    public Animator animatorFront; // the animator controller of the player character looking bottom
    public Animator animatorBack; // the animator controller of the player character looking top

    // delay action
    public float delay = 0.3f;
    private bool actionBlocked;
    public bool actionRequested = false;


    // Use this for initialization
    void Start () {
        leftJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponentsInChildren<LeftJoystick>()[0];
        rigidBody = gameObject.GetComponentInChildren<Rigidbody2D>();
        spriteDirectionSet = SpriteDirectionSet.BottomRight;
        SwitchingVisibleSpriteTo(animatorFront, animatorBack);

    }



	// Update is called once per frame
	void FixedUpdate () {
        // get input from joystick
        leftJoystickInput = leftJoystick.GetInputDirection();

        // if there is no input on the left joystick
        if (leftJoystickInput == Vector3.zero && animatorFront != null && animatorBack != null)
        {
            animatorFront.SetFloat("MovingSpeed", 0f);
            animatorBack.SetFloat("MovingSpeed", 0f);

            if ( actionRequested == true && actionBlocked==false )
            {
                animatorFront.SetTrigger("Attack");
                animatorBack.SetTrigger("Attack");
                actionBlocked = true;
                actionRequested = false;
                StartCoroutine(DelayAction());

            }


        }

        // if there is only input from the left joystick
        if (leftJoystickInput != Vector3.zero)
        {

            tempAmplitude = leftJoystickInput.magnitude;

            // calculate the player's direction based on angle
            tempAngle = Mathf.Atan2(leftJoystickInput.y, leftJoystickInput.x);
            xMovementLeftJoystick = tempAmplitude * Mathf.Cos(tempAngle+ angleOffsetDueToIsometricView);
            yMovementLeftJoystick = tempAmplitude * Mathf.Sin(tempAngle+ angleOffsetDueToIsometricView);

            // Moving in the direction of the joystick
            leftJoystickInput = new Vector3(xMovementLeftJoystick, yMovementLeftJoystick, 0);
            leftJoystickInput = transform.TransformDirection(leftJoystickInput);
            leftJoystickInput *= moveSpeed;

            // rotate the player to face the direction of input
            if (tempAngle > 0 && tempAngle <= 1.57079 && spriteDirectionSet != SpriteDirectionSet.TopRight) ChangeSpriteDirectionSetTo(SpriteDirectionSet.TopRight);
            else if (tempAngle > 1.57079 && spriteDirectionSet != SpriteDirectionSet.TopLeft) ChangeSpriteDirectionSetTo(SpriteDirectionSet.TopLeft);
            else if (tempAngle < 0 && tempAngle >= -1.57079 && spriteDirectionSet != SpriteDirectionSet.BottomRight) ChangeSpriteDirectionSetTo(SpriteDirectionSet.BottomRight);
            else if (tempAngle < -1.57079 && spriteDirectionSet != SpriteDirectionSet.BottomLeft) ChangeSpriteDirectionSetTo(SpriteDirectionSet.BottomLeft);


            if (animatorFront != null && animatorBack != null)
            {
                animatorFront.SetFloat("MovingSpeed", tempAmplitude);
                animatorBack.SetFloat("MovingSpeed", tempAmplitude);
            }

            // move the player
            rigidBody.transform.Translate(leftJoystickInput * Time.fixedDeltaTime);
        }
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(delay);
        actionBlocked = false;
    }

    public void ChangeSpriteDirectionSetTo(SpriteDirectionSet newDirection) 
    {

        // Switching Front to back if needed
        if ((spriteDirectionSet == SpriteDirectionSet.BottomRight || spriteDirectionSet == SpriteDirectionSet.BottomLeft) && (newDirection == SpriteDirectionSet.TopRight || newDirection == SpriteDirectionSet.TopLeft)) SwitchingVisibleSpriteTo(animatorBack, animatorFront);
        if ((spriteDirectionSet == SpriteDirectionSet.TopRight || spriteDirectionSet == SpriteDirectionSet.TopLeft) && (newDirection == SpriteDirectionSet.BottomRight || newDirection == SpriteDirectionSet.BottomLeft)) SwitchingVisibleSpriteTo(animatorFront, animatorBack);


        // mirroring the character if needed
        if ((spriteDirectionSet == SpriteDirectionSet.BottomRight || spriteDirectionSet == SpriteDirectionSet.TopRight) && (newDirection == SpriteDirectionSet.BottomLeft || newDirection == SpriteDirectionSet.TopLeft)) MirroringSprite();
        if ((spriteDirectionSet == SpriteDirectionSet.BottomLeft || spriteDirectionSet == SpriteDirectionSet.TopLeft) && (newDirection == SpriteDirectionSet.BottomRight || newDirection == SpriteDirectionSet.TopRight)) MirroringSprite();

        // moving the spot light
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

        // Updating the status of the direction
        spriteDirectionSet = newDirection;

    }

    public void SwitchingVisibleSpriteTo(Animator animatorToTurnVisible, Animator animatorToTurnInvisible)
    {

        foreach (Renderer r in animatorToTurnInvisible.GetComponentsInChildren(typeof(Renderer)))
        {
            r.enabled = false;
        }

        foreach (Renderer r in animatorToTurnVisible.GetComponentsInChildren(typeof(Renderer)))
        {
            r.enabled = true;
        }
    }

    public void MirroringSprite()
    {
        characterObject.transform.localScale = new Vector3(-1* characterObject.transform.localScale.x, characterObject.transform.localScale.y, characterObject.transform.localScale.z);
        bodyAppearanceSwapperFront.MirrorSpriteAppearrance();
        bodyAppearanceSwapperBack.MirrorSpriteAppearrance();
    }

}


