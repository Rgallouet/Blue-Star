using UnityEngine;
using System.Collections;

public class HistoryAllocation
{
    public DataBaseManager dataBaseManager;
    private ArrayList Stats;
	private BasePlayer newPlayer;
    private string speciesSelectionStr;

    public string[] GetChoiceArray(int hellCircleSelection, int allegianceSelection, int genusSelection, int speciesSelection, int classSelection, int impSelection, int originSelection, int temperSelection, int astroSelection, int affinitySelection) {

        string[] ReturnArray = new string[10];
        ReturnArray[0] = "01_0" + hellCircleSelection;
        ReturnArray[1] = "02_0" + allegianceSelection;
        ReturnArray[2] = "03_0" + genusSelection + "g";
        if (speciesSelection <10) ReturnArray[3] = "03_0" + speciesSelection + "s";
        else ReturnArray[3] = "03_" + speciesSelection + "s";
        ReturnArray[4] = "04_0" + classSelection;
        ReturnArray[5] = "05_0" + impSelection;
        ReturnArray[6] = "06_0" + originSelection;
        ReturnArray[7] = "07_0" + temperSelection;
        ReturnArray[8] = "08_0" + astroSelection;
        ReturnArray[9] = "09_0" + affinitySelection;

        return ReturnArray;
    }


    public void CreateNewPlayer (int hellCircleSelection, int allegianceSelection, int genusSelection, int speciesSelection, int classSelection, int impSelection, int originSelection, int temperSelection, int astroSelection, int affinitySelection)
	{

        //Get the choices
        string[] Choices = GetChoiceArray(hellCircleSelection, allegianceSelection, genusSelection, speciesSelection, classSelection, impSelection, originSelection, temperSelection, astroSelection, affinitySelection);

        //Get the stats for the choices
        Stats = dataBaseManager.getArrayData(
            "select count(*), sum(Strength), sum(Speed), sum(Dexterity), sum(Embodiment), sum(Reflex), sum(Resilience), " + 
            "sum(Knowledge), sum(Elocution), sum(Intellect), sum(Influence), sum(Focus), sum(Mockery), " + 
            "sum(Malevolent), sum(Unmerciful), " + 
            "sum(Rage), sum(Phase), " + 
            "sum(Momentum), sum(Balance), sum(Chaos), sum(Luck), sum(Perception), sum(Judgement) " +
            "from REF_CustomCharacters " + 
            "where Id in ('" + Choices[0] + "','" + Choices[1] + "','" + Choices[2] + "','" + Choices[3] + "','" + Choices[4] + "','" + Choices[5] + "','" + Choices[6] + "','" + Choices[7] + "','" + Choices[8] + "','" + Choices[9] + "')", "BlueStarDataWarehouse.db");

        //Reset or Create new player
        BasePlayer newPlayer = new BasePlayer ();

        //Reset Xp & Money
		InitiateXPandMoney (newPlayer);

        // Reinitialise Stats based on choices
		HistoryMatrixStats (newPlayer);

        // Store Data
		StoreDataInGameInformation (newPlayer);
	
	}

	void InitiateXPandMoney (BasePlayer newPlayer)
	{

		// Init level
		newPlayer.PlayerLevel = 1;
		newPlayer.TotalXP = 0;
		newPlayer.CurrentXP = 0;
		newPlayer.RequiredXP = 100;
		newPlayer.HumanCrap = 0;
		

	}

	void HistoryMatrixStats (BasePlayer newPlayer)
	{

        int Base_prim = 100;
        int Base_heroic = 10;
        int Base_sec = 100;

        newPlayer.PrimaryStatPointsToAllocate = 5;
		newPlayer.HeroicStatPointsToAllocate = 0;
		newPlayer.SecondaryStatPointsToAllocate = 5;
        		
		newPlayer.Strength =    Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[1]);
        newPlayer.Speed =       Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[2]);
        newPlayer.Dexterity =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[3]);
        newPlayer.Embodiment =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[4]);
        newPlayer.Reflex =      Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[5]);
        newPlayer.Resilience =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[6]);

        newPlayer.Knowledge =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[7]);
        newPlayer.Elocution =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[8]);
        newPlayer.Intellect =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[9]);
        newPlayer.Influence =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[10]);
        newPlayer.Focus =       Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[11]);
        newPlayer.Mockery =     Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[12]);

        newPlayer.Malevolent =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[13]);
        newPlayer.Unmerciful =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[14]);

        newPlayer.Rage =        Base_heroic + System.Convert.ToInt32(((ArrayList)Stats[1])[15]);
        newPlayer.Phase =       Base_heroic + System.Convert.ToInt32(((ArrayList)Stats[1])[16]);

        newPlayer.Momentum =    Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[17]);
        newPlayer.Balance =     Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[18]);
        newPlayer.Chaos =       Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[19]);
        newPlayer.Luck =        Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[20]);
        newPlayer.Perception =  Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[21]);
        newPlayer.Judgement =   Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[22]);

        // Calculate Base stats
        newPlayer.CurrentEmbodiment = newPlayer.Embodiment;
		newPlayer.CurrentInfluence = newPlayer.Influence;
	}

	void StoreDataInGameInformation (BasePlayer newPlayer)
	{
		//Storing base stat in environment
		GameInformation.BasePlayer = newPlayer;
	}





}
