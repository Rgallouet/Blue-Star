using UnityEngine;
using System.Collections;

public class DisplayGameMenu  {


	public void DisplayMenuSelection() {

		//lorsque click "new game"
		if(GameMenuButtons.gameMenuNewGame==true){
		MenuGUI.currentState = MenuGUI.CreateAPlayerStates.CLASSSELECTION;
		}

		//lorsque que click "Quit"
		if(GameMenuButtons.gameMenuQuit==true){
			Application.Quit();
		}



	}



}
