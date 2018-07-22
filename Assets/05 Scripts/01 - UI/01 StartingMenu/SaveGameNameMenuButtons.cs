using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameNameMenuButtons : MonoBehaviour {


    public DataBaseManager dataBaseManager;
    private Canvas SaveNameCanvas;
    public MenuGUI menuGUI;

    private Button TextNext;

    public string PlayerLastName;



    // Use this for initialization
    void Start () {


        SaveNameCanvas = GetComponent<Canvas>();
        TextNext = SaveNameCanvas.GetComponentsInChildren<Button>()[0];

        SaveNameCanvas.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {

        PlayerLastName = SaveNameCanvas.GetComponentsInChildren<Text>()[3].text;

        if (!(PlayerLastName == ""))
        {
            
            TextNext.interactable = true;

            if (menuGUI.isThereAnySavedDataOnTheMachine == false)
            { TextNext.GetComponentsInChildren<Text>()[0].text = "Start"; }
            else
            { TextNext.GetComponentsInChildren<Text>()[0].text = "Next"; }

        }
        else {
            TextNext.interactable = false;
            TextNext.GetComponentsInChildren<Text>()[0].text = "";
        }



        


    }



    public void Next()
    {
        menuGUI.PlayerLastName = PlayerLastName;
        menuGUI.MenuGoNext(0);
        SaveNameCanvas.enabled = false;
    }

    public void Back()
    {

        if (menuGUI.isThereAnySavedDataOnTheMachine == false)
        {
            Application.Quit();
        }
        else
        {
            menuGUI.MenuGoBack(0);
            SaveNameCanvas.enabled = false;
        }
    }



    public void ActivateMenu()
    {
        SaveNameCanvas.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVENAME;

        if (menuGUI.isThereAnySavedDataOnTheMachine == false)
        {
            SaveNameCanvas.GetComponentsInChildren<Text>()[1].text = "";
            SaveNameCanvas.GetComponentsInChildren<Button>()[1].interactable = false;
        }


    }



}
