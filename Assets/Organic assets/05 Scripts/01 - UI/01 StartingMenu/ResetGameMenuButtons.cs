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
            RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' and Trigger='WarningResetAccount'");
            menuGUI.dialogue.UpdateDialogue(150, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4]);
            havebeenwarned = true;
        }
        // Wants to reset account even after being warned
        else if (mode == 1 && !(menuGUI.account.AccountName == " ") && !(havebeenwarned == false))

        {


            // reset the database
            bool success= dataBaseManager.ResetDB();

            if (success == true)
            {
                // Explaining what will happen
                RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' and Trigger='WarningResetAccountConfirm'");
                menuGUI.dialogue.UpdateDialogue(150, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4]);
                Application.Quit();
            }
            else
            {

                // Explaining what will happen
                RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' and Trigger='WarningResetAccountFail'");
                menuGUI.dialogue.UpdateDialogue(150, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4]);

            }



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
