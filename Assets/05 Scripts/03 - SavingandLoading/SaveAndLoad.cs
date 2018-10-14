using UnityEngine;
using System.Collections;

public class SaveAndLoad: MonoBehaviour {

    public DataBaseManager dataBaseManager;

    private ArrayList PlayerStaticChoices;
    private ArrayList PlayerStatsModifiers;
    private ArrayList PlayerProgress;
    private ArrayList PlayerCity;
    private ArrayList PlayerAccountStatsBefore;
    private ArrayList CurrentSlot;

    private HistoryAllocation historyAllocation = new HistoryAllocation();

    private int MapSize = 150;

    private int GetSlot() {

        //Getting the slot
        CurrentSlot = dataBaseManager.getArrayData("select * from CrossSceneTemporaryData ", "BlueStarDataWarehouse.db");
        int Slot = System.Convert.ToInt32(((ArrayList)CurrentSlot[1])[0]);
        return Slot;

    }

    public void SettingTheCurrentSaveSlot(int Slot) {

        string[] CrossSceneData = {
            "CurrentSlot = " + Slot
        };

        // Setting the current game instance to the selected save slot for cross scene management
        dataBaseManager.UpdateData("CrossSceneTemporaryData", "1=1", CrossSceneData);

    }

    public void SavePlayerChoicesInDataBase(BasePlayer Player)
    {
        int Slot = GetSlot();


        // Saving the detailed choices
        string[] PlayerStaticChoicesValues = {

            "FirstName = '" +       Player.PlayerFirstName + "'",
            "LastName = '" +        Player.PlayerLastName + "'",
            "Bio = '" +             Player.PlayerBio + "'",
            "Gender = '" +          Player.PlayerGender + "'",

            "HellCircleChoice = " + Player.HistoryChoices.HellCircleChoice,
            "AllegianceChoice = " + Player.HistoryChoices.AllegianceChoice,
            "GenusChoice = " +      Player.HistoryChoices.GenusChoice,
            "SpeciesChoice = " +    Player.HistoryChoices.SpeciesChoice,
            "JobChoice = " +        Player.HistoryChoices.JobChoice,
            "ImpChoice = " +        Player.HistoryChoices.ImpChoice,
            "OriginChoice = "  +    Player.HistoryChoices.OriginChoice,
            "TemperChoice = " +     Player.HistoryChoices.TemperChoice ,
            "AstroChoice = " +      Player.HistoryChoices.AstroChoice,
            "AffinityChoice = " +   Player.HistoryChoices.AffinityChoice

        };


        dataBaseManager.UpdateData("PlayerStaticChoices", "Slot=" + Slot, PlayerStaticChoicesValues);


        // Saving the allocated points
        string[] PlayerStatsModifiersValues = {

            "Strength = " +         Player.AllocatedStatsModifier.Strength  ,
            "Speed = " +            Player.AllocatedStatsModifier.Speed  ,
            "Dexterity = " +        Player.AllocatedStatsModifier.Dexterity  ,
            "Embodiment = " +       Player.AllocatedStatsModifier.Embodiment  ,
            "Reflex = " +           Player.AllocatedStatsModifier.Reflex ,
            "Resilience = " +       Player.AllocatedStatsModifier.Resilience ,
            "Knowledge = " +        Player.AllocatedStatsModifier.Knowledge  ,
            "Elocution = " +        Player.AllocatedStatsModifier.Elocution  ,
            "Intellect = " +        Player.AllocatedStatsModifier.Intellect  ,
            "Influence = " +        Player.AllocatedStatsModifier.Influence  ,
            "Focus = " +            Player.AllocatedStatsModifier.Focus  ,
            "Mockery = " +          Player.AllocatedStatsModifier.Mockery  ,
            "Malevolent = " +       Player.AllocatedStatsModifier.Malevolent  ,
            "Unmerciful = " +       Player.AllocatedStatsModifier.Unmerciful  ,
            "Rage = " +             Player.AllocatedStatsModifier.Rage  ,
            "Phase = " +            Player.AllocatedStatsModifier.Phase  ,
            "Momentum = " +         Player.AllocatedStatsModifier.Momentum ,
            "Balance = " +          Player.AllocatedStatsModifier.Balance ,
            "Chaos = " +            Player.AllocatedStatsModifier.Chaos  ,
            "Luck = " +             Player.AllocatedStatsModifier.Luck ,
            "Perception = " +       Player.AllocatedStatsModifier.Perception ,
            "Judgement = " +        Player.AllocatedStatsModifier.Judgement ,

        };

        dataBaseManager.UpdateData("PlayerStatsModifiers", "Slot=" + Slot + " and ModifierSource='PlayerCreation' ", PlayerStatsModifiersValues);


        // Resetting the progress of the hero
        string[] PlayerProgressValues = {

            "Level = " +            Player.PlayerLevel  ,
            "CurrentXp = " +        Player.CurrentXP  ,
            "HumanCrap = " +        Player.HumanCrap ,
            "Gold = " +             Player.Gold

        };

        dataBaseManager.UpdateData("PlayerProgress", "Slot=" + Slot, PlayerProgressValues);


        // Updating the account general stat, and increasing by one the number of legacy
        PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats where Slot =" + Slot, "BlueStarDataWarehouse.db");

        string[] PlayerAccountStats = { "NumberOfLegacy = " + (System.Convert.ToInt32(((ArrayList)PlayerAccountStatsBefore[1])[2])+1) };

        dataBaseManager.UpdateData("PlayerAccountStats", "Slot=" + Slot, PlayerAccountStats);

        
    }
    

