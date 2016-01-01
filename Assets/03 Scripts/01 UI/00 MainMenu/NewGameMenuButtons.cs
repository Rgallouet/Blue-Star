using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour {

	public static Canvas NewGameMenu;
	
	
	void Awake(){
		NewGameMenu = GetComponent<Canvas>();
		NewGameMenu.enabled = false;
	}

	public void BackToGameMenuFromNewGameScreen(){
		MenuGUI.MenuGoBack (0);
	}

	public void NewGame(int mode){
		MenuGUI.MenuGoNext (mode);
	}



}
