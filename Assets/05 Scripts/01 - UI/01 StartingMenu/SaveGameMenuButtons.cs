using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas SaveGameMenu;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();


    void Start(){
        
        SaveGameMenu = GetComponent<Canvas>();
		SaveGameMenu.enabled = false;

        Names = dataBaseManager.getArrayData("select FirstName, LastName from PlayerStaticChoices");
        for (int i = 1; i< 4; i++) { SaveGameMenu.GetComponentsInChildren<Text>()[i].text = (string)((ArrayList)Names[i])[1]; }

    }
	
	public void Next(int position){

        // Save in place (a ajouter)

        menuGUI.MenuGoNext(0);
        SaveGameMenu.enabled = false;
    }


    public void Back(){
        menuGUI.MenuGoBack (0);
        SaveGameMenu.enabled = false;
    }


    public void ActivateMenu() {
        SaveGameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVE;


    }




}
