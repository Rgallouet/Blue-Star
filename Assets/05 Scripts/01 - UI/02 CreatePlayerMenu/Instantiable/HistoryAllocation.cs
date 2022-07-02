using UnityEngine;
using System.Collections;

public class HistoryAllocation
{
    private ArrayList Stats;

      
    public string[] GetChoiceArray(HistoryChoices historyChoices) {

        string[] ReturnArray = new string[10];
        ReturnArray[0] = "01_0" + historyChoices.HellCircleChoice;
        ReturnArray[1] = "02_0" + historyChoices.AllegianceChoice;
        ReturnArray[2] = "03_0" + historyChoices.GenusChoice + "g";
        if (historyChoices.SpeciesChoice <10) ReturnArray[3] = "03_0" + historyChoices.SpeciesChoice + "s";
        else ReturnArray[3] = "03_" + historyChoices.SpeciesChoice + "s";
        ReturnArray[4] = "04_0" + historyChoices.JobChoice;
        ReturnArray[5] = "05_0" + historyChoices.ImpChoice;
        ReturnArray[6] = "06_0" + historyChoices.OriginChoice;
        ReturnArray[7] = "07_0" + historyChoices.TemperChoice;
        ReturnArray[8] = "08_0" + historyChoices.AstroChoice;
        ReturnArray[9] = "09_0" + historyChoices.AffinityChoice;

        return ReturnArray;
    }


    public BasePlayer CreateNewPlayer (HistoryChoices historyChoices, DataBaseManager dataBaseManager)
	{

 
        
        //Reset or Create new player
        BasePlayer newPlayer = new BasePlayer ();

        newPlayer.HistoryChoices = historyChoices;

        //Reset Xp & Money
        InitiateXPandMoney (newPlayer);

        // Reinitialise Stats based on choices
        newPlayer.HistoryChoicesModifier = HistoryMatrixStats (historyChoices, dataBaseManager);

        return newPlayer;
    }

	void InitiateXPandMoney (BasePlayer newPlayer)
	{

		// Init level
		newPlayer.PlayerLevel = 1;
		newPlayer.CurrentXP = 0;
		newPlayer.HumanCrap = 0;
        newPlayer.Gold = 0;
        

    }

    public StatModifier HistoryMatrixStats (HistoryChoices historyChoices, DataBaseManager dataBaseManager)
	{

        StatModifier ReturnModifier = new StatModifier();
        
        //Get the choices
        string[] Choices = GetChoiceArray(historyChoices);

        //Get the stats for the choices
        Stats = dataBaseManager.getArrayData(
            "select count(*), sum(Strength), sum(Speed), sum(Dexterity), sum(Embodiment), sum(Reflex), sum(Resilience), " +
            "sum(Knowledge), sum(Elocution), sum(Intellect), sum(Influence), sum(Focus), sum(Mockery), " +
            "sum(Malevolent), sum(Unmerciful), " +
            "sum(Rage), sum(Phase), " +
            "sum(Momentum), sum(Balance), sum(Chaos), sum(Luck), sum(Perception), sum(Judgement) " +
            "from REF_CustomCharacters " +
            "where Id in ('" + Choices[0] + "','" + Choices[1] + "','" + Choices[2] + "','" + Choices[3] + "','" + Choices[4] + "','" + Choices[5] + "','" + Choices[6] + "','" + Choices[7] + "','" + Choices[8] + "','" + Choices[9] + "')");

        
        int Base_prim = 100;
        int Base_heroic = 10;
        int Base_sec = 100;
	
		ReturnModifier.Strength =    Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[1]);
        ReturnModifier.Speed =       Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[2]);
        ReturnModifier.Dexterity =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[3]);
        ReturnModifier.Embodiment =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[4]);
        ReturnModifier.Reflex =      Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[5]);
        ReturnModifier.Resilience =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[6]);

        ReturnModifier.Knowledge =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[7]);
        ReturnModifier.Elocution =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[8]);
        ReturnModifier.Intellect =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[9]);
        ReturnModifier.Influence =   Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[10]);
        ReturnModifier.Focus =       Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[11]);
        ReturnModifier.Mockery =     Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[12]);

        ReturnModifier.Malevolent =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[13]);
        ReturnModifier.Unmerciful =  Base_prim + System.Convert.ToInt32(((ArrayList)Stats[1])[14]);

        ReturnModifier.Rage =        Base_heroic + System.Convert.ToInt32(((ArrayList)Stats[1])[15]);
        ReturnModifier.Phase =       Base_heroic + System.Convert.ToInt32(((ArrayList)Stats[1])[16]);

        ReturnModifier.Momentum =    Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[17]);
        ReturnModifier.Balance =     Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[18]);
        ReturnModifier.Chaos =       Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[19]);
        ReturnModifier.Luck =        Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[20]);
        ReturnModifier.Perception =  Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[21]);
        ReturnModifier.Judgement =   Base_sec + System.Convert.ToInt32(((ArrayList)Stats[1])[22]);

        return ReturnModifier;
  

	}
    





}
