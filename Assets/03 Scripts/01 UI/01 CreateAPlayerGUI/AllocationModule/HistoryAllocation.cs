using UnityEngine;
using System.Collections;

public class HistoryAllocation
{
    public DataBaseManager dataBaseManager;
    private ArrayList Stats;
	private BasePlayer newPlayer;

    public string[] GetChoiceArray(int hellCircleChoice, int allegianceChoice, int genusChoice, int speciesChoice, int JobChoice, int impChoice, int originChoice, int temperChoice, int astroChoice, int affinityChoice) {

        string[] ReturnArray = new string[10];
        ReturnArray[0] = "01_0" + hellCircleChoice;
        ReturnArray[1] = "02_0" + allegianceChoice;
        ReturnArray[2] = "03_0" + genusChoice + "g";
        if (speciesChoice <10) ReturnArray[3] = "03_0" + speciesChoice + "s";
        else ReturnArray[3] = "03_" + speciesChoice + "s";
        ReturnArray[4] = "04_0" + JobChoice;
        ReturnArray[5] = "05_0" + impChoice;
        ReturnArray[6] = "06_0" + originChoice;
        ReturnArray[7] = "07_0" + temperChoice;
        ReturnArray[8] = "08_0" + astroChoice;
        ReturnArray[9] = "09_0" + affinityChoice;

        return ReturnArray;
    }


    public void CreateNewPlayer (int hellCircleChoice, int allegianceChoice, int genusChoice, int speciesChoice, int JobChoice, int impChoice, int originChoice, int temperChoice, int astroChoice, int affinityChoice)
	{

        //Get the choices
        string[] Choices = GetChoiceArray(hellCircleChoice, allegianceChoice, genusChoice, speciesChoice, JobChoice, impChoice, originChoice, temperChoice, astroChoice, affinityChoice);

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
		HistoryMatrixStats (newPlayer, hellCircleChoice, allegianceChoice, genusChoice, speciesChoice, JobChoice, impChoice, originChoice, temperChoice, astroChoice, affinityChoice);

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

	void HistoryMatrixStats (BasePlayer newPlayer, int hellCircleChoice, int allegianceChoice, int genusChoice, int speciesChoice, int JobChoice, int impChoice, int originChoice, int temperChoice, int astroChoice, int affinityChoice)
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

        //Choices

        newPlayer.HellCircleChoice =    hellCircleChoice;
        newPlayer.AllegianceChoice =    allegianceChoice;
        newPlayer.GenusChoice=          genusChoice;
        newPlayer.SpeciesChoice=        speciesChoice;
        newPlayer.JobChoice=            JobChoice;
        newPlayer.ImpChoice=            impChoice;
        newPlayer.OriginChoice=         originChoice;
        newPlayer.TemperChoice=         temperChoice;
        newPlayer.AstroChoice=          astroChoice;
        newPlayer.AffinityChoice=       affinityChoice;


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
