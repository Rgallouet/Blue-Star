using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public GameObject menuGUIHolder;
	public static Canvas GameMenu;
	
	
	void Awake(){
		GameMenu = GetComponent<Canvas>();
		GameMenu.enabled = true;
	}


	public void StartNewGame()	{menuGUIHolder.GetComponent<MenuGUI>().MenuGoNext (1);}
	public void LoadGame()		{menuGUIHolder.GetComponent<MenuGUI>().MenuGoNext (2);}
	public void QuitGame()		{menuGUIHolder.GetComponent<MenuGUI>().MenuGoBack (0);}


}
