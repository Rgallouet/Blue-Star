using UnityEngine;
using System.Collections;

public class SaveAndLoad : MonoBehaviour
{

    public DataBaseManager dataBaseManager;


    public void ResetAllCharactersInDataBase()
    {

        dataBaseManager.RunQuery("DELETE FROM CharacterStatsModifiers;");
        dataBaseManager.RunQuery("DELETE FROM CharacterStaticChoices;");
        dataBaseManager.RunQuery("DELETE FROM CharacterProgress;");

    }

    public void ResetCityInDataBase()
    {

        dataBaseManager.RunQuery("DELETE FROM CityMap;");

    }

    public void ResetResourcesInDataBase()
    {

        dataBaseManager.RunQuery("UPDATE PlayerRessources SET Quantity=0;");

    }


    public void SaveCharacterCreationChoicesInDataBase(BaseCharacter character)
    {

        // Saving the detailed choices
        string[] CharacterStaticChoicesValues = {

            "Name = '" +            character.characterName + "'",
            "Bio = '" +             character.characterBio + "'",
            "Gender = '" +          character.characterGender + "'",

            "HellCircleChoice = '" + character.HistoryChoices.HellCircleChoice + "'",
            "AllegianceChoice = '" + character.HistoryChoices.AllegianceChoice + "'",
            "GenusChoice = '" +      character.HistoryChoices.GenusChoice + "'",
            "SpeciesChoice = '" +    character.HistoryChoices.SpeciesChoice + "'",
            "JobChoice = '" +        character.HistoryChoices.JobChoice + "'",
            "ImpChoice = '" +        character.HistoryChoices.ImpChoice + "'",
            "OriginChoice = '"  +    character.HistoryChoices.OriginChoice + "'",
            "TemperChoice = '" +     character.HistoryChoices.TemperChoice + "'",
            "AstroChoice = '" +      character.HistoryChoices.AstroChoice + "'",
            "AffinityChoice = '" +   character.HistoryChoices.AffinityChoice + "'",

            "LeadershipCost = " +   character.HistoryChoices.LeadershipCost ,

        };

        // updating the static choices
        dataBaseManager.InsertOrUpdateData("CharacterStaticChoices", "CharacterID", character.characterID, CharacterStaticChoicesValues);


        // generating the basic stat modifier line
        string[] CharacterBaseStatsValues = {

            "Strength = " +     (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Speed = " +        (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Dexterity = " +    (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Embodiment = " +   (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Reflex = " +       (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Resilience = " +   (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Knowledge = " +    (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Elocution = " +    (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Intellect = " +    (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Influence = "  +   (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Focus = " +        (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Mockery = " +      (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Malevolent = " +   (50 + 25 * character.HistoryChoices.LeadershipCost),
            "Unmerciful = " +   (50 + 25 * character.HistoryChoices.LeadershipCost),

            "Rage = " +     10,
            "Phase = " +    10,

            "Momentum = " +     100,
            "Balance = " +      100,
            "Chaos = " +        100,
            "Luck = " +         100,
            "Perception = " +   100,
            "Judgement = " +    100,

            "PrimaryStatsToAllocate = " +    0,
            "SecondaryStatsToAllocate = " +  0,
            "HeroicStatsToAllocate = " +        0,

        };

        dataBaseManager.InsertOrUpdateData("CharacterStatsModifiers", "CharacterID", character.characterID, CharacterBaseStatsValues);


        // generating the choices remated stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CharacterStatsModifiers Select " + character.characterID + " as CharacterID, 'CreationChoices' as ModifierSource, sum(Strength) as Strength, sum(Speed) as Speed, sum(Dexterity) as Dexterity, sum(Embodiment) as Embodiment, sum(Reflex) as Reflex, sum(Resilience) as Resilience, " +
            "sum(Knowledge) as Knowledge, sum(Elocution) as Elocution, sum(Intellect) as Intellect, sum(Influence) as Influence, sum(Focus) as Focus, sum(Mockery) as Mockery, " +
            "sum(Malevolent) as Malevolent, sum(Unmerciful) as Unmerciful, " +
            "sum(Rage) as Rage, sum(Phase) as Phase, " +
            "sum(Momentum) as Momentum, sum(Balance) as Balance, sum(Chaos) as Chaos, sum(Luck) as Luck, sum(Perception) as Perception, sum(Judgement) as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from REF_CustomCharacters " +
            "where Id in ('"
            + character.HistoryChoices.HellCircleChoice + "','"
            + character.HistoryChoices.AllegianceChoice + "','"
            + character.HistoryChoices.GenusChoice + "','"
            + character.HistoryChoices.SpeciesChoice + "','"
            + character.HistoryChoices.JobChoice + "','"
            + character.HistoryChoices.ImpChoice + "','"
            + character.HistoryChoices.OriginChoice + "','"
            + character.HistoryChoices.TemperChoice + "','"
            + character.HistoryChoices.AstroChoice + "','"
            + character.HistoryChoices.AffinityChoice
            + "') ON CONFLICT(CharacterID) DO UPDATE ;");


    }

    public void SaveCharacterStatAllocationInDataBase(BaseCharacter character)
    {

        // Saving the allocated points
        string[] CharacterStatsModifiersValues = {

            "ModifierSource = 'AllocatedStats'" ,
            "Strength = " +         character.AllocatedStatsModifier.Strength  ,
            "Speed = " +            character.AllocatedStatsModifier.Speed  ,
            "Dexterity = " +        character.AllocatedStatsModifier.Dexterity  ,
            "Embodiment = " +       character.AllocatedStatsModifier.Embodiment  ,
            "Reflex = " +           character.AllocatedStatsModifier.Reflex ,
            "Resilience = " +       character.AllocatedStatsModifier.Resilience ,
            "Knowledge = " +        character.AllocatedStatsModifier.Knowledge  ,
            "Elocution = " +        character.AllocatedStatsModifier.Elocution  ,
            "Intellect = " +        character.AllocatedStatsModifier.Intellect  ,
            "Influence = " +        character.AllocatedStatsModifier.Influence  ,
            "Focus = " +            character.AllocatedStatsModifier.Focus  ,
            "Mockery = " +          character.AllocatedStatsModifier.Mockery  ,
            "Malevolent = " +       character.AllocatedStatsModifier.Malevolent  ,
            "Unmerciful = " +       character.AllocatedStatsModifier.Unmerciful  ,
            "Rage = " +             character.AllocatedStatsModifier.Rage  ,
            "Phase = " +            character.AllocatedStatsModifier.Phase  ,
            "Momentum = " +         character.AllocatedStatsModifier.Momentum ,
            "Balance = " +          character.AllocatedStatsModifier.Balance ,
            "Chaos = " +            character.AllocatedStatsModifier.Chaos  ,
            "Luck = " +             character.AllocatedStatsModifier.Luck ,
            "Perception = " +       character.AllocatedStatsModifier.Perception ,
            "Judgement = " +        character.AllocatedStatsModifier.Judgement ,
            "PrimaryStatsToAllocate = " +        character.AllocatedStatsModifier.primaryStatPointsToAllocate ,
            "SecondaryStatsToAllocate = " +      character.AllocatedStatsModifier.heroicStatPointsToAllocate ,
            "HeroicStatsToAllocate = " +         character.AllocatedStatsModifier.secondaryStatPointsToAllocate ,

        };

        dataBaseManager.InsertOrUpdateData("CharacterStatsModifiers", "CharacterID" , character.characterID, CharacterStatsModifiersValues);


    }

    public void SaveCharacterInDataBase(BaseCharacter character)
    {

        // Saving the allocated points
        string[] CharacterValues = { "Experience = " + character.Experience };

        dataBaseManager.InsertOrUpdateData("CharacterProgress", "CharacterID" , character.characterID, CharacterValues);

    }

    public void SaveAccountDetails(BaseAccount baseAccount)

    {
        // Resetting the progress of the hero
        string[] PlayerProgressValues = {

            "AccountName = " + baseAccount.AccountName,
            "MaximumLevelReached = " + baseAccount.MaximumLevelReached,
            "NumberOfDeaths = " + baseAccount.NumberOfDeaths,
            "UnderCityExists = " + baseAccount.UnderCityExists,
            "CumulativeExperience = " + baseAccount.CumulativeExperience,
        };

        dataBaseManager.UpdateData("PlayerAccountStats", "", PlayerProgressValues);

    }

    public BaseAccount LoadAccountDetails()

    {
        // Creating a local account
        BaseAccount account = new();

        // Getting the status
        ArrayList PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats");

        // Getting the latest max experience
        int CurrentHighestExperience = (int)((ArrayList)dataBaseManager.getArrayData("select max(Experience) from CharacterProgress")[1])[0];

        // Converting it into the properties
        account.AccountName = (string)((ArrayList)PlayerAccountStatsBefore[1])[0];

        if (CurrentHighestExperience > 1)
        {
            account.NumberOfDeaths = 1 + (int)((ArrayList)PlayerAccountStatsBefore[1])[1];
            account.CumulativeExperience = (long)CurrentHighestExperience + (long)((ArrayList)PlayerAccountStatsBefore[1])[4];

            if (CurrentHighestExperience / 1000 > (int)((ArrayList)PlayerAccountStatsBefore[1])[2])
            {
                account.MaximumLevelReached = CurrentHighestExperience / 1000;
            }
            else
            {
                account.MaximumLevelReached = (int)((ArrayList)PlayerAccountStatsBefore[1])[2];
            }
        }
        else
        {
            account.NumberOfDeaths = (int)((ArrayList)PlayerAccountStatsBefore[1])[1];
            account.CumulativeExperience = (long)((ArrayList)PlayerAccountStatsBefore[1])[4];
            account.MaximumLevelReached = (int)((ArrayList)PlayerAccountStatsBefore[1])[2];
        }

        account.UnderCityExists = (int)((ArrayList)PlayerAccountStatsBefore[1])[3];

        Debug.Log("Loading account - playerName:'" + account.AccountName + "'; playerDeaths: " + account.NumberOfDeaths + "; playerMaximumLevel: " + account.MaximumLevelReached + "; playerCityExistence: " + account.UnderCityExists + "; playerCumulativeExperience: " + account.CumulativeExperience);

        return account;
    }

    public BaseCharacter LoadCharacterFromDataBase(int CharacterID)
    {

        BaseCharacter Character = new();

        // DataBase Extract
        ArrayList CharacterStaticChoices = dataBaseManager.getArrayData("select * from CharacterStaticChoices where CharacterID=" + CharacterID);
        ArrayList CharacterStatsModifiers = dataBaseManager.getArrayData("select * from CharacterStatsModifiers where ModifierSource='AllocatedStats' and CharacterID=" + CharacterID);
        ArrayList CharacterStats = dataBaseManager.getArrayData("select * from VIEW_CharacterStats where CharacterID=" + CharacterID);
        ArrayList CharacterProgress = dataBaseManager.getArrayData("select * from CharacterProgress where CharacterID=" + CharacterID);


        //StaticChoices
        Character.characterName = (string)((ArrayList)CharacterStaticChoices[1])[1];
        Character.characterBio = (string)((ArrayList)CharacterStaticChoices[1])[2];
        Character.characterGender = (string)((ArrayList)CharacterStaticChoices[1])[3];

        Character.HistoryChoices.HellCircleChoice = (string)((ArrayList)CharacterStaticChoices[1])[4];
        Character.HistoryChoices.AllegianceChoice = (string)((ArrayList)CharacterStaticChoices[1])[5];
        Character.HistoryChoices.GenusChoice = (string)((ArrayList)CharacterStaticChoices[1])[6];
        Character.HistoryChoices.SpeciesChoice = (string)((ArrayList)CharacterStaticChoices[1])[7];
        Character.HistoryChoices.JobChoice = (string)((ArrayList)CharacterStaticChoices[1])[8];
        Character.HistoryChoices.ImpChoice = (string)((ArrayList)CharacterStaticChoices[1])[9];
        Character.HistoryChoices.OriginChoice = (string)((ArrayList)CharacterStaticChoices[1])[10];
        Character.HistoryChoices.TemperChoice = (string)((ArrayList)CharacterStaticChoices[1])[11];
        Character.HistoryChoices.AstroChoice = (string)((ArrayList)CharacterStaticChoices[1])[12];
        Character.HistoryChoices.AffinityChoice = (string)((ArrayList)CharacterStaticChoices[1])[13];
        Character.HistoryChoices.LeadershipCost = (int)((ArrayList)CharacterStaticChoices[1])[14];

        // StatsModifiers
        Character.AllocatedStatsModifier.Strength = (int)((ArrayList)CharacterStatsModifiers[1])[2];
        Character.AllocatedStatsModifier.Speed = (int)((ArrayList)CharacterStatsModifiers[1])[3];
        Character.AllocatedStatsModifier.Dexterity = (int)((ArrayList)CharacterStatsModifiers[1])[4];
        Character.AllocatedStatsModifier.Embodiment = (int)((ArrayList)CharacterStatsModifiers[1])[5];
        Character.AllocatedStatsModifier.Reflex = (int)((ArrayList)CharacterStatsModifiers[1])[6];
        Character.AllocatedStatsModifier.Resilience = (int)((ArrayList)CharacterStatsModifiers[1])[7];

        Character.AllocatedStatsModifier.Knowledge = (int)((ArrayList)CharacterStatsModifiers[1])[8];
        Character.AllocatedStatsModifier.Elocution = (int)((ArrayList)CharacterStatsModifiers[1])[9];
        Character.AllocatedStatsModifier.Intellect = (int)((ArrayList)CharacterStatsModifiers[1])[10];
        Character.AllocatedStatsModifier.Influence = (int)((ArrayList)CharacterStatsModifiers[1])[11];
        Character.AllocatedStatsModifier.Focus = (int)((ArrayList)CharacterStatsModifiers[1])[12];
        Character.AllocatedStatsModifier.Mockery = (int)((ArrayList)CharacterStatsModifiers[1])[13];

        Character.AllocatedStatsModifier.Malevolent = (int)((ArrayList)CharacterStatsModifiers[1])[14];
        Character.AllocatedStatsModifier.Unmerciful = (int)((ArrayList)CharacterStatsModifiers[1])[15];

        Character.AllocatedStatsModifier.Rage = (int)((ArrayList)CharacterStatsModifiers[1])[16];
        Character.AllocatedStatsModifier.Phase = (int)((ArrayList)CharacterStatsModifiers[1])[17];

        Character.AllocatedStatsModifier.Momentum = (int)((ArrayList)CharacterStatsModifiers[1])[18];
        Character.AllocatedStatsModifier.Balance = (int)((ArrayList)CharacterStatsModifiers[1])[19];
        Character.AllocatedStatsModifier.Chaos = (int)((ArrayList)CharacterStatsModifiers[1])[20];
        Character.AllocatedStatsModifier.Luck = (int)((ArrayList)CharacterStatsModifiers[1])[21];
        Character.AllocatedStatsModifier.Perception = (int)((ArrayList)CharacterStatsModifiers[1])[22];
        Character.AllocatedStatsModifier.Judgement = (int)((ArrayList)CharacterStatsModifiers[1])[23];

        Character.AllocatedStatsModifier.primaryStatPointsToAllocate = (int)((ArrayList)CharacterStatsModifiers[1])[24];
        Character.AllocatedStatsModifier.heroicStatPointsToAllocate = (int)((ArrayList)CharacterStatsModifiers[1])[25];
        Character.AllocatedStatsModifier.secondaryStatPointsToAllocate = (int)((ArrayList)CharacterStatsModifiers[1])[26];


        // Getting the sum
        Character.Strength = (int)((ArrayList)CharacterStats[1])[1];
        Character.Speed = (int)((ArrayList)CharacterStats[1])[2];
        Character.Dexterity = (int)((ArrayList)CharacterStats[1])[3];
        Character.Embodiment = (int)((ArrayList)CharacterStats[1])[4];
        Character.Reflex = (int)((ArrayList)CharacterStats[1])[5];
        Character.Resilience = (int)((ArrayList)CharacterStats[1])[6];

        Character.Knowledge = (int)((ArrayList)CharacterStats[1])[7];
        Character.Elocution = (int)((ArrayList)CharacterStats[1])[8];
        Character.Intellect = (int)((ArrayList)CharacterStats[1])[9];
        Character.Influence = (int)((ArrayList)CharacterStats[1])[10];
        Character.Focus = (int)((ArrayList)CharacterStats[1])[11];
        Character.Mockery = (int)((ArrayList)CharacterStats[1])[12];

        Character.Malevolent = (int)((ArrayList)CharacterStats[1])[13];
        Character.Unmerciful = (int)((ArrayList)CharacterStats[1])[14];

        Character.Rage = (int)((ArrayList)CharacterStats[1])[15];
        Character.Phase = (int)((ArrayList)CharacterStats[1])[16];

        Character.Momentum = (int)((ArrayList)CharacterStats[1])[17];
        Character.Balance = (int)((ArrayList)CharacterStats[1])[18];
        Character.Chaos = (int)((ArrayList)CharacterStats[1])[19];
        Character.Luck = (int)((ArrayList)CharacterStats[1])[20];
        Character.Perception = (int)((ArrayList)CharacterStats[1])[21];
        Character.Judgement = (int)((ArrayList)CharacterStats[1])[22];


        Character.BuildingLevel = 1;
        Character.DiggingLevel = 1;


        return Character;
    }

    public void SavePlayerCityInDataBase(int[,] Map, int[,] Sprite)
    {
        
                
        // Getting the dimensions of the map
        (int MapSizeOnX, int MapSizeOnZ) = LoadMapDimension("UnderCity");

        // Saving row by row
        int z = 0;
        int x = 0;

        for (int i = 0; i < MapSizeOnX; i++)
        {
            for (int j = 0; j < MapSizeOnZ; j++)
            {
                z = j + 1;
                x = i + 1;
                InsertCityData(Map[i, j], Sprite[i, j], x, z);
            }

        }


        // Saving the status of the city
        dataBaseManager.UpdateData("PlayerAccountStats", "", new string[1] { "UnderCityExist = 1" });

    }

    public void UpdateCityData(int Tile, int Sprite, int x, int z)
    {
        dataBaseManager.UpdateData("CityMap", "X=" + x + " and Y=" + z, new string[1] { "TileCode= " + Tile + "and SpriteVariation= " + Sprite });
    }

    public void InsertCityData(int Tile, int Sprite, int x, int z)
    {
        string[] MapRecord = {

            "X = " + x,
            "Y = " + z,
            "TileCode = " + Tile,
            "SpriteVariation = " + Sprite,
        };
        dataBaseManager.InsertData("CityMap", MapRecord);
    }

    public (int[,] TileMap, int[,] SpriteMap) LoadPlayerCityFromDataBase()
    {
        // Getting the dimensions of the map
        (int MapSizeOnX, int MapSizeOnZ) = LoadMapDimension("UnderCity");

        // Getting the map details
        ArrayList PlayerCity = dataBaseManager.getArrayData("select * from CityMap");

        int[,] TileMap = new int[MapSizeOnX, MapSizeOnZ];
        int[,] SpriteMap = new int[MapSizeOnX, MapSizeOnZ];

        for (int i = 0; i < MapSizeOnX; i++)
        {
            for (int j = 0; j < MapSizeOnZ; j++)
            {
                TileMap[i, j] =     (int)((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[3];
                SpriteMap[i, j] =   (int)((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[4];
            }
        }

        return (TileMap, SpriteMap);

    }

    public (int MapSizeOnX, int MapSizeOnZ) LoadMapDimension(string MapName)
    {

        // Getting the dimensions of the map
        ArrayList RefCitySize = dataBaseManager.getArrayData("select * from REF_TerrainSpecificities where MapName = '" + MapName + "'");
        int MapSizeOnX = (int)((ArrayList)RefCitySize[0])[2];
        int MapSizeOnZ = (int)((ArrayList)RefCitySize[0])[3];

        return (MapSizeOnX, MapSizeOnZ);
    }


}
