using UnityEngine;
using System.Collections;

public class CreationGameMenuStaticButtons : MonoBehaviour {

	public static Canvas CreationGameMenuStatic;
	public Transform player;



	public bool Left; 
	public bool Right;
	
	void Awake(){
		CreationGameMenuStatic = GetComponent<Canvas>();
		CreationGameMenuStatic.enabled = false;
	}

	void Update(){
		if (Left == true) {GameObject.FindGameObjectWithTag ("Player").transform.Rotate(Vector3.up);}
		if (Right == true) {GameObject.FindGameObjectWithTag ("Player").transform.Rotate(Vector3.down);}

	}


	public void CreationMenuGoBack(){
		MenuGUI.MenuGoBack ();
	}

	public void CreationMenuGoNext(){
		MenuGUI.MenuGoNext ();
	}

	public void CreationMenuTurnLeft(){Left = true;}
	public void CreationMenuTurnRight(){Right = true;}
	public void CreationMenuStopTurnLeft(){Left = false;}
	public void CreationMenuStopTurnRight(){Right = false;}




}
