using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas GameMenu;



    void Start(){

		GameMenu = GetComponent<Canvas>();
        GameMenu.enabled = false;

    }


public void StartNewGame()	{
        menuGUI.MenuGoNext (1);
        GameMenu.enabled = false;
    }

    public void LoadGame()		{
        menuGUI.MenuGoNext (2);
        GameMenu.enabled = false;
    }

    public void ResetGame()
    {
        menuGUI.MenuGoNext(3);
        GameMenu.enabled = false;
    }

    public void QuitGame()		
    {
        menuGUI.MenuGoBack (0);
    }

    public void ActivateMenu()
    {
        GameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.MENU;

        // Auto-start if no game save information on first slot
        if (menuGUI.account.AccountName == " ") 
        {
            StartNewGame();
        }

    }

    

}
