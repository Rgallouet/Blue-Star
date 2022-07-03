using UnityEngine;
using System.Collections;



public class BaseCharacter {

	//Statics
	public int characterID;

	//Statics
	public string characterName;
	public string characterBio;
	public string characterGender;

    //History
    public HistoryChoices HistoryChoices = new();

    //Modifiers
    public StatModifier HistoryChoicesModifier = new();
    public StatModifier AllocatedStatsModifier = new();

    //Combat
    public int CurrentHealth;
	public int CurrentShield;
	public int CurrentEnergy;	

	public int Experience;

	public int HumanCrap;
    public int Gold;

    //Active Stats
    public int Embodiment; 
	public int Strength;
	public int Speed;
	public int Dexterity;
	public int Reflex;
	public int Resilience;

	public int Influence;   
	public int Knowledge;
	public int Elocution;
	public int Intellect;
	public int Focus;
	public int Mockery;
	
	public int Malevolent;
	public int Unmerciful;
	
	
	public int Rage;
	public int Phase;

	public int Momentum;
	public int Balance;
	public int Luck;
	public int Perception;
	public int Judgement;
	public int Chaos;

	//InteractionStats
	public int BuildingLevel;
    public int DiggingLevel;


	public void AddExperience(int xpToGive)
	{

		Debug.Log("Character " + characterName + " receives " + xpToGive + " experience.");

		int levelBefore = Experience / 1000;
		int levelAfter = (Experience + xpToGive) / 1000;

		if (levelAfter > levelBefore)
		{
			//Script for leveling up e.g. giving 2 stat allocation for instance
			int primaryStatsGain = 1 * (levelAfter - levelBefore);
			AllocatedStatsModifier.primaryStatPointsToAllocate += primaryStatsGain;
			Debug.Log("Character " + characterName + " levels up to " + levelAfter + " and gains " + primaryStatsGain + " primary stat point to allocate.");

			if (levelAfter / 5 > levelBefore / 5)
			{
				int secondaryStatsGain = 2 * ((levelAfter / 5) - (levelBefore / 5));
				AllocatedStatsModifier.secondaryStatPointsToAllocate += primaryStatsGain;
				Debug.Log("Character " + characterName + " reached a special level threshold and gains " + secondaryStatsGain + " secondary stat point to allocate.");

				if (levelAfter / 10 > levelBefore / 10)
				{
					int heroicStatsGain = 1 * ((levelAfter / 10) - (levelBefore / 10));
					AllocatedStatsModifier.heroicStatPointsToAllocate += heroicStatsGain;
					Debug.Log("Character " + characterName + " reached a special level threshold and gains " + heroicStatsGain + " heroic stat point to allocate.");

				}

			}


		}
		Experience += xpToGive;


	}



}
