using UnityEngine;
using System.Collections;

public class SaveAndLoad: MonoBehaviour {

    public DataBaseManager dataBaseManager;

    private ArrayList PlayerStaticChoices;
    private ArrayList PlayerStatsModifiers;
    private ArrayList PlayerProgress;
    private ArrayList PlayerCity;
    private ArrayList PlayerAccountStatsBefore;
    private ArrayList RefCitySize;

    private HistoryAllocation historyAllocation = new HistoryAllocation();

    private int MapSizeOnX;
    private int MapSizeOnZ;

    public void SavePlayerChoicesInDataBase(BasePlayer Player, bool IsItARebirth)
    {
        
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


        dataBaseManager.UpdateData("PlayerStaticChoices", "" , PlayerStaticChoicesValues);


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

        dataBaseManager.UpdateData("PlayerStatsModifiers", "ModifierSource='PlayerCreation' ", PlayerStatsModifiersValues);


        // Resetting the progress of the hero
        string[] PlayerProgressValues = {

            "Level = " +            Player.PlayerLevel  ,
            "CurrentXp = " +        Player.CurrentXP  ,
            "HumanCrap = " +        Player.HumanCrap ,
            "Gold = " +             Player.Gold

        };

        dataBaseManager.UpdateData("PlayerProgress", "", PlayerProgressValues);




        //New Character & City
        if (IsItARebirth==true)
        {
            // Updating the account general stat, and increasing by one the number of legacy
            PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats", "BlueStarDataWarehouse.db");
            string[] PlayerAccountStats = { "NumberOfLegacy = " + (System.Convert.ToInt32(((ArrayList)PlayerAccountStatsBefore[1])[2]) + 1), "UnderCityExist = 0 " };
            dataBaseManager.UpdateData("PlayerAccountStats", "" , PlayerAccountStats);
        }
        
    }
    
    public BasePlayer LoadPlayerChoicesFromDataBase()
    {

        BasePlayer Player = new BasePlayer();

        // DataBase Extract
        PlayerStaticChoices = dataBaseManager.getArrayData("select * from PlayerStaticChoices" , "BlueStarDataWarehouse.db");
        PlayerStatsModifiers = dataBaseManager.getArrayData("select * from PlayerStatsModifiers where ModifierSource='PlayerCreation'" , "BlueStarDataWarehouse.db");
        PlayerProgress = dataBaseManager.getArrayData("select * from PlayerProgress", "BlueStarDataWarehouse.db");
        PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats", "BlueStarDataWarehouse.db");

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



    public void SavePlayerCityInDataBase(int[,] Map, int[,] Sprite)
    {
        // Getting the dimensions of the map
        (MapSizeOnX, MapSizeOnZ) = LoadMapDimension("UnderCity");

        // Saving row by row
        int z = 0;
        int x = 0;

        for (int i = 0; i < MapSizeOnX; i++) {
            for (int j = 0; j < MapSizeOnZ; j++) {
                z = j + 1;
                x = i + 1;
                UpdateCityData(Map[i,j], Sprite[i,j], x, z);
            }

        }


        // Saving the status of the city
        dataBaseManager.UpdateData("PlayerAccountStats", "", new string[1] {"UnderCityExist = 1"});

    }



    public void UpdateCityData(int Tile, int Sprite, int x, int z)
    {
        dataBaseManager.UpdateData("CityMap", "X=" + x + " and Y=" + z , new string[1] { "TileCode= " + Tile + "and SpriteVariation= " + Sprite });
    }




    public (int[,] TileMap, int[,] SpriteMap ) LoadPlayerCityFromDataBase()
    {
        // Getting the dimensions of the map
        (MapSizeOnX, MapSizeOnZ) = LoadMapDimension("UnderCity");

        // Getting the map details
        PlayerCity = dataBaseManager.getArrayData("select * from CityMap", "BlueStarDataWarehouse.db");
 
        int[,] TileMap = new int[MapSizeOnX, MapSizeOnZ];
        int[,] SpriteMap = new int[MapSizeOnX, MapSizeOnZ];
          
        for (int i = 0; i < MapSizeOnX; i++)
        {
            for (int j = 0; j < MapSizeOnZ; j++)
            {
                TileMap[i,j] = System.Convert.ToInt32(((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[3]);
                SpriteMap[i,j] = System.Convert.ToInt32(((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[3]);
            }
        }

        return (TileMap,SpriteMap);

    }


    public (int MapSizeOnX, int MapSizeOnZ) LoadMapDimension(string MapName)
    {

        // Getting the dimensions of the map
        RefCitySize = dataBaseManager.getArrayData("select * from REF_TerrainSpecificities where MapName = '" + MapName  + "'", "BlueStarDataWarehouse.db");
        MapSizeOnX = System.Convert.ToInt32(((ArrayList)RefCitySize[0])[2]);
        MapSizeOnZ = System.Convert.ToInt32(((ArrayList)RefCitySize[0])[3]);

    }




}
