using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public static Canvas GameMenu;
	
	
	void Awake(){
		GameMenu = GetComponent<Canvas>();
		GameMenu.enabled = true;
	}


	public void StartNewGame()	{MenuGUI.MenuGoNext ();}
	public void QuitGame()		{MenuGUI.MenuGoBack ();}
	public void LoadGame()		{MenuGUI.MenuLoad ();}

}
