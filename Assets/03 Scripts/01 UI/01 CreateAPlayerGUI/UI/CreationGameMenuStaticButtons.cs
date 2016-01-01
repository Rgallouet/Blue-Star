using UnityEngine;
using System.Collections;

public class CreationGameMenuStaticButtons : MonoBehaviour {

	public static Canvas CreationGameMenuStatic;
	public Transform player;

	private bool WasPredefinedPath;

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

	
	public void CreationMenuGoNext(){
		if 		(MenuGUI.currentState == MenuGUI.CreateAPlayerStates.PREDEFINEDSELECTION) 	{MenuGUI.MenuGoNext (1);	WasPredefinedPath=true;} 
		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.HISTORYSELECTION) 		{MenuGUI.MenuGoNext (2); 	WasPredefinedPath=false;} 
		else 	{MenuGUI.MenuGoNext (0);}
	}


	public void CreationMenuGoBack(){
		if 		(MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION && WasPredefinedPath==true ) {MenuGUI.MenuGoBack (1);} 
		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION && WasPredefinedPath==false ) {MenuGUI.MenuGoBack (2);} 
		else 	{MenuGUI.MenuGoBack (0);}
	}


	public void CreationMenuTurnLeft(){Left = true;}
	public void CreationMenuTurnRight(){Right = true;}
	public void CreationMenuStopTurnLeft(){Left = false;}
	public void CreationMenuStopTurnRight(){Right = false;}

}
