using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas GameMenu;

    private string description;

    void Start(){

		GameMenu = GetComponent<Canvas>();
        
}


public void StartNewGame()	{
        menuGUI.MenuGoNext (1);
        GameMenu.enabled = false;
    }

    public void LoadGame()		{
        menuGUI.MenuGoNext (2);
        GameMenu.enabled = false;
    }

    public void QuitGame()		{
        menuGUI.MenuGoBack (0);
    }

    public void ActivateMenu()
    {
        GameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.MENU;
    }

    

}
