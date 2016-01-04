using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour {

	public GameObject menuGUIHolder;
	public static Canvas NewGameMenu;
	
	
	void Awake(){
		NewGameMenu = GetComponent<Canvas>();
		NewGameMenu.enabled = false;
	}

	public void BackToGameMenuFromNewGameScreen(){
		menuGUIHolder.GetComponent<MenuGUI>().MenuGoBack (0);
	}

	public void NewGame(int mode){
		menuGUIHolder.GetComponent<MenuGUI>().MenuGoNext (mode);
	}



}
