using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas GameMenu;

    private string description;



    void Start(){

		GameMenu = GetComponent<Canvas>();
        ActivateMenu();

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

        // Auto-start if no game save information on first slot
        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[1])[1])== 0) 
        {
            StartNewGame();
        }

    }

    

}
