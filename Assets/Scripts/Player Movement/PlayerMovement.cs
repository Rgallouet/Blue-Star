using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {



	public float moveSpeed = 8.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey("z")) {
			transform.Translate((Vector3.forward)*moveSpeed*Time.deltaTime);
			Debug.Log ("moving vertical");}

		if(Input.GetKey("s")) {
			transform.Translate((Vector3.back)*moveSpeed*0.5f*Time.deltaTime);
			Debug.Log ("moving vertical");}

		if(Input.GetKey("q")) {
			transform.Translate((Vector3.left)*moveSpeed*Time.deltaTime);
			Debug.Log ("moving vertical");}
		
		if(Input.GetKey("d")) {
			transform.Translate((Vector3.right)*moveSpeed*0.5f*Time.deltaTime);
			Debug.Log ("moving vertical");}

		if(Input.GetKey("a")) {
			transform.Rotate((Vector3.up)*moveSpeed*Time.deltaTime);
			Debug.Log ("moving vertical");}
		
		if(Input.GetKey("e")) {
			transform.Rotate((Vector3.down)*moveSpeed*0.5f*Time.deltaTime);
			Debug.Log ("moving vertical");}

	if(Input.GetKeyDown("space")) {Debug.Log ("Pressing space key");}
	if(Input.GetKeyUp("a")) {Debug.Log ("Pressing A key");}
	if(Input.GetKey("d")) {Debug.Log ("Pressing D key");}
	if(Input.GetMouseButton(0)) {Debug.Log ("Left Mouse button");}
	if(Input.GetMouseButton(1)) {Debug.Log ("Right Mouse button");}
	}
}
