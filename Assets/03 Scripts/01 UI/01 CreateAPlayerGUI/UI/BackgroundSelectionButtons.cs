using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundSelectionButtons : MonoBehaviour {

    public DataBaseManager dataBaseManager;
    private Canvas BackgroundSelection;
    public MenuGUI menuGUI;

    private ArrayList RefErrors = new ArrayList();


    public GridLayoutGroup[] ChoiceDisplay = new GridLayoutGroup[3]; 

	public string PlayerFirstName;
    public string PlayerLastName;
    public string PlayerBio;
    public int genderSelection=0;

	void Start () {

        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc", "BlueStarDataWarehouse.db");

        BackgroundSelection = GetComponent<Canvas>();

		for (int i=0;i<3;i++) {
			ChoiceDisplay[i]=BackgroundSelection.GetComponentsInChildren<GridLayoutGroup>()[i];
		}
		BackgroundSelection.enabled = false;
	}

	public bool TestDetails () {
		PlayerFirstName = ChoiceDisplay [0].GetComponentsInChildren<Text> () [2].text;
		PlayerLastName = ChoiceDisplay [0].GetComponentsInChildren<Text> () [5].text;
		PlayerBio=ChoiceDisplay [1].GetComponentsInChildren<Text> () [2].text;
		
		for (int i=0; i<6; i++) {
			if (ChoiceDisplay [2].GetComponentsInChildren<Toggle> () [i].isOn==true) {genderSelection=i+1;}
		}

		if( !(PlayerFirstName=="") && !(PlayerLastName=="") && !(PlayerBio=="") && !(genderSelection==0) ) {return true;} else {return false; }
	}
	

	public void Next (){

        if (TestDetails()== true) { menuGUI.MenuGoNext(0); }
        else {
            menuGUI.dialogue.UpdateDialogue(false, (string)((ArrayList)RefErrors[3])[2], (string)((ArrayList)RefErrors[3])[3], (string)((ArrayList)RefErrors[3])[4]);

        }
    }

    public void Back()
    {
        menuGUI.MenuGoBack(0);
        BackgroundSelection.enabled = false;

    }

    public void ActivateMenu()
    {
        BackgroundSelection.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;
    }


}
