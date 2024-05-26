using UnityEngine;
using System.Collections;
using System;

public class SaveAndLoad : MonoBehaviour
{



    public DataBaseManager dataBaseManager;


    public void ResetAllCharactersInDataBase()
    {

        dataBaseManager.RunQuery("DELETE FROM CHARACTER_StatModifiers;");
        dataBaseManager.RunQuery("DELETE FROM CHARACTER_StaticChoices;");
        dataBaseManager.RunQuery("DELETE FROM CHARACTER_Progress;");

    }

    public void ResetCityInDataBase()
    {

        dataBaseManager.RunQuery("DELETE FROM ACCOUNT_CityMap;");

    }

    public void ResetResourcesInDataBase()
    {

        dataBaseManager.RunQuery("UPDATE ACCOUNT_Ressources SET Quantity=0;");

    }

    public void SaveCharacterCreationChoicesInDataBase(BaseCharacter character)
    {

        // Saving the detailed choices
        string[] CHARACTER_StaticChoicesValues = {

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
        dataBaseManager.InsertOrUpdateFullData("CHARACTER_StaticChoices", "CharacterID", character.characterID, CHARACTER_StaticChoicesValues);


        // Cleaning the records
        dataBaseManager.RunQuery(
            "DELETE FROM CHARACTER_StatModifiers where CharacterID=" + character.characterID + " and ModifierSource in ('Baseline','HistoryChoices','DemonPartsChoices') ;");

        // generating the baseline related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CHARACTER_StatModifiers Select " + character.characterID + " as CharacterID, 'Baseline' as ModifierSource," +
            75 + " as Strength, " +
            100 + " as Speed, " +
            75 + " as Dexterity, " +
            75 + " as Endurance, " +
            75 + " as Reflex, " +
            75 + " as Resilience, " +
            75 + " as Knowledge, " +
            75 + " as Elocution, " +
            75 + " as Intellect, " +
            75 + " as Influence, " +
            75 + " as Focus, " +
            75 + " as Mockery, " +
            75 + " as Malevolent, " +
            75 + " as Unmerciful, " +

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
            "INSERT into CHARACTER_StatModifiers Select " + character.characterID + " as CharacterID, 'HistoryChoices' as ModifierSource, sum(Strength) as Strength, sum(Speed) as Speed, sum(Dexterity) as Dexterity, sum(Endurance) as Endurance, sum(Reflex) as Reflex, sum(Resilience) as Resilience, " +
            "sum(Knowledge) as Knowledge, sum(Elocution) as Elocution, sum(Intellect) as Intellect, sum(Influence) as Influence, sum(Focus) as Focus, sum(Mockery) as Mockery, " +
            "sum(Malevolent) as Malevolent, sum(Unmerciful) as Unmerciful, " +
            "sum(Rage) as Rage, sum(Phase) as Phase, " +
            "sum(Momentum) as Momentum, sum(Balance) as Balance, sum(Chaos) as Chaos, sum(Luck) as Luck, sum(Perception) as Perception, sum(Judgement) as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from REF_HistoryChoicesStatistics " +
            "where ChoiceId in ('"
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
            "INSERT into CHARACTER_StatModifiers Select " + character.characterID + " as CharacterID, 'DemonPartsChoices' as ModifierSource, sum(Strength) as Strength, sum(Speed) as Speed, sum(Dexterity) as Dexterity, sum(Endurance) as Endurance, sum(Reflex) as Reflex, sum(Resilience) as Resilience, " +
            "sum(Knowledge) as Knowledge, sum(Elocution) as Elocution, sum(Intellect) as Intellect, sum(Influence) as Influence, sum(Focus) as Focus, sum(Mockery) as Mockery, " +
            "0 as Malevolent, 0 as Unmerciful, sum(Rage) as Rage, sum(Phase) as Phase, 0 as Momentum, 0 as Balance, 0 as Chaos, 0 as Luck, 0 as Perception, 0 as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from VIEW_DemonPartsStatisticsWithQuality where " +
            " (BodyPart='Head' and CharacterTypeId= " +          character.DemonPartChoices.HeadChoiceID + " and QualityId=" +             character.DemonPartChoices.HeadQuality + ") or " +
            " (BodyPart='Body' and CharacterTypeId= " +          character.DemonPartChoices.BodyChoiceID + " and QualityId=" +             character.DemonPartChoices.BodyQuality + ") or " +
            " (BodyPart='RightUpperArm' and CharacterTypeId= " + character.DemonPartChoices.RightUpperArmChoiceID + " and QualityId=" +    character.DemonPartChoices.RightUpperArmQuality + ") or " +
            " (BodyPart='RightLowerArm' and CharacterTypeId= " + character.DemonPartChoices.RightLowerArmChoiceID + " and QualityId=" +    character.DemonPartChoices.RightLowerArmQuality + ") or " +
            " (BodyPart='RightFist' and CharacterTypeId= " +     character.DemonPartChoices.RightFistChoiceID + " and QualityId=" +        character.DemonPartChoices.RightFistQuality + ") or " +
            " (BodyPart='RightLeg' and CharacterTypeId= " +      character.DemonPartChoices.RightLegChoiceID + " and QualityId=" +         character.DemonPartChoices.RightLegQuality + ") or " +
            " (BodyPart='RightFoot' and CharacterTypeId= " +     character.DemonPartChoices.RightFootChoiceID + " and QualityId=" +        character.DemonPartChoices.RightFootQuality + ") or " +
            " (BodyPart='LeftUpperArm' and CharacterTypeId= " +  character.DemonPartChoices.LeftUpperArmChoiceID + " and QualityId=" +     character.DemonPartChoices.LeftUpperArmQuality + ") or " +
            " (BodyPart='LeftLowerArm' and CharacterTypeId= " +  character.DemonPartChoices.LeftLowerArmChoiceID + " and QualityId=" +     character.DemonPartChoices.LeftLowerArmQuality + ") or " +
            " (BodyPart='LeftFist' and CharacterTypeId= " +      character.DemonPartChoices.LeftFistChoiceID + " and QualityId=" +         character.DemonPartChoices.LeftFistQuality + ") or " +
            " (BodyPart='LeftLeg' and CharacterTypeId= " +       character.DemonPartChoices.LeftLegChoiceID + " and QualityId=" +          character.DemonPartChoices.LeftLegQuality + ") or " +
            " (BodyPart='LeftFoot' and CharacterTypeId= " +      character.DemonPartChoices.LeftFootChoiceID + " and QualityId=" +         character.DemonPartChoices.LeftFootQuality + "); " );



        // generating the Leadership cost stats increase
        dataBaseManager.RunQuery(
            "INSERT into CHARACTER_StatModifiers Select " + character.characterID + " as CharacterID, 'LeadershipCost' as ModifierSource, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Strength) as INTEGER) as Strength, " +
            "0 as Speed, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Dexterity) as INTEGER) as Dexterity, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Endurance) as INTEGER) as Endurance, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Reflex) as INTEGER) as Reflex, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Resilience) as INTEGER) as Resilience, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Knowledge) as INTEGER) as Knowledge, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Elocution) as INTEGER) as Elocution, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Intellect) as INTEGER) as Intellect, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Influence) as INTEGER) as Influence, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Focus) as INTEGER) as Focus, " +
            "CAST(" + (character.HistoryChoices.LeadershipCost - 1) + "*0.1*sum(Mockery) as INTEGER) as Mockery, " +
            "0 as Malevolent, 0 as Unmerciful, 0 as Rage, 0 as Phase, 0 as Momentum, 0 as Balance, 0 as Chaos, 0 as Luck, 0 as Perception, 0 as Judgement, 0 as PrimaryStatsToAllocate, 0 as SecondaryStatsToAllocate, 0 as HeroicStatsToAllocate  " +
            "from CHARACTER_StatModifiers where CharacterID=" + character.characterID + " and ModifierSource in ('Baseline','HistoryChoices','DemonPartsChoices'); ");


    }

