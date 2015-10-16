using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public static Canvas GameMenu;
	
	
	void Awake(){
		GameMenu = GetComponent<Canvas>();
		GameMenu.enabled = true;
	}


	public void StartNewGame()	{MenuGUI.currentState = MenuGUI.CreateAPlayerStates.CLASSSELECTION;}
	public void LoadGame()		{MenuGUI.currentState = MenuGUI.CreateAPlayerStates.LOAD;}
	public void QuitGame()		{Application.Quit();}

}
