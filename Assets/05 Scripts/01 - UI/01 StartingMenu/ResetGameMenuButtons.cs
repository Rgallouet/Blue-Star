using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetGameMenuButtons : MonoBehaviour 
{

	public MenuGUI menuGUI;
	private Canvas ResetGameMenu;

    private ArrayList RefErrors = new();
    private bool havebeenwarned;
    public DataBaseManager dataBaseManager;

    void Start()
    {
        
        ResetGameMenu = GetComponent<Canvas>();
		ResetGameMenu.enabled = false;

    }
	

    public void Next(int mode)
    {


        // Wants to reset account; but not yet warned
        if (mode==1 && !(menuGUI.account.AccountName == " ") && havebeenwarned == false)
        {
            RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' and Trigger='WarningResetAccount'");
            menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4], (string)((ArrayList)RefErrors[1])[5]);
            havebeenwarned = true;
        }
        // Wants to reset account even after being warned
        else if (mode == 1 && !(menuGUI.account.AccountName == " ") && !(havebeenwarned == false))

        {
            // Explaining what will happen
            RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' and Trigger='WarningResetAccountConfirm'");
            menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4], (string)((ArrayList)RefErrors[1])[5]);

            // reset the database
            dataBaseManager.ResetDB();
            Application.Quit();
        }
        else if (mode == 0)
        {
            //Just a restart while keeping saved progress
            menuGUI.MenuGoNext(0);
            ResetGameMenu.enabled = false;
        }


    }

    public void Back(){
        menuGUI.MenuGoBack (0);
        ResetGameMenu.enabled = false;
    }


    public void ActivateMenu() 
    {
        havebeenwarned = false;
        ResetGameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.RESET;

    }




}
