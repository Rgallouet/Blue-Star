#pragma strict



var canJump = true;
var jumpHeight = 2.0;
var jumpinterval : float = 1.5;
private var nextjump : float = 1.2;

public var speed : float = 4;
var runspeed : float = 8;
private var moveAmount : float;
var smoothSpeed : float = 2;
private var sensitivityX : float = 6;


public var gravity : float = 25;
public var rotateSpeed : float = 8.0;
public var dampTime : float = 3;


private var horizontalSpeed : float;

var grounded : boolean;
var myaudiosource : AudioSource;

private var nextstep : float;
var target : Transform;
var chest : Transform;



private var running : boolean = false;



private var forward : Vector3 = Vector3.forward;
private var moveDirection : Vector3 = Vector3.zero;
private var right : Vector3;
private var canrun : boolean = true;
private var canjump : boolean = false;
private var isjumping : boolean = false;


var shield : Transform;
var weapon : Transform;
var lefthandpos : Transform;
var righthandpos : Transform;
var chestposshield : Transform;
var chestposweapon : Transform;
var equip1sound : AudioClip;
var wooshsounds : AudioClip[];

var holster1sound : AudioClip;

private var fightmodus : boolean = false;
private var didselect : boolean;
private var canattack : boolean = false;

var mycamera : Transform;
private var reference : Transform;


function Start()
{
     
     reference = new GameObject().transform; 
}
function Update()
{
 	 reference.eulerAngles = new Vector3(0, mycamera.eulerAngles.y, 0);
	 forward = reference.forward;
	 right = new Vector3(forward.z, 0, -forward.x);
	

	

	 var controller = GetComponent.<CharacterController>();
 	 var animator = GetComponent(Animator);
 	 
	 var hor = Input.GetAxis("Horizontal");
	 var ver = Input.GetAxis("Vertical");
	 var targetDirection : Vector3 = (hor * right) + (ver * forward);
	
	 
	 var velocity = controller.velocity;
	 var z = velocity.z;
	 var x = velocity.x;
	 var horizontalvelocity = new Vector3(x,0,z);
	 var horizontalspeed = horizontalvelocity.magnitude;
	 var localmagnitude = transform.InverseTransformDirection(horizontalvelocity);
	 if (fightmodus)
	 {
		
		
		var localTarget = transform.InverseTransformPoint(target.position);
		var addfloat = (Mathf.Atan2(localTarget.x, localTarget.z));
		
		canrun = false;
		
		var relativePos = target.transform.position - transform.position;
 	 	var lookrotation = Quaternion.LookRotation(relativePos,Vector3.up);
 	 	lookrotation.x = 0;
 	 	lookrotation.z = 0;
 	 	animator.SetFloat("hor",(localmagnitude.x) + (addfloat * 2), dampTime , 0.8);
	 	animator.SetFloat("ver",(localmagnitude.z), dampTime , 0.8);
	 	transform.rotation = Quaternion.Lerp(transform.rotation,lookrotation,Time.deltaTime * rotateSpeed);
	 	
	 	
	 }
	 else
	 {
		
		canrun = true;
		
		if (targetDirection != Vector3.zero)
		{
			var lookrotation2 = Quaternion.LookRotation(targetDirection,Vector3.up);
			lookrotation2.x = 0;
 	 		lookrotation2.z = 0;
			transform.rotation = Quaternion.Lerp(transform.rotation,lookrotation2,Time.deltaTime * rotateSpeed);
		}
	 }
	 var targetVelocity = targetDirection;
	 if (Input.GetButton("Fire2") && canrun && !isjumping)
	{
			
		targetVelocity *= runspeed;
			
	} 
	else 
	{
		targetVelocity *= speed;
	}
	var swordscript: sword =  weapon.GetComponent(sword); 
	
	
	if (canattack)
	{
		var attackState = animator.GetCurrentAnimatorStateInfo(0).IsName("attacks");
		swordscript.canattack = attackState;
		if (Input.GetButtonDown("Fire1"))
		{
			
			
			
   			
   			if (!attackState)
   			{
   			    
   			    
   			    myaudiosource.clip = wooshsounds[Random.Range(0,wooshsounds.Length)];
   			    myaudiosource.pitch = 0.98f + 0.1f *Random.value;
   			    myaudiosource.Play();
   			   
   			    animator.SetBool("attack",true);
   			  
   				        
   			}
   			

   			
		}
		else
		{
			animator.SetBool("attack",false);
			
		}
	}
	
	if (controller.isGrounded) 
    {
    	
		
		
		
		
		
		
		
		
		
	   
		animator.SetFloat("speed",horizontalspeed,dampTime, 0.2);
		if (Input.GetButton ("Jump") && Time.time > nextjump) 
		{
					nextjump = Time.time + jumpinterval;
					moveDirection.y = jumpHeight;
					animator.SetBool ("Jump", true);
					isjumping = true;
		} 
		else 
		{
					animator.SetBool ("Jump", false);
					isjumping = false;
				
		}  
		
	}		
	else 
	{
			moveDirection.y -= gravity * Time.deltaTime;
			nextjump = Time.time + jumpinterval;
	}
			
		
		


		moveDirection.z = targetVelocity.z;
		moveDirection.x = targetVelocity.x;
		controller.Move (moveDirection * Time.deltaTime);   
	
 
	 if (Input.GetButtonDown("Fire3"))
	 {
	 	 weaponselect();	
	 }
      
	 animator.SetBool("grounded",controller.isGrounded);	 
   
 }
 
function equip()
{
	weapon.parent = righthandpos;
	weapon.position = righthandpos.position;
	weapon.rotation = righthandpos.rotation;
	myaudiosource.clip = equip1sound;
	myaudiosource.loop = false;
	myaudiosource.pitch = 0.9 + 0.2*Random.value;
	myaudiosource.Play();
	shield.parent = lefthandpos;
	shield.position = lefthandpos.position;
	shield.rotation = lefthandpos.rotation;
	fightmodus = true;
	
	
}
function holster()
{
	shield.parent = chestposshield;
	shield.position = chestposshield.position;
	shield.rotation = chestposshield.rotation;
	myaudiosource.clip = holster1sound;
	myaudiosource.loop = false;
	myaudiosource.pitch = 0.9 + 0.2*Random.value;
	myaudiosource.Play();
	fightmodus = false;
	weapon.parent = chestposweapon;
	weapon.position = chestposweapon.position;
	weapon.rotation = chestposweapon.rotation;
	
	
}
function OnAnimatorIK()
{
	 var animator = GetComponent(Animator);
		if (canattack)
		{
			animator.SetLookAtPosition(target.position);
			animator.SetLookAtWeight(0.9,0.2,1,1,1);
		}
	
}
function weaponselect()
{	
	
	var animator = GetComponent(Animator);
	
	if (didselect)
	{
		
		animator.CrossFade("Holster",0.15,0,0);
		canattack = false;
		didselect = false;
		yield WaitForSeconds(1);
	}
	else
	{
		
		animator.CrossFade("Equip",0.15,0,0);
		canattack = true;
		didselect = true;
		yield WaitForSeconds(1);
	}
	
	
	
}

