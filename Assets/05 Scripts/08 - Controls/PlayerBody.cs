using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour {

	private float jumpPower;
    
	//public GameObject waterlevel;

	public float moveSpeedMultiplier = 5f;
	Rigidbody m_Rigidbody;
	Animator animator;
	public enum BodyStatus{isOnGround,isJumping,isSwimming,isFlying};
	public BodyStatus bodyStatus;
    public bool isUsingGravity;
	public Vector3 groundNormal;


	public float DistanceToGround;
	public Vector3 PlayerVelocity;
	public bool ReadyToFly;

    private float PlayerMass;

	
	void Start()
	{
		ReadyToFly = false;
		bodyStatus = BodyStatus.isOnGround;
		animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        //try { moveSpeedMultiplier = GameInformation.BasePlayer.Balance / 20f; }
        //catch (System.Exception)  {moveSpeedMultiplier = 5f;throw;}

        //PlayerMass = GameInformation.BasePlayer.Momentum / 100f;
        //jumpPower = 5 * (GameInformation.BasePlayer.Balance / GameInformation.BasePlayer.Momentum);
        jumpPower = 5f;
        moveSpeedMultiplier = 5f;
        PlayerMass = 1f;

    }


    public void MoveBody(float goFront, float goRight, Vector3 groundMove,Vector3 freeMove, bool jump)
	{

		CheckGroundStatus ();
		groundMove = Vector3.ProjectOnPlane(groundMove, groundNormal);

        // control and velocity handling is different when grounded and airborne:
        if (bodyStatus == BodyStatus.isOnGround && jump) StartJumping();
        else if (bodyStatus == BodyStatus.isJumping && jump) StartAscending();
        else if (bodyStatus == BodyStatus.isFlying && jump) StartFalling();
        else if (bodyStatus == BodyStatus.isOnGround) StayOnGround(groundMove);
        else if (bodyStatus == BodyStatus.isFlying) m_Rigidbody.velocity = m_Rigidbody.velocity + (freeMove * moveSpeedMultiplier  - m_Rigidbody.velocity * 0.4f )* Time.deltaTime / PlayerMass;
        else if (bodyStatus == BodyStatus.isSwimming) m_Rigidbody.velocity = m_Rigidbody.velocity + (freeMove * moveSpeedMultiplier - m_Rigidbody.velocity )* Time.deltaTime / PlayerMass;

		//Output indicator for debuging
		PlayerVelocity = m_Rigidbody.velocity;
        isUsingGravity = m_Rigidbody.useGravity;


        // send input and other state parameters to the animator
        UpdateAnimator(goFront, goRight);
	}
	
	

	
	
	void UpdateAnimator(float goFront, float goRight)
	{

         // update the animator parameters
        animator.SetFloat("Forward", goFront , 0.1f, Time.deltaTime);
		animator.SetFloat("Rightside", goRight, 0.1f, Time.deltaTime);
        animator.SetInteger("State", bodyStatus==BodyStatus.isOnGround ? 0 : bodyStatus == BodyStatus.isJumping ? 1 : bodyStatus == BodyStatus.isFlying ? 2 : 3 ); 
		if (bodyStatus==BodyStatus.isJumping? true : false) animator.SetFloat("JumpingFalling", m_Rigidbody.velocity.y);


	}

	
	
	void StartJumping()
	{
        if(m_Rigidbody.useGravity == false) m_Rigidbody.useGravity = true;
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, jumpPower, m_Rigidbody.velocity.z);
		bodyStatus = BodyStatus.isJumping;
	}

	void StartAscending()
	{
        if (m_Rigidbody.useGravity == true) m_Rigidbody.useGravity = false;
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 4*jumpPower, m_Rigidbody.velocity.z);
		ReadyToFly = true;
	}

	void StartFalling()
	{
        if (m_Rigidbody.useGravity == false) m_Rigidbody.useGravity = true;
        ReadyToFly = false;
		bodyStatus = BodyStatus.isJumping;
	}

    void StayOnGround(Vector3 groundMove)
    {
        if (m_Rigidbody.useGravity == false) m_Rigidbody.useGravity = true;
        m_Rigidbody.velocity = new Vector3(groundMove.x * moveSpeedMultiplier, m_Rigidbody.velocity.y, groundMove.z * moveSpeedMultiplier);
        if (m_Rigidbody.velocity.magnitude < 0.05)
        {
            m_Rigidbody.useGravity = false;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);//frottements statiques
        }
    }


    void CheckGroundStatus()
	{
		RaycastHit hitInfo;
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character


		Physics.Raycast (transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 15000);
		DistanceToGround = hitInfo.distance - 0.1f;
		groundNormal = hitInfo.normal;

		//if (transform.position.y<waterlevel.transform.position.y) {
			//bodyStatus = BodyStatus.isSwimming;
			//m_Rigidbody.mass = 0f;
			//animator.applyRootMotion = false;

		//} else 
        if (bodyStatus == BodyStatus.isSwimming || (DistanceToGround < 0.1f && (bodyStatus == BodyStatus.isJumping) && m_Rigidbody.velocity.y <0.01f)) {
			bodyStatus = BodyStatus.isOnGround;
			m_Rigidbody.mass = 1f;
			//animator.applyRootMotion = true;
		} else if (DistanceToGround < 10 && bodyStatus == BodyStatus.isFlying) {
			bodyStatus = BodyStatus.isJumping;
		} else if (DistanceToGround > 15 && bodyStatus == BodyStatus.isJumping && ReadyToFly) {
			bodyStatus = BodyStatus.isFlying;
			m_Rigidbody.mass = 0f;
			ReadyToFly=false;
		}
	}

}
