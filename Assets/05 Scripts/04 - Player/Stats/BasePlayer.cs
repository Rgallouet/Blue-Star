using UnityEngine;
using System.Collections;
[System.Serializable]


public class BasePlayer {

	public int PlayerLevel;
    
    //Statics
    public string PlayerFirstName;
	public string PlayerLastName;	
	public string PlayerBio;
	public string PlayerGender;

    //History
    public HistoryChoices HistoryChoices = new HistoryChoices();

    //Modifiers
    public StatModifier HistoryChoicesModifier = new StatModifier();
    public StatModifier AllocatedStatsModifier = new StatModifier();

    //Combat
    public int CurrentEmbodiment; 	
	public int CurrentInfluence;	

	public int TotalXP;
	public int CurrentXP;
	public int RequiredXP;

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

    public int NumberOfLegacy;
}
