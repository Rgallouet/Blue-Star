using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas GameMenu;

    private string description;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();


    void Start(){

		GameMenu = GetComponent<Canvas>();


        //Get the names of the saved game
        Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc");

        /*  Testing save slots
        Debug.Log("Name zero is " + (string)((ArrayList)Names[0])[1]);
        Debug.Log("Name one is " + (string)((ArrayList)Names[1])[1]);
        Debug.Log("Name two is " + (string)((ArrayList)Names[2])[1]);
        Debug.Log("Name three is " + (string)((ArrayList)Names[3])[1]);
        Debug.Log("LastName zero is " + (string)((ArrayList)Names[0])[2]);
        Debug.Log("LastName one is " + (string)((ArrayList)Names[1])[2]);
        Debug.Log("LastName two is " + (string)((ArrayList)Names[2])[2]);
        Debug.Log("LastName three is " + (string)((ArrayList)Names[3])[2]);
        */

        
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
        if ((string)((ArrayList)Names[1])[2] == null) {StartNewGame();}

    }

    

}