    public BasePlayer LoadPlayerChoicesFromDataBase()
    {

        int Slot = GetSlot();


        BasePlayer Player = new BasePlayer();

        // DataBase Extract
        PlayerStaticChoices = dataBaseManager.getArrayData("select * from PlayerStaticChoices where Slot =" + Slot, "BlueStarDataWarehouse.db");
        PlayerStatsModifiers = dataBaseManager.getArrayData("select * from PlayerStatsModifiers where ModifierSource='PlayerCreation' and Slot =" + Slot, "BlueStarDataWarehouse.db");
        PlayerProgress = dataBaseManager.getArrayData("select * from PlayerProgress where Slot =" + Slot, "BlueStarDataWarehouse.db");
        PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats where Slot =" + Slot, "BlueStarDataWarehouse.db");

        //StaticChoices
        Player.PlayerFirstName =    (string)((ArrayList)PlayerStaticChoices[1])[1];
        Player.PlayerLastName =     (string)((ArrayList)PlayerStaticChoices[1])[2];
        Player.PlayerBio =          (string)((ArrayList)PlayerStaticChoices[1])[3];
        Player.PlayerGender =       (string)((ArrayList)PlayerStaticChoices[1])[4];

        Player.HistoryChoices.HellCircleChoice =    System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[5]);
        Player.HistoryChoices.AllegianceChoice =    System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[6]);
        Player.HistoryChoices.GenusChoice =         System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[7]);
        Player.HistoryChoices.SpeciesChoice =       System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[8]);
        Player.HistoryChoices.JobChoice =           System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[9]);
        Player.HistoryChoices.ImpChoice =           System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[10]);
        Player.HistoryChoices.OriginChoice =        System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[11]);
        Player.HistoryChoices.TemperChoice =        System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[12]);
        Player.HistoryChoices.AstroChoice =         System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[13]);
        Player.HistoryChoices.AffinityChoice =      System.Convert.ToInt32(((ArrayList)PlayerStaticChoices[1])[14]);

        Player.HistoryChoicesModifier = historyAllocation.HistoryMatrixStats(Player.HistoryChoices, dataBaseManager);


        // StatsModifiers
        Player.AllocatedStatsModifier.Strength =           System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[2]);
        Player.AllocatedStatsModifier.Speed =              System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[3]);
        Player.AllocatedStatsModifier.Dexterity =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[4]);
        Player.AllocatedStatsModifier.Embodiment =         System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[5]);
        Player.AllocatedStatsModifier.Reflex =             System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[6]);
        Player.AllocatedStatsModifier.Resilience =         System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[7]);

        Player.AllocatedStatsModifier.Knowledge =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[8]);
        Player.AllocatedStatsModifier.Elocution =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[9]);
        Player.AllocatedStatsModifier.Intellect =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[10]);
        Player.AllocatedStatsModifier.Influence =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[11]);
        Player.AllocatedStatsModifier.Focus =              System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[12]);
        Player.AllocatedStatsModifier.Mockery =            System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[13]);

        Player.AllocatedStatsModifier.Malevolent =         System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[14]);
        Player.AllocatedStatsModifier.Unmerciful =         System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[15]);

        Player.AllocatedStatsModifier.Rage =               System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[16]);
        Player.AllocatedStatsModifier.Phase =              System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[17]);

        Player.AllocatedStatsModifier.Momentum =           System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[18]);
        Player.AllocatedStatsModifier.Balance =            System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[19]);
        Player.AllocatedStatsModifier.Chaos =              System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[20]);
        Player.AllocatedStatsModifier.Luck =               System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[21]);
        Player.AllocatedStatsModifier.Perception =         System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[22]);
        Player.AllocatedStatsModifier.Judgement =          System.Convert.ToInt32(((ArrayList)PlayerStatsModifiers[1])[23]);


        // Progress
        Player.PlayerLevel =                               System.Convert.ToInt32(((ArrayList)PlayerProgress[1])[1]);
        Player.CurrentXP =                                 System.Convert.ToInt32(((ArrayList)PlayerProgress[1])[2]);
        Player.HumanCrap =                                 System.Convert.ToInt32(((ArrayList)PlayerProgress[1])[3]);
        Player.Gold =                                      System.Convert.ToInt32(((ArrayList)PlayerProgress[1])[4]);

        
        //MakeTheSum
        Player.Strength =       Player.HistoryChoicesModifier.Strength + Player.AllocatedStatsModifier.Strength;
        Player.Speed =          Player.HistoryChoicesModifier.Speed + Player.AllocatedStatsModifier.Speed;
        Player.Dexterity =      Player.HistoryChoicesModifier.Dexterity + Player.AllocatedStatsModifier.Dexterity;
        Player.Embodiment =     Player.HistoryChoicesModifier.Embodiment + Player.AllocatedStatsModifier.Embodiment;
        Player.Reflex =         Player.HistoryChoicesModifier.Reflex + Player.AllocatedStatsModifier.Reflex;
        Player.Resilience =     Player.HistoryChoicesModifier.Resilience + Player.AllocatedStatsModifier.Resilience;

        Player.Knowledge =      Player.HistoryChoicesModifier.Knowledge + Player.AllocatedStatsModifier.Knowledge;
        Player.Elocution =      Player.HistoryChoicesModifier.Elocution + Player.AllocatedStatsModifier.Elocution;
        Player.Intellect =      Player.HistoryChoicesModifier.Intellect + Player.AllocatedStatsModifier.Intellect;
        Player.Influence =      Player.HistoryChoicesModifier.Influence + Player.AllocatedStatsModifier.Influence;
        Player.Focus =          Player.HistoryChoicesModifier.Focus + Player.AllocatedStatsModifier.Focus;
        Player.Mockery =        Player.HistoryChoicesModifier.Mockery + Player.AllocatedStatsModifier.Mockery;

        Player.Malevolent =     Player.HistoryChoicesModifier.Malevolent + Player.AllocatedStatsModifier.Malevolent;
        Player.Unmerciful =     Player.HistoryChoicesModifier.Unmerciful + Player.AllocatedStatsModifier.Unmerciful;

        Player.Rage =           Player.HistoryChoicesModifier.Rage + Player.AllocatedStatsModifier.Rage;
        Player.Phase =          Player.HistoryChoicesModifier.Phase + Player.AllocatedStatsModifier.Phase;

        Player.Momentum =       Player.HistoryChoicesModifier.Momentum + Player.AllocatedStatsModifier.Momentum;
        Player.Balance =        Player.HistoryChoicesModifier.Balance + Player.AllocatedStatsModifier.Balance;
        Player.Chaos =          Player.HistoryChoicesModifier.Chaos + Player.AllocatedStatsModifier.Chaos;
        Player.Luck =           Player.HistoryChoicesModifier.Luck + Player.AllocatedStatsModifier.Luck;
        Player.Perception =     Player.HistoryChoicesModifier.Perception + Player.AllocatedStatsModifier.Perception;
        Player.Judgement =      Player.HistoryChoicesModifier.Judgement + Player.AllocatedStatsModifier.Judgement;

        Player.NumberOfLegacy = System.Convert.ToInt32(((ArrayList)PlayerAccountStatsBefore[1])[2]);
        Player.UnderCityExist = System.Convert.ToInt32(((ArrayList)PlayerAccountStatsBefore[1])[3]);

        Player.BuildingLevel = 1;
        Player.DiggingLevel = 1;


        return Player;
    }



    public void SavePlayerCityInDataBase(int[][] Map)
    {


        int Slot = GetSlot();

        int z = 0;
        int x = 0;

        for (int i = 0; i < MapSize; i++) {

            string[] PlayerCityVector = new string[150];

            for (int j = 0; j < MapSize; j++) {
                z = j + 1;
                x = i + 1;
                
                PlayerCityVector[j]="Cube" + z + "= " + Map[i][j];

            }
             
            dataBaseManager.UpdateData("PlayerCity", "Slot=" + Slot + " and X=" + x, PlayerCityVector);
        }


        // Saving the status of the city
        string[] PlayerAccountStats = { "UnderCityExist = 1" };
        dataBaseManager.UpdateData("PlayerAccountStats", "Slot=" + Slot, PlayerAccountStats);




    }



    public void UpdateCityData(int Cube,int x, int z)
    {

        int Slot = GetSlot();
        string[] PlayerCityVector = new string[1];
        PlayerCityVector[0] = "Cube" + z + "= " + Cube;

        dataBaseManager.UpdateData("PlayerCity", "Slot=" + Slot + " and X=" + x, PlayerCityVector);
       

    }




    public int[][] LoadPlayerCityFromDataBase()
    {

        int Slot = GetSlot();

        PlayerCity = dataBaseManager.getArrayData("select * from PlayerCity where Slot =" + Slot, "BlueStarDataWarehouse.db");

        int[][] MapArray = new int[MapSize][];
        for (int i = 0; i < MapSize; i++) MapArray[i] = new int[MapSize];
                        
        for (int i = 0; i < 150; i++)
        {
            for (int j = 0; j < 150; j++)
            {
                MapArray[i][j] = System.Convert.ToInt32(((ArrayList)PlayerCity[i+1])[j+2]);
            }
        }

        return MapArray;

    }




}
