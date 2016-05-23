#pragma strict
var impactPrefab : Transform;
var mask : LayerMask;
var damage : float = 25;
var canattack : boolean = false;

function Start () {

}

function Update () {

}

function OnCollisionEnter(collision : Collision) 
{
	
		if (canattack)
		{
		
			

			for (var contact: ContactPoint in collision.contacts)
			{
				var impact = Instantiate(impactPrefab, contact.point, Quaternion.FromToRotation(Vector3.up,contact.normal));
				collision.gameObject.SendMessage ("Damage", damage,SendMessageOptions.DontRequireReceiver);
			}
			
		}
}
	
      		