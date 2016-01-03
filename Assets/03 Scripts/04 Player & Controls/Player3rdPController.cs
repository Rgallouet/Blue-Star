using UnityEngine;
using System.Collections;

public class Player3rdPController : MonoBehaviour {

	private Player3rdPBody m_Character; 		// A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  	// A reference to the main camera in the scenes transform
	private Vector3 m_Move;
	private bool m_Jump;                      	// the world-relative desired move direction, calculated from the camForward and user input.
	
	
	private void Start()
	{
		// get the transform of the main camera
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}
		
		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<Player3rdPBody>();
	}
	
	
	private void Update()
	{
		if (!m_Jump)
		{
			m_Jump = Input.GetButtonDown("Jump");
		}
	}
	
	
	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		// read inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.C);

		// calculate camera relative direction to move:
		m_Move = v*m_Cam.forward + h*m_Cam.right;


		
		// pass all parameters to the character control script
		m_Character.Move(m_Move, crouch, m_Jump);
		m_Jump = false;
	}
}
