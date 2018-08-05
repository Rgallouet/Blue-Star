using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameNameMenuButtons : MonoBehaviour {


    public DataBaseManager dataBaseManager;
    private Canvas SaveNameCanvas;
    public MenuGUI menuGUI;

    private Button ButtonNext;
    private Button ButtonBack;


    public string Name;



    // Use this for initialization
    void Start () {


        SaveNameCanvas = GetComponent<Canvas>();
        ButtonNext = SaveNameCanvas.GetComponentsInChildren<Button>()[0];
        ButtonBack = SaveNameCanvas.GetComponentsInChildren<Button>()[1];

        SaveNameCanvas.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {

        Name = SaveNameCanvas.GetComponentsInChildren<Text>()[3].text;

        if (!(Name == "")) {
            ButtonNext.interactable = true;
            ButtonNext.GetComponentsInChildren<Text>()[0].enabled = true;
            ButtonBack.interactable = true;
            ButtonBack.GetComponentsInChildren<Text>()[0].enabled = true;

        }
        else {
            ButtonNext.interactable = false;
            ButtonNext.GetComponentsInChildren<Text>()[0].enabled = false;
            ButtonBack.interactable = false;
            ButtonBack.GetComponentsInChildren<Text>()[0].enabled = false;

            //ButtonNext.interactable = false;
        }



    }



    public void Next()
    {
        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[menuGUI.Slot])[2]) == 0)
        { menuGUI.PlayerLastName = Name; }
        else { menuGUI.PlayerFirstName = Name; }

        menuGUI.MenuGoNext(0);
        SaveNameCanvas.enabled = false;
    }

    public void Back()
    {

        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[1])[2]) == 0)
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


        // The start versus the legacy
        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[menuGUI.Slot])[2]) == 0) {

            SaveNameCanvas.GetComponentsInChildren<Text>()[0].text = "Start";
            SaveNameCanvas.GetComponentsInChildren<Text>()[1].text = "Quit";
            SaveNameCanvas.GetComponentsInChildren<Text>()[2].text = "The family name of your demon ancestors";

        }
        else {
            SaveNameCanvas.GetComponentsInChildren<Text>()[0].text = "Next";
            SaveNameCanvas.GetComponentsInChildren<Text>()[1].text = "Back";
            SaveNameCanvas.GetComponentsInChildren<Text>()[2].text = "Your first name";
        }
        
        
    }



}
