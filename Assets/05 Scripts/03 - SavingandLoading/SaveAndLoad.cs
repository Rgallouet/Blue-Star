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

            "'" + character.characterName + "' as Name",
            "'" + character.characterBio + "' as Bio",
            "'" + character.characterGender + "' as Gender",

            "'" + character.HistoryChoices.HellCircleChoice + "' as HellCircleChoice",
            "'" + character.HistoryChoices.AllegianceChoice + "' as AllegianceChoice",
            "'" + character.HistoryChoices.SocialChoice + "' as SocialChoice",
            "'" + character.HistoryChoices.JobChoice + "' as JobChoice",
            "'" + character.HistoryChoices.ImpChoice + "' as ImpChoice",
            "'" + character.HistoryChoices.OriginChoice + "' as OriginChoice",
            "'" + character.HistoryChoices.TemperChoice + "' as TemperChoice",
            "'" + character.HistoryChoices.AstroChoice + "' as AstroChoice",
            "'" + character.HistoryChoices.AffinityChoice + "' as AffinityChoice",

            character.HistoryChoices.LeadershipCost + " as LeadershipCost" ,

            character.DemonPartChoices.HeadChoiceID + " as HeadChoiceID" ,
            character.DemonPartChoices.HeadQuality + " as HeadQuality" ,
            character.DemonPartChoices.BodyChoiceID + " as BodyChoiceID" ,
            character.DemonPartChoices.BodyQuality + " as BodyQuality" ,
            character.DemonPartChoices.RightUpperArmChoiceID + " as RightUpperArmChoiceID" ,
            character.DemonPartChoices.RightUpperArmQuality + " as RightUpperArmQuality" ,
            character.DemonPartChoices.RightLowerArmChoiceID + " as RightLowerArmChoiceID" ,
            character.DemonPartChoices.RightLowerArmQuality + " as RightLowerArmQuality" ,
            character.DemonPartChoices.RightFistChoiceID + " as RightFistChoiceID" ,
            character.DemonPartChoices.RightFistQuality + " as RightFistQuality" ,
            character.DemonPartChoices.RightLegChoiceID + " as RightLegChoiceID" ,
            character.DemonPartChoices.RightLegQuality + " as RightLegQuality" ,
            character.DemonPartChoices.RightFootChoiceID + " as RightFootChoiceID" ,
            character.DemonPartChoices.RightFootQuality + " as RightFootQuality" ,
            character.DemonPartChoices.LeftUpperArmChoiceID + " as LeftUpperArmChoiceID" ,
            character.DemonPartChoices.LeftUpperArmQuality + " as LeftUpperArmQuality" ,
            character.DemonPartChoices.LeftLowerArmChoiceID + " as LeftLowerArmChoiceID" ,
            character.DemonPartChoices.LeftLowerArmQuality + " as LeftLowerArmQuality" ,
            character.DemonPartChoices.LeftFistChoiceID + " as LeftFistChoiceID" ,
            character.DemonPartChoices.LeftFistQuality + " as LeftFistQuality" ,
            character.DemonPartChoices.LeftLegChoiceID + " as LeftLegChoiceID" ,
            character.DemonPartChoices.LeftLegQuality + " as LeftLegQuality" ,
            character.DemonPartChoices.LeftFootChoiceID + " as LeftFootChoiceID" ,
            character.DemonPartChoices.LeftFootQuality+ " as LeftFootQuality" ,

    };

        // updating the static choices
        dataBaseManager.InsertOrUpdateFullData("CharacterStaticChoices", "CharacterID", character.characterID, CharacterStaticChoicesValues);


        // Cleaning the records
        dataBaseManager.RunQuery(
            "DELETE FROM CharacterStatsModifiers where CharacterID=" + character.characterID + " and ModifierSource in ('Baseline','HistoryChoices','DemonPartsChoices') ;");

        // generating the baseline related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CharacterStatsModifiers Select " + character.characterID + " as CharacterID, 'Baseline' as ModifierSource," +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Strength, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Speed, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Dexterity, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Embodiment, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Reflex, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Resilience, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Knowledge, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Elocution, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Intellect, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Influence, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Focus, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Mockery, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Malevolent, " +
            (50 + 25 * character.HistoryChoices.LeadershipCost) + " as Unmerciful, " +

            10 + " as Rage, " +
            10 + " as Phase, " +

            100 + " as Momentum, " +
            100 + " as Balance, " +
            100 + " as Chaos, " +
            100 + " as Luck, " +
            100 + " as Perception, " +
            100 + " as Judgement, " +

            0 + " as PrimaryStatsToAllocate, " +
            0 + " as SecondaryStatsToAllocate, " +
            0 + " as HeroicStatsToAllocate;");



        // generating the choices related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CharacterStatsModifiers Select " + character.characterID + " as CharacterID, 'HistoryChoices' as ModifierSource, sum(Strength) as Strength, sum(Speed) as Speed, sum(Dexterity) as Dexterity, sum(Embodiment) as Embodiment, sum(Reflex) as Reflex, sum(Resilience) as Resilience, " +
            "sum(Knowledge) as Knowledge, sum(Elocution) as Elocution, sum(Intellect) as Intellect, sum(Influence) as Influence, sum(Focus) as Focus, sum(Mockery) as Mockery, " +
            "sum(Malevolent) as Malevolent, sum(Unmerciful) as Unmerciful, " +
            "sum(Rage) as Rage, sum(Phase) as Phase, " +
            "sum(Momentum) as Momentum, sum(Balance) as Balance, sum(Chaos) as Chaos, sum(Luck) as Luck, sum(Perception) as Perception, sum(Judgement) as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from REF_HistoryChoicesStatistics " +
            "where Id in ('"
            + character.HistoryChoices.HellCircleChoice + "','"
            + character.HistoryChoices.AllegianceChoice + "','"
            + character.HistoryChoices.SocialChoice + "','"
            + character.HistoryChoices.JobChoice + "','"
            + character.HistoryChoices.ImpChoice + "','"
            + character.HistoryChoices.OriginChoice + "','"
            + character.HistoryChoices.TemperChoice + "','"
            + character.HistoryChoices.AstroChoice + "','"
            + character.HistoryChoices.AffinityChoice
            + "');");

        // generating the demon parts related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CharacterStatsModifiers Select " + character.characterID + " as CharacterID, 'DemonPartsChoices' as ModifierSource, sum(Strength) as Strength, sum(Speed) as Speed, sum(Dexterity) as Dexterity, sum(Embodiment) as Embodiment, sum(Reflex) as Reflex, sum(Resilience) as Resilience, " +
            "sum(Knowledge) as Knowledge, sum(Elocution) as Elocution, sum(Intellect) as Intellect, sum(Influence) as Influence, sum(Focus) as Focus, sum(Mockery) as Mockery, " +
            "sum(Malevolent) as Malevolent, sum(Unmerciful) as Unmerciful, " +
            "sum(Rage) as Rage, sum(Phase) as Phase, " +
            "sum(Momentum) as Momentum, sum(Balance) as Balance, sum(Chaos) as Chaos, sum(Luck) as Luck, sum(Perception) as Perception, sum(Judgement) as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from REF_DemonPartsStatistics where " +
            " (BodyPart='Head' and Id= " +          character.DemonPartChoices.HeadChoiceID + " and Quality=" +             character.DemonPartChoices.HeadQuality + ") or " +
            " (BodyPart='Body' and Id= " +          character.DemonPartChoices.BodyChoiceID + " and Quality=" +             character.DemonPartChoices.BodyQuality + ") or " +
            " (BodyPart='RightUpperArm' and Id= " + character.DemonPartChoices.RightUpperArmChoiceID + " and Quality=" +    character.DemonPartChoices.RightUpperArmQuality + ") or " +
            " (BodyPart='RightLowerArm' and Id= " + character.DemonPartChoices.RightLowerArmChoiceID + " and Quality=" +    character.DemonPartChoices.RightLowerArmQuality + ") or " +
            " (BodyPart='RightFist' and Id= " +     character.DemonPartChoices.RightFistChoiceID + " and Quality=" +        character.DemonPartChoices.RightFistQuality + ") or " +
            " (BodyPart='RightLeg' and Id= " +      character.DemonPartChoices.RightLegChoiceID + " and Quality=" +         character.DemonPartChoices.RightLegQuality + ") or " +
            " (BodyPart='RightFoot' and Id= " +     character.DemonPartChoices.RightFootChoiceID + " and Quality=" +        character.DemonPartChoices.RightFootQuality + ") or " +
            " (BodyPart='LeftUpperArm' and Id= " +  character.DemonPartChoices.LeftUpperArmChoiceID + " and Quality=" +     character.DemonPartChoices.LeftUpperArmQuality + ") or " +
            " (BodyPart='LeftLowerArm' and Id= " +  character.DemonPartChoices.LeftLowerArmChoiceID + " and Quality=" +     character.DemonPartChoices.LeftLowerArmQuality + ") or " +
            " (BodyPart='LeftFist' and Id= " +      character.DemonPartChoices.LeftFistChoiceID + " and Quality=" +         character.DemonPartChoices.LeftFistQuality + ") or " +
            " (BodyPart='LeftLeg' and Id= " +       character.DemonPartChoices.LeftLegChoiceID + " and Quality=" +          character.DemonPartChoices.LeftLegQuality + ") or " +
            " (BodyPart='LeftFoot' and Id= " +      character.DemonPartChoices.LeftFootChoiceID + " and Quality=" +         character.DemonPartChoices.LeftFootQuality + "); " );

    }

    public void SaveCharacterStatAllocationInDataBase(BaseCharacter character)
    {

        // Cleaning the previous stat allocation
        dataBaseManager.RunQuery(
            "DELETE FROM CharacterStatsModifiers where CharacterID=" + character.characterID + " and ModifierSource in ('AllocatedStats') ;");


        // generating the baseline related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CharacterStatsModifiers Select " + character.characterID + " as CharacterID, 'AllocatedStats' as ModifierSource," +

            character.AllocatedStatsModifier.Strength + " as Strength," +
            character.AllocatedStatsModifier.Speed + " as Speed," +
            character.AllocatedStatsModifier.Dexterity + " as Dexterity," +
            character.AllocatedStatsModifier.Embodiment + " as Embodiment," +
            character.AllocatedStatsModifier.Reflex + " as Reflex," +
            character.AllocatedStatsModifier.Resilience + " as Resilience," +
            character.AllocatedStatsModifier.Knowledge + " as Knowledge," +
            character.AllocatedStatsModifier.Elocution + " as Elocution," +
            character.AllocatedStatsModifier.Intellect + " as Intellect," +
            character.AllocatedStatsModifier.Influence + " as Influence," +
            character.AllocatedStatsModifier.Focus + " as Focus," +
            character.AllocatedStatsModifier.Mockery + " as Mockery," +
            character.AllocatedStatsModifier.Malevolent + " as Malevolent," +
            character.AllocatedStatsModifier.Unmerciful + " as Unmerciful," +
            character.AllocatedStatsModifier.Rage + " as Rage," +
            character.AllocatedStatsModifier.Phase + " as Phase," +
            character.AllocatedStatsModifier.Momentum + " as Momentum," +
            character.AllocatedStatsModifier.Balance + " as Balance," +
            character.AllocatedStatsModifier.Chaos + " as Chaos," +
            character.AllocatedStatsModifier.Luck + " as Luck," +
            character.AllocatedStatsModifier.Perception + " as Perception," +
            character.AllocatedStatsModifier.Judgement + " as Judgement," +
            character.AllocatedStatsModifier.primaryStatPointsToAllocate + " as PrimaryStatsToAllocate," +
            character.AllocatedStatsModifier.heroicStatPointsToAllocate + " as SecondaryStatsToAllocate," +
            character.AllocatedStatsModifier.secondaryStatPointsToAllocate + " as HeroicStatsToAllocate;");


    }

    public void SaveCharacterInDataBase(BaseCharacter character)
    {

        // Saving the allocated points
        string[] CharacterValues = { character.Experience + " as Experience" };

        dataBaseManager.InsertOrUpdateFullData("CharacterProgress", "CharacterID" , character.characterID, CharacterValues);

    }

    public void SaveAccountDetails(BaseAccount baseAccount)

    {

        // Cleaning the previous account stats
        dataBaseManager.RunQuery(
            "DELETE FROM PlayerAccountStats;");


        // Resetting the progress of the hero
        dataBaseManager.RunQuery(
            "INSERT into PlayerAccountStats Select '" +
            baseAccount.AccountName + "' as AccountName, " +
            baseAccount.MaximumLevelReached + " as MaximumLevelReached, " +
            baseAccount.NumberOfDeaths + " as NumberOfDeaths, " +
            baseAccount.CurrentCityRegion + " as CurrentCityTier, " +
            baseAccount.CumulativeExperience + " as CumulativeExperience ;");

    }

    public void LoadAccountDetails(BaseAccount baseAccount)

    {

        // Getting the status
        ArrayList PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats");

        // Getting the latest max experience
        long CurrentHighestExperience = (long)((ArrayList)dataBaseManager.getArrayData("select max(Experience) from CharacterProgress")[1])[0];

        // Converting it into the properties
        baseAccount.AccountName = (string)((ArrayList)PlayerAccountStatsBefore[1])[0];

        if (CurrentHighestExperience > 1)
        {
            baseAccount.NumberOfDeaths = 1 + (int)((ArrayList)PlayerAccountStatsBefore[1])[1];
            baseAccount.CumulativeExperience = CurrentHighestExperience + (long)((ArrayList)PlayerAccountStatsBefore[1])[4];

            if (CurrentHighestExperience / 1000 > (int)((ArrayList)PlayerAccountStatsBefore[1])[2])
            {
                baseAccount.MaximumLevelReached = (int)(CurrentHighestExperience / 1000);
            }
            else
            {
                baseAccount.MaximumLevelReached = (int)((ArrayList)PlayerAccountStatsBefore[1])[2];
            }
        }
        else
        {
            baseAccount.NumberOfDeaths = (int)((ArrayList)PlayerAccountStatsBefore[1])[1];
            baseAccount.CumulativeExperience = (long)((ArrayList)PlayerAccountStatsBefore[1])[4];
            baseAccount.MaximumLevelReached = (int)((ArrayList)PlayerAccountStatsBefore[1])[2];
        }

        baseAccount.CurrentCityRegion = (int)((ArrayList)PlayerAccountStatsBefore[1])[3];

        Debug.Log("Loading account - playerName:'" + baseAccount.AccountName + "'; playerDeaths: " + baseAccount.NumberOfDeaths + "; playerMaximumLevel: " + baseAccount.MaximumLevelReached + "; playerCityExistence: " + baseAccount.CurrentCityRegion + "; playerCumulativeExperience: " + baseAccount.CumulativeExperience);

    }

    public BaseCharacter LoadCharacterFromDataBase(long CharacterID)
    {
        //Debug.Log("Starting to load Character " + CharacterID);
        BaseCharacter Character = new();

        Character.characterID = CharacterID;

        // DataBase Extract
        ArrayList CharacterStaticChoices = dataBaseManager.getArrayData("select * from CharacterStaticChoices where CharacterID=" + CharacterID);
        ArrayList CharacterStatsModifiers = dataBaseManager.getArrayData("select * from CharacterStatsModifiers where ModifierSource='AllocatedStats' and CharacterID=" + CharacterID);
        ArrayList CharacterStats = dataBaseManager.getArrayData("select * from VIEW_CharacterStats where CharacterID=" + CharacterID);
        ArrayList CharacterProgress = dataBaseManager.getArrayData("select * from CharacterProgress where CharacterID=" + CharacterID);

        //Debug.Log("Loaded tables");


        //StaticChoices
        Character.characterName = (string)((ArrayList)CharacterStaticChoices[1])[1];
        Character.characterBio = (string)((ArrayList)CharacterStaticChoices[1])[2];
        Character.characterGender = (string)((ArrayList)CharacterStaticChoices[1])[3];

        //Debug.Log("Names and Gender are ok instanciated");

        Character.HistoryChoices.HellCircleChoice = (string)((ArrayList)CharacterStaticChoices[1])[4];
        Character.HistoryChoices.AllegianceChoice = (string)((ArrayList)CharacterStaticChoices[1])[5];
        Character.HistoryChoices.SocialChoice = (string)((ArrayList)CharacterStaticChoices[1])[6];
        Character.HistoryChoices.JobChoice = (string)((ArrayList)CharacterStaticChoices[1])[7];
        Character.HistoryChoices.ImpChoice = (string)((ArrayList)CharacterStaticChoices[1])[8];
        Character.HistoryChoices.OriginChoice = (string)((ArrayList)CharacterStaticChoices[1])[9];
        Character.HistoryChoices.TemperChoice = (string)((ArrayList)CharacterStaticChoices[1])[10];
        Character.HistoryChoices.AstroChoice = (string)((ArrayList)CharacterStaticChoices[1])[11];
        Character.HistoryChoices.AffinityChoice = (string)((ArrayList)CharacterStaticChoices[1])[12];
        Character.HistoryChoices.LeadershipCost = (int)((ArrayList)CharacterStaticChoices[1])[13];

        //Debug.Log("History choices are instanciated");

        Character.DemonPartChoices.HeadChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[14];
        Character.DemonPartChoices.HeadQuality = (int)((ArrayList)CharacterStaticChoices[1])[15];
        Character.DemonPartChoices.BodyChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[16];
        Character.DemonPartChoices.BodyQuality = (int)((ArrayList)CharacterStaticChoices[1])[17];
        Character.DemonPartChoices.RightUpperArmChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[18];
        Character.DemonPartChoices.RightUpperArmQuality = (int)((ArrayList)CharacterStaticChoices[1])[19];
        Character.DemonPartChoices.RightLowerArmChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[20];
        Character.DemonPartChoices.RightLowerArmQuality = (int)((ArrayList)CharacterStaticChoices[1])[21];
        Character.DemonPartChoices.RightFistChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[22];
        Character.DemonPartChoices.RightFistQuality = (int)((ArrayList)CharacterStaticChoices[1])[23];
        Character.DemonPartChoices.RightLegChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[24];
        Character.DemonPartChoices.RightLegQuality = (int)((ArrayList)CharacterStaticChoices[1])[25];
        Character.DemonPartChoices.RightFootChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[26];
        Character.DemonPartChoices.RightFootQuality = (int)((ArrayList)CharacterStaticChoices[1])[27];
        Character.DemonPartChoices.LeftUpperArmChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[28];
        Character.DemonPartChoices.LeftUpperArmQuality = (int)((ArrayList)CharacterStaticChoices[1])[29];
        Character.DemonPartChoices.LeftLowerArmChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[30];
        Character.DemonPartChoices.LeftLowerArmQuality = (int)((ArrayList)CharacterStaticChoices[1])[31];
        Character.DemonPartChoices.LeftFistChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[32];
        Character.DemonPartChoices.LeftFistQuality = (int)((ArrayList)CharacterStaticChoices[1])[33];
        Character.DemonPartChoices.LeftLegChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[34];
        Character.DemonPartChoices.LeftLegQuality = (int)((ArrayList)CharacterStaticChoices[1])[35];
        Character.DemonPartChoices.LeftFootChoiceID = (int)((ArrayList)CharacterStaticChoices[1])[36];
        Character.DemonPartChoices.LeftFootQuality = (int)((ArrayList)CharacterStaticChoices[1])[37];

        //Debug.Log("Demon Part Choices are instanciated");

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

        //Debug.Log("Allocated Stats Modifiers are instanciated");



        // Getting the sum
        Character.Strength = (int)(long)((ArrayList)CharacterStats[1])[1];
        Character.Speed = (int)(long)((ArrayList)CharacterStats[1])[2];
        Character.Dexterity = (int)(long)((ArrayList)CharacterStats[1])[3];
        Character.Embodiment = (int)(long)((ArrayList)CharacterStats[1])[4];
        Character.Reflex = (int)(long)((ArrayList)CharacterStats[1])[5];
        Character.Resilience = (int)(long)((ArrayList)CharacterStats[1])[6];

        Character.Knowledge = (int)(long)((ArrayList)CharacterStats[1])[7];
        Character.Elocution = (int)(long)((ArrayList)CharacterStats[1])[8];
        Character.Intellect = (int)(long)((ArrayList)CharacterStats[1])[9];
        Character.Influence = (int)(long)((ArrayList)CharacterStats[1])[10];
        Character.Focus = (int)(long)((ArrayList)CharacterStats[1])[11];
        Character.Mockery = (int)(long)((ArrayList)CharacterStats[1])[12];

        Character.Malevolent = (int)(long)((ArrayList)CharacterStats[1])[13];
        Character.Unmerciful = (int)(long)((ArrayList)CharacterStats[1])[14];

        Character.Rage = (int)(long)((ArrayList)CharacterStats[1])[15];
        Character.Phase = (int)(long)((ArrayList)CharacterStats[1])[16];

        Character.Momentum = (int)(long)((ArrayList)CharacterStats[1])[17];
        Character.Balance = (int)(long)((ArrayList)CharacterStats[1])[18];
        Character.Chaos = (int)(long)((ArrayList)CharacterStats[1])[19];
        Character.Luck = (int)(long)((ArrayList)CharacterStats[1])[20];
        Character.Perception = (int)(long)((ArrayList)CharacterStats[1])[21];
        Character.Judgement = (int)(long)((ArrayList)CharacterStats[1])[22];

        //Debug.Log("Total Stats are instanciated");

        Character.BuildingLevel = 1;
        Character.DiggingLevel = 1;

        Character.Experience = (long)((ArrayList)CharacterProgress[1])[1];

        //Debug.Log("Experience is instanciated");

        //Debug.Log("Finish");

        return Character;
    }

    public void SavePlayerCityInDataBase(int[,] Map, int[,] Sprite)
    {
        
                
        // Getting the dimensions of the map
        (int MapSizeOnX, int MapSizeOnZ) = LoadMapDimension("UnderCity");

        // Saving row by row
        for (int i = 0; i < MapSizeOnX; i++)
        {
            string query = "INSERT into CityMap VALUES ";

            for (int j = 0; j < MapSizeOnZ-1; j++)
            {
                query += "(" + (i + 1) + "," + (j + 1) + "," + Map[i, j] + "," + Sprite[i, j] + "),";
            }

            // Saving the status of the city by batch of X size dimension
            dataBaseManager.RunQuery(query + "(" + (i + 1) + "," + (MapSizeOnZ - 1) + "," + Map[i, MapSizeOnZ - 1] + "," + Sprite[i, MapSizeOnZ - 1] + ")");

        }

        // Saving the status of the city
        dataBaseManager.RunQuery("UPDATE PlayerAccountStats SET CurrentCityRegion = 1;");

    }

    public void UpdateCityData(int Tile, int Sprite, int x, int z)
    {
        // cleaning any existing record
        dataBaseManager.RunQuery("DELETE FROM CityMap WHERE " +"X=" + x +" and Y=" + z +";");

        // creating the x and z record
        dataBaseManager.RunQuery("INSERT INTO CityMap VALUES (" +x + " , " + z + " , " + Tile + " , " + Sprite + " );");

    }

    public (int MapSizeOnX, int MapSizeOnZ, int[,] TileMap, int[,] SpriteMap) LoadPlayerCityFromDataBase()
    {
        // Getting the dimensions of the map
        (int MapSizeOnX, int MapSizeOnZ) = LoadMapDimension("UnderCity");
        //Debug.Log("Start loading map looping through " + MapSizeOnX + " in X and " + MapSizeOnZ + " in Z");

        // Getting the map details
        ArrayList PlayerCity = dataBaseManager.getArrayData("select * from CityMap");

        int[,] TileMap = new int[MapSizeOnX, MapSizeOnZ];
        int[,] SpriteMap = new int[MapSizeOnX, MapSizeOnZ];

        for (int i = 0; i < MapSizeOnX; i++)
        {
            for (int j = 0; j < MapSizeOnZ; j++)
            {
                TileMap[i, j] =     (int)((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[2];
                SpriteMap[i, j] =   (int)((ArrayList)PlayerCity[(i + 1) + (j * MapSizeOnX)])[3];
                //Debug.Log("Loading tile and sprite at x="+(i + 1) + " and z="+(j + 1) +" being tilecode="+ TileMap[i, j]);
            }
        }

        return (MapSizeOnX, MapSizeOnZ, TileMap, SpriteMap);

    }

    public (int MapSizeOnX, int MapSizeOnZ) LoadMapDimension(string MapName)
    {

        // Getting the dimensions of the map
        ArrayList RefCitySize = dataBaseManager.getArrayData("select * from REF_TerrainSpecificities where MapName = '" + MapName + "'");
        int MapSizeOnX = (int)((ArrayList)RefCitySize[1])[1];
        int MapSizeOnZ = (int)((ArrayList)RefCitySize[1])[2];

        return (MapSizeOnX, MapSizeOnZ);
    }


}
