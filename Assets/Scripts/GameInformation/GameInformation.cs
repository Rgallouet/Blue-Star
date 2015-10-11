using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	// Base Player
	public static string 		PlayerFirstName 			{ get; set;}
	public static string 		PlayerLastName 				{ get; set;}
	public static string 		PlayerBio 					{ get; set;}
	public static string 		PlayerGender 				{ get; set;}
	public static BaseClass 	PlayerClass 				{ get; set;}

	public static string 		Gender						{ get; set;}

	public static int 		PlayerLevel 					{ get; set;}
	public static int 		TotalXP 						{ get; set;}
	public static int 		CurrentXP 						{ get; set;}
	public static int 		RequiredXP 						{ get; set;}
	public static int 		PrimaryStatPointsToAllocate 	{ get; set;}
	public static int 		HeroicStatPointsToAllocate 		{ get; set;}
	public static int 		SecondaryStatPointsToAllocate 	{ get; set;}
	
	public static int 		HumanCrap 						{ get; set;}
	
	public static int 		HP 								{ get; set;}
	public static int 		AP 								{ get; set;}
	public static int 		CurrentHP 						{ get; set;}
	public static int 		CurrentAP 						{ get; set;}
	
	public static int Strength		{ get; set;}
	public static int Speed		{ get; set;}
	public static int Dexterity	{ get; set;}
	public static int Reflex		{ get; set;}
	public static int Resilience	{ get; set;}
	
	public static int Knowledge	{ get; set;}
	public static int Elocution	{ get; set;}
	public static int Intellect	{ get; set;}
	public static int Focus		{ get; set;}
	public static int Mockery		{ get; set;}
	
	public static int Malevolant	{ get; set;}
	public static int Unmerciful	{ get; set;}
	
	public static int Rage			{ get; set;}
	public static int Phase		{ get; set;}

	public static int Momentum		{ get; set;}
	public static int Balance		{ get; set;}
	public static int Luck			{ get; set;}
	public static int Perception	{ get; set;}
	public static int Judgement	{ get; set;}
	public static int Chaos		{ get; set;}


	// Equipment
	public static BaseEquipment EquipmentOne	{ get; set;}










}
