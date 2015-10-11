using UnityEngine;
using System.Collections;
[System.Serializable]


public class BasePlayer {

	private int playerLevel;
	private BaseClass playerClass;

	private string playerFirstName;
	private string playerLastName;	
	private string playerBio;
	private string playerGender;

	//HP are always 100, same for action points
	private int hp; 		//Health Points are always 100
	private int ap;			//Action Points are always 100
	private int currenthp; 		//Health Points are always 100
	private int currentap;			//Action Points are always 100

	private int totalXP;
	private int currentXP;
	private int requiredXP;
	private int primaryStatPointsToAllocate;
	private int heroicStatPointsToAllocate;
	private int secondaryStatPointsToAllocate;

	private int humanCrap;

	//Primary stats for Physical
	private int strength;
	private int speed;
	private int dexterity;
	private int reflex;
	private int resilience;
	
	private int knowledge;
	private int elocution;
	private int intellect;
	private int focus;
	private int mockery;
	
	private int malevolant;
	private int unmerciful;
	
	
	private int rage;
	private int phase;
	private int momentum;
	private int balance;
	private int luck;
	private int perception;
	private int judgement;
	private int chaos;

		

	public string 		PlayerFirstName 			{ get; set;}
	public string 		PlayerLastName 				{ get; set;}
	public string 		PlayerBio 					{ get; set;}
	public string 		PlayerGender 				{ get; set;}

	public BaseClass 	PlayerClass 				{ get; set;}

	public int 		PlayerLevel 					{ get; set;}
	public int 		TotalXP 						{ get; set;}
	public int 		CurrentXP 						{ get; set;}
	public int 		RequiredXP 						{ get; set;}
	public int 		PrimaryStatPointsToAllocate 	{ get; set;}
	public int 		HeroicStatPointsToAllocate 		{ get; set;}
	public int 		SecondaryStatPointsToAllocate 	{ get; set;}

	public int 		HumanCrap 						{ get; set;}

	public int 		HP 								{ get; set;}
	public int 		AP 								{ get; set;}
	public int 		CurrentHP 						{ get; set;}
	public int 		CurrentAP 						{ get; set;}

	public int Strength		{ get; set;}
	public int Speed		{ get; set;}
	public int Dexterity	{ get; set;}
	public int Reflex		{ get; set;}
	public int Resilience	{ get; set;}
	
	public int Knowledge	{ get; set;}
	public int Elocution	{ get; set;}
	public int Intellect	{ get; set;}
	public int Focus		{ get; set;}
	public int Mockery		{ get; set;}
	
	public int Malevolant	{ get; set;}
	public int Unmerciful	{ get; set;}
	
	public int Rage			{ get; set;}
	public int Phase		{ get; set;}
	public int Momentum		{ get; set;}
	public int Balance		{ get; set;}
	public int Luck			{ get; set;}
	public int Perception	{ get; set;}
	public int Judgement	{ get; set;}
	public int Chaos		{ get; set;}



}
