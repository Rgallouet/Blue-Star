using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StatAllocationButtons : MonoBehaviour {

    public DataBaseManager dataBaseManager;
    private ArrayList refData = new ArrayList();
    private ArrayList RefErrors = new ArrayList();


    public MenuGUI menuGUI;

	private Canvas StatAllocationMenu;
    public GameObject DisplayStatArea;
    
    public Text[] PrimaryNumbers = new Text[14];
	public Text[] HeroicNumbers = new Text[2];
	public Text[] SecondaryNumbers = new Text[6];
	public Text[] PointsToAlloc = new Text[3];

	public Button[] PrimaryPlus = new Button[14];
	public Button[] HeroicPlus = new Button[2];
	public Button[] SecondaryPlus = new Button[6];

	public Button[] PrimaryMinus = new Button[14];
	public Button[] HeroicMinus = new Button[2];
	public Button[] SecondaryMinus = new Button[6];

	private Text DescriptionHead;
	private Text DescriptionBody;





    void Start(){

		StatAllocationMenu = GetComponent<Canvas>();

        refData = dataBaseManager.getArrayData("select * from REF_StatsDescription order by Id asc", "BlueStarDataWarehouse.db");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc", "BlueStarDataWarehouse.db");

        for (int i = 0; i < 22; i++) {
            StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[0].GetComponentsInChildren<Button>()[i].GetComponentInChildren<Text>().text=(string)((ArrayList)refData[i+1])[1]; 
        }

        //Find the Minus buttons for each stat to update visible/invisible property
        for (int i = 0; i < 14; i++) { PrimaryMinus[i] =        StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[1].GetComponentsInChildren<Button>()[i]; }
        for (int i = 0; i < 2; i++) { HeroicMinus[i] =          StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[1].GetComponentsInChildren<Button>()[i+14]; }
        for (int i = 0; i < 6; i++) { SecondaryMinus[i] =       StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[1].GetComponentsInChildren<Button>()[i+16]; }

        // Find the stats display areas to update numbers when used push buttons
        for (int i=0; i<6; i++)		{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+1];}
		for (int i=6; i<12; i++)	{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+2];}
		for (int i=12; i<14; i++)	{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+3];}
		for (int i=0; i<2; i++) 	{ HeroicNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+14+4];}
		for (int i=0; i<6; i++) 	{ SecondaryNumbers [i] = 	StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+16+5];}
		for (int i=0; i<3; i++) 	{ PointsToAlloc [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[2].GetComponentsInChildren<Text> () [i+28];}

        // Find the Plus buttons for each stat to update visibile/invisible property
		for (int i=0; i<14; i++)	{ PrimaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[3].GetComponentsInChildren<Button> () [i];}
		for (int i=0; i<2; i++) 	{ HeroicPlus [i] = 			StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[3].GetComponentsInChildren<Button> ()[i+14];}
		for (int i=0; i<6; i++) 	{ SecondaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup>()[3].GetComponentsInChildren<Button> ()[i+16];}

        DescriptionHead = DisplayStatArea.GetComponentsInChildren<Text> ()[0];
		DescriptionBody = DisplayStatArea.GetComponentsInChildren<Text> ()[1];

		StatAllocationMenu.enabled = false;

	}


    // Interaction with UI Stats Buttons
    public void DisplayStat(int WhichButton)
    {
    DescriptionHead.text = (string)((ArrayList)refData[WhichButton+1])[1] + " Description";
    DescriptionBody.text = "<i>" + (string)((ArrayList)refData[WhichButton+1])[6] + "</i> \n\n" + (string)((ArrayList)refData[WhichButton + 1])[5]; 
    }

    
    public void CallPlusStat(int Stat_ID){

        CallStatAllocationMoveStat (true, Stat_ID);
        DisplayStat(Stat_ID);
    }

	public void CallMinusStat(int Stat_ID){
		CallStatAllocationMoveStat (false, Stat_ID);
        DisplayStat(Stat_ID);
    }

    public void CallStatAllocationMoveStat(bool Move, int Stat_ID)
    {
        menuGUI.statAllocation.MoveStat(Move, Stat_ID);
        menuGUI.statAllocation.RefreshDisplayStatsNumbers();
        menuGUI.statAllocation.CalculateDisplayPlusMinusButtons();
    }


    public void Next()
    {


        if (menuGUI.statAllocation.readyForNext==true)
        {
            menuGUI.MenuGoBack(0);
            StatAllocationMenu.enabled = false;

        }
        else
        {
            menuGUI.dialogue.UpdateDialogue(false, (string)((ArrayList)RefErrors[2])[2], (string)((ArrayList)RefErrors[2])[3], (string)((ArrayList)RefErrors[2])[4]);
        }

    }

    public void Back ()
    {

        if (menuGUI.WasPredefinedPath == true)
        { menuGUI.MenuGoBack(1); }
        else { menuGUI.MenuGoBack(2); }
        StatAllocationMenu.enabled = false;

    }

    public void ActivateMenu() {
        StatAllocationMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
        menuGUI.statAllocation.DisplayStatAllocationModule();
    }




}
