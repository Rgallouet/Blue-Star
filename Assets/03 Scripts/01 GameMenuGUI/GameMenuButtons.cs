using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public static Canvas GameMenu;
	
	
	void Awake(){
		GameMenu = GetComponent<Canvas>();
		GameMenu.enabled = true;
	}


	public void StartNewGame()	{MenuGUI.MenuGoNext (1);}
	public void LoadGame()		{MenuGUI.MenuGoNext (2);}
	public void QuitGame()		{MenuGUI.MenuGoBack (0);}


}
