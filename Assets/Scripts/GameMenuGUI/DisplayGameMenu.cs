using UnityEngine;
using System.Collections;

public class DisplayGameMenu  {

	//public Canvas GameMenu;


	void Awake (){
	//GameMenu= GameObject.Find("GameMenu").GetComponent<Canvas>();
	}


	public void DisplayMenuSelection() {
		//Ouvrir le menu si fermé
		//if (GameMenu.enabled== false) {GameMenu.enabled = !GameMenu.enabled;} 

		//lorsque click "new game"
		if(GameMenuButtons.gameMenuNewGame==true){

			Debug.Log ("Yes!");

		CloseMenuSelection();
		MenuGUI.currentState = MenuGUI.CreateAPlayerStates.CLASSSELECTION;
		}

		//lorsque que click "Quit"
		if(GameMenuButtons.gameMenuQuit==true){
			Application.Quit();
		}



	}

	public void CloseMenuSelection() {
	//GameMenu.enabled = !GameMenu.enabled;
	}



}
