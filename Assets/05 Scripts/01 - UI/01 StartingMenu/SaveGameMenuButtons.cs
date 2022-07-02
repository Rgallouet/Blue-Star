using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveGameMenuButtons : MonoBehaviour 
{

	public MenuGUI menuGUI;
	private Canvas SaveGameMenu;

    public DataBaseManager dataBaseManager;
    private string playerName;
    private ArrayList RefErrors = new ArrayList();


    void Start(){
        
        SaveGameMenu = GetComponent<Canvas>();
		SaveGameMenu.enabled = false;

        playerName = (string)((ArrayList)dataBaseManager.getArrayData("select Name from PlayerStaticChoices")[1])[0];
        
        if (!(playerName == null)) 
        {
            SaveGameMenu.GetComponentsInChildren<Text>()[1].text = "Delete account " + playerName;

        }


    }
	
	public void Next(int position){

        if (!(playerName == null))
        {
            // reset the database
            dataBaseManager.ResetDB();
            Application.Quit();
        }

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

        if (!(playerName == null))
        {
            RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' and Trigger='WarningResetAccount'");
            menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4], (string)((ArrayList)RefErrors[1])[5]);
        }

    }




}
