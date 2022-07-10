using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundSelectionButtons : MonoBehaviour {

    public DataBaseManager dataBaseManager;
    private Canvas BackgroundSelection;
    public MenuGUI menuGUI;

    private ArrayList RefErrors = new ArrayList();


    private GridLayoutGroup[] ChoiceDisplay = new GridLayoutGroup[2];

    public string CharacterName;
    public string CharacterBio;
    public string CharacterGender;

    private string[] genderSelectionNames = new string[] { "Male", "Female", "Bigender", "Pangender", "Agender", "Other" };

    public int genderSelection=0;

	void Start () {

        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc");

        BackgroundSelection = GetComponent<Canvas>();

		for (int i=0;i<2;i++) {
			ChoiceDisplay[i]=BackgroundSelection.GetComponentsInChildren<GridLayoutGroup>()[i];
		}
		BackgroundSelection.enabled = false;
	}

	void UpdateDetails () {
		CharacterBio=ChoiceDisplay [0].GetComponentsInChildren<Text> () [2].text;
		
		for (int i=0; i<6; i++) {
			if (ChoiceDisplay [1].GetComponentsInChildren<Toggle> () [i].isOn==true) {
                genderSelection =i+1;
                CharacterGender = genderSelectionNames[genderSelection - 1];
            }
		}
        
	}


    public bool TestDetails()
    {
        if (!(CharacterGender == "") && CharacterBio.IndexOf("'")==-1) { return true; } else { return false; }
    }

    public void Next (){

        if (menuGUI.account.NumberOfDeaths == 0)
        {
            menuGUI.MenuGoNext(0);
            BackgroundSelection.enabled = false;
        }
        else {
   
            UpdateDetails();

            if (TestDetails() == true)
            {
                menuGUI.MenuGoNext(0);
                BackgroundSelection.enabled = false;
            }
            else
            { 
                menuGUI.dialogue.UpdateDialogue(150, (string)((ArrayList)RefErrors[3])[2], (string)((ArrayList)RefErrors[3])[3], (string)((ArrayList)RefErrors[3])[4]);
            }
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

        if (menuGUI.account.NumberOfDeaths == 0) {

            CharacterName = "Aephyn";
            CharacterBio = "Aephyn is the last vampyri lord of her forgotten house, and seeks to restore the glory of her name through stolen wealth. She embarks in a perilous heist on the family vault of an ancient archdemon, to find an unexpected end.";
            CharacterGender = "Bigender";

            Next();
        }



    }


}