    public void SaveCharacterStatAllocationInDataBase(BaseCharacter character)
    {

        // Cleaning the previous stat allocation
        dataBaseManager.RunQuery(
            "DELETE FROM CHARACTER_StatModifiers where CharacterID=" + character.characterID + " and ModifierSource in ('AllocatedStats') ;");


        // generating the baseline related stat modifier line
        dataBaseManager.RunQuery(
            "INSERT into CHARACTER_StatModifiers Select " + character.characterID + " as CharacterID, 'AllocatedStats' as ModifierSource," +

            character.AllocatedStatsModifier.Strength + " as Strength," +
            character.AllocatedStatsModifier.Speed + " as Speed," +
            character.AllocatedStatsModifier.Dexterity + " as Dexterity," +
            character.AllocatedStatsModifier.Endurance + " as Endurance," +
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

        dataBaseManager.InsertOrUpdateFullData("CHARACTER_Progress", "CharacterID" , character.characterID, CharacterValues);

    }

    public void SaveAccountDetails(BaseAccount baseAccount)

    {

        // Cleaning the previous account stats
        dataBaseManager.RunQuery(
            "DELETE FROM ACCOUNT_MenuStatistics;");


        // Resetting the progress of the hero
        dataBaseManager.RunQuery(
            "INSERT into ACCOUNT_MenuStatistics Select '" +
            baseAccount.AccountName + "' as AccountName, " +
            baseAccount.MaximumLevelReached + " as MaximumLevelReached, " +
            baseAccount.NumberOfDeaths + " as NumberOfDeaths, " +
            baseAccount.CurrentCityTier + " as CurrentCityTier, " +
            baseAccount.CumulativeExperience + " as CumulativeExperience ;");

    }

    public void LoadAccountDetails(BaseAccount baseAccount)

    {

        // Getting the status
        ArrayList ACCOUNT_MenuStatisticsBefore = dataBaseManager.getArrayData("select * from ACCOUNT_MenuStatistics");

        // Getting the latest max experience
        long CurrentHighestExperience = (long)((ArrayList)dataBaseManager.getArrayData("select max(Experience) from CHARACTER_Progress")[1])[0];

        // Converting it into the properties
        baseAccount.AccountName = (string)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[0];

        if (CurrentHighestExperience > 1)
        {
            baseAccount.NumberOfDeaths = 1 + (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[1];
            baseAccount.CumulativeExperience = CurrentHighestExperience + (long)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[4];

            if (CurrentHighestExperience / 1000 > (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[2])
            {
                baseAccount.MaximumLevelReached = (int)(CurrentHighestExperience / 1000);
            }
            else
            {
                baseAccount.MaximumLevelReached = (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[2];
            }
        }
        else
        {
            baseAccount.NumberOfDeaths = (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[1];
            baseAccount.CumulativeExperience = (long)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[4];
            baseAccount.MaximumLevelReached = (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[2];
        }

        baseAccount.CurrentCityTier = (int)((ArrayList)ACCOUNT_MenuStatisticsBefore[1])[3];

        Debug.Log("Loading account - playerName:'" + baseAccount.AccountName + "'; playerDeaths: " + baseAccount.NumberOfDeaths + "; playerMaximumLevel: " + baseAccount.MaximumLevelReached + "; playerCityExistence: " + baseAccount.CurrentCityTier + "; playerCumulativeExperience: " + baseAccount.CumulativeExperience);

    }

    public BaseCharacter LoadCharacterFromDataBase(long CharacterID)
    {
        //Debug.Log("Starting to load Character " + CharacterID);
        BaseCharacter Character = new();

        Character.characterID = CharacterID;

        // DataBase Extract
        ArrayList CHARACTER_StaticChoices = dataBaseManager.getArrayData("select * from CHARACTER_StaticChoices where CharacterID=" + CharacterID);
        ArrayList CHARACTER_StatModifiers = dataBaseManager.getArrayData("select * from CHARACTER_StatModifiers where ModifierSource='AllocatedStats' and CharacterID=" + CharacterID);
        ArrayList CharacterStats = dataBaseManager.getArrayData("select * from VIEW_CharacterStats where CharacterID=" + CharacterID);
        ArrayList CHARACTER_Progress = dataBaseManager.getArrayData("select * from CHARACTER_Progress where CharacterID=" + CharacterID);

        //Debug.Log("Loaded tables");


        //StaticChoices
        Character.characterName = (string)((ArrayList)CHARACTER_StaticChoices[1])[1];
        Character.characterBio = (string)((ArrayList)CHARACTER_StaticChoices[1])[2];
        Character.characterGender = (string)((ArrayList)CHARACTER_StaticChoices[1])[3];

        //Debug.Log("Names and Gender are ok instanciated");

        Character.HistoryChoices.HellCircleChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[4];
        Character.HistoryChoices.AllegianceChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[5];
        Character.HistoryChoices.SocialChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[6];
        Character.HistoryChoices.JobChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[7];
        Character.HistoryChoices.ImpChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[8];
        Character.HistoryChoices.OriginChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[9];
        Character.HistoryChoices.TemperChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[10];
        Character.HistoryChoices.AstroChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[11];
        Character.HistoryChoices.AffinityChoice = (string)((ArrayList)CHARACTER_StaticChoices[1])[12];
        Character.HistoryChoices.LeadershipCost = (int)((ArrayList)CHARACTER_StaticChoices[1])[13];

        //Debug.Log("History choices are instanciated");

        Character.DemonPartChoices.HeadChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[14];
        Character.DemonPartChoices.HeadQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[15];
        Character.DemonPartChoices.BodyChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[16];
        Character.DemonPartChoices.BodyQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[17];
        Character.DemonPartChoices.RightUpperArmChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[18];
        Character.DemonPartChoices.RightUpperArmQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[19];
        Character.DemonPartChoices.RightLowerArmChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[20];
        Character.DemonPartChoices.RightLowerArmQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[21];
        Character.DemonPartChoices.RightFistChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[22];
        Character.DemonPartChoices.RightFistQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[23];
        Character.DemonPartChoices.RightLegChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[24];
        Character.DemonPartChoices.RightLegQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[25];
        Character.DemonPartChoices.RightFootChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[26];
        Character.DemonPartChoices.RightFootQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[27];
        Character.DemonPartChoices.LeftUpperArmChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[28];
        Character.DemonPartChoices.LeftUpperArmQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[29];
        Character.DemonPartChoices.LeftLowerArmChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[30];
        Character.DemonPartChoices.LeftLowerArmQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[31];
        Character.DemonPartChoices.LeftFistChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[32];
        Character.DemonPartChoices.LeftFistQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[33];
        Character.DemonPartChoices.LeftLegChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[34];
        Character.DemonPartChoices.LeftLegQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[35];
        Character.DemonPartChoices.LeftFootChoiceID = (int)((ArrayList)CHARACTER_StaticChoices[1])[36];
        Character.DemonPartChoices.LeftFootQuality = (int)((ArrayList)CHARACTER_StaticChoices[1])[37];

        //Debug.Log("Demon Part Choices are instanciated");

        // StatsModifiers
        Character.AllocatedStatsModifier.Strength = (int)((ArrayList)CHARACTER_StatModifiers[1])[2];
        Character.AllocatedStatsModifier.Speed = (int)((ArrayList)CHARACTER_StatModifiers[1])[3];
        Character.AllocatedStatsModifier.Dexterity = (int)((ArrayList)CHARACTER_StatModifiers[1])[4];
        Character.AllocatedStatsModifier.Endurance = (int)((ArrayList)CHARACTER_StatModifiers[1])[5];
        Character.AllocatedStatsModifier.Reflex = (int)((ArrayList)CHARACTER_StatModifiers[1])[6];
        Character.AllocatedStatsModifier.Resilience = (int)((ArrayList)CHARACTER_StatModifiers[1])[7];

        Character.AllocatedStatsModifier.Knowledge = (int)((ArrayList)CHARACTER_StatModifiers[1])[8];
        Character.AllocatedStatsModifier.Elocution = (int)((ArrayList)CHARACTER_StatModifiers[1])[9];
        Character.AllocatedStatsModifier.Intellect = (int)((ArrayList)CHARACTER_StatModifiers[1])[10];
        Character.AllocatedStatsModifier.Influence = (int)((ArrayList)CHARACTER_StatModifiers[1])[11];
        Character.AllocatedStatsModifier.Focus = (int)((ArrayList)CHARACTER_StatModifiers[1])[12];
        Character.AllocatedStatsModifier.Mockery = (int)((ArrayList)CHARACTER_StatModifiers[1])[13];

        Character.AllocatedStatsModifier.Malevolent = (int)((ArrayList)CHARACTER_StatModifiers[1])[14];
        Character.AllocatedStatsModifier.Unmerciful = (int)((ArrayList)CHARACTER_StatModifiers[1])[15];

        Character.AllocatedStatsModifier.Rage = (int)((ArrayList)CHARACTER_StatModifiers[1])[16];
        Character.AllocatedStatsModifier.Phase = (int)((ArrayList)CHARACTER_StatModifiers[1])[17];

        Character.AllocatedStatsModifier.Momentum = (int)((ArrayList)CHARACTER_StatModifiers[1])[18];
        Character.AllocatedStatsModifier.Balance = (int)((ArrayList)CHARACTER_StatModifiers[1])[19];
        Character.AllocatedStatsModifier.Chaos = (int)((ArrayList)CHARACTER_StatModifiers[1])[20];
        Character.AllocatedStatsModifier.Luck = (int)((ArrayList)CHARACTER_StatModifiers[1])[21];
        Character.AllocatedStatsModifier.Perception = (int)((ArrayList)CHARACTER_StatModifiers[1])[22];
        Character.AllocatedStatsModifier.Judgement = (int)((ArrayList)CHARACTER_StatModifiers[1])[23];

        Character.AllocatedStatsModifier.primaryStatPointsToAllocate = (int)((ArrayList)CHARACTER_StatModifiers[1])[24];
        Character.AllocatedStatsModifier.heroicStatPointsToAllocate = (int)((ArrayList)CHARACTER_StatModifiers[1])[25];
        Character.AllocatedStatsModifier.secondaryStatPointsToAllocate = (int)((ArrayList)CHARACTER_StatModifiers[1])[26];

        //Debug.Log("Allocated Stats Modifiers are instanciated");



        // Getting the sum
        Character.Strength = (int)(long)((ArrayList)CharacterStats[1])[1];
        Character.Speed = (int)(long)((ArrayList)CharacterStats[1])[2];
        Character.Dexterity = (int)(long)((ArrayList)CharacterStats[1])[3];
        Character.Endurance = (int)(long)((ArrayList)CharacterStats[1])[4];
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


        Character.Experience = (long)((ArrayList)CHARACTER_Progress[1])[1];

        //Debug.Log("Experience is instanciated");

        //Debug.Log("Finish");

        return Character;
    }


    public void UpdateCityData(int TileSpriteId, int Visibility, int x, int y)
    {
        // cleaning any existing record
        dataBaseManager.RunQuery("DELETE FROM ACCOUNT_CityMap WHERE " + "X=" + x +" and Y=" + y +";");

        // creating the x and z record
        dataBaseManager.RunQuery("INSERT INTO ACCOUNT_CityMap VALUES (" + x + " , " + y + " , " + TileSpriteId + " , " + Visibility + " );");

    }

    public (int[,] TileMap, int[,] VisibilityMap) LoadPlayerCityFromDataBase()
    {

        // Getting the dimensions of the map
        int MapSizeOnX = Convert.ToInt32(((ArrayList)dataBaseManager.getArrayData("select count(distinct X) from ACCOUNT_CityMap")[1])[0]);
        int MapSizeOnY = Convert.ToInt32(((ArrayList)dataBaseManager.getArrayData("select count(distinct Y) from ACCOUNT_CityMap")[1])[0]);


        // Getting the map details
        ArrayList PlayerCity = dataBaseManager.getArrayData("select * from ACCOUNT_CityMap order by X, Y");

        int[,] TileMap = new int[MapSizeOnX, MapSizeOnY];
        int[,] VisibilityMap = new int[MapSizeOnX, MapSizeOnY];

        for (int i = 0; i < MapSizeOnX; i++)
        {
            for (int j = 0; j < MapSizeOnY; j++)
            {
                TileMap[i, j] =         (int)((ArrayList)PlayerCity[1+j + (i * MapSizeOnY)])[2];
                VisibilityMap[i, j] =   (int)((ArrayList)PlayerCity[1+j + (i * MapSizeOnY)])[3];
                //Debug.Log("Loading tile and sprite at x="+ i + " and z="+ j +" being tilecode="+ TileMap[i, j] + " with a visibility of "+ VisibilityMap[i, j]);
            }
        }

        return (TileMap, VisibilityMap);

    }


    public (string[] tileName, string[] tileDescription, int[] fallingEdgeTileSpriteId) LoadTileReferences()
    {

        // Finding number of sprites
        int numberOfSprites = Convert.ToInt32(((ArrayList)dataBaseManager.getArrayData("select count(distinct TileSpriteId) from VIEW_TileSpriteCodeDetailed;")[1])[0]);
        //Debug.Log("Number of tile sprite reference to load " + numberOfSprites);

        // Preparing arrays of the right size
        string[] tileName = new string[numberOfSprites];
        string[] tileDescription = new string[numberOfSprites];
        int[] fallingEdgeTileSpriteId = new int[numberOfSprites];

        // Getting the dimensions of the map
        ArrayList refTileCode = dataBaseManager.getArrayData("select TileName,TileDescription, TileMatchingFallingEdgeId from VIEW_TileSpriteCodeDetailed order by TileSpriteId ASC;");

        for (int i = 0; i < numberOfSprites; i++)
        {

            tileName[i] = (string)((ArrayList)refTileCode[i+1])[0];
            tileDescription[i] = (string)((ArrayList)refTileCode[i+1])[1];
            fallingEdgeTileSpriteId[i] = (int)((ArrayList)refTileCode[i + 1])[2];

            //Debug.Log("Loaded reference of "+ tileName[i]+ " on iteration "+ i);
        }

        return (tileName, tileDescription,fallingEdgeTileSpriteId);
    }



}
