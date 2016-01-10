using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour {

	[SerializeField] float jumpPower = 5f;
	[Range(0f, 4f)][SerializeField] float gravityMultiplier = 2f;
	[SerializeField] float groundCheckDistance = 0.1f;
	[SerializeField] float animSpeedMultiplier = 1f;
	[SerializeField] float moveSpeedMultiplier = 10f;

	Rigidbody m_Rigidbody;
	Animator animator;
	public enum BodyStatus{isOnGround,isJumping,isFlying};
	public BodyStatus bodyStatus;
	float origGroundCheckDistance;
	Vector3 groundNormal;


	
	
	void Start()
	{
		bodyStatus = BodyStatus.isOnGround;
		animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();

		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		origGroundCheckDistance = groundCheckDistance;
	}
	
	
	public void MoveBody(Vector3 move, bool jump)
	{
		CheckGroundStatus ();
		move = Vector3.ProjectOnPlane(move, groundNormal);
		// control and velocity handling is different when grounded and airborne:
		if (bodyStatus == BodyStatus.isOnGround && !jump && !(move.magnitude==0)) m_Rigidbody.velocity = new Vector3(move.x * moveSpeedMultiplier, m_Rigidbody.velocity.y,move.z * moveSpeedMultiplier);
		else if	(bodyStatus == BodyStatus.isOnGround && jump) 	StartJumping ();
		else if (bodyStatus == BodyStatus.isJumping && !jump) 	HandleAirborneMovement();
		else if (bodyStatus == BodyStatus.isJumping && jump) 	StartFlying ();
		else if (bodyStatus == BodyStatus.isFlying) 			HandleFlying();
	
		// send input and other state parameters to the animator
		UpdateAnimator(move);
	}
	
	

	
	
	void UpdateAnimator(Vector3 move)
	{
		// update the animator parameters
		animator.SetFloat("Forward", move.z, 0.1f, Time.deltaTime);
		//animator.SetFloat("Right", move.x, 0.1f, Time.deltaTime);
		animator.SetBool("OnGround", bodyStatus==BodyStatus.isOnGround ? true : false); 

		if (bodyStatus==BodyStatus.isOnGround ? false : true) animator.SetFloat("Jump", m_Rigidbody.velocity.y);


	}

	
	
	void StartJumping()
	{
		m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, jumpPower, m_Rigidbody.velocity.z);
		bodyStatus = BodyStatus.isJumping;

		animator.applyRootMotion = false;
		groundCheckDistance = 0.1f;
	}

	void StartFlying()
	{
		m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 10*jumpPower, m_Rigidbody.velocity.z);
		bodyStatus = BodyStatus.isFlying;
	}


	void HandleAirborneMovement()
	{
		// apply extra gravity from multiplier:
		Vector3 extraGravityForce = (Physics.gravity * gravityMultiplier) - Physics.gravity;
		m_Rigidbody.AddForce(extraGravityForce);
		groundCheckDistance = m_Rigidbody.velocity.y < 0 ? origGroundCheckDistance : 0.01f;
	}

	void HandleFlying()
	{
		// A changer plus tard
		HandleAirborneMovement ();

	}

	
	void CheckGroundStatus()
	{
		RaycastHit hitInfo;
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
		{
			groundNormal = hitInfo.normal;
			bodyStatus = BodyStatus.isOnGround;
			animator.applyRootMotion = true;
		}
		else
		{
			groundNormal = Vector3.up;
			animator.applyRootMotion = false;
		}
	}

}
