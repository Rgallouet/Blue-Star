using UnityEngine;
using System.Collections;
[System.Serializable]


public class BaseClass {
	private string className;
	private string classDescription;

	//Embodiment are always 100, same for action points
	private int embodiment; 		//Health Points are always 100
	private int influence;			//Action Points are always 100

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




	public int[] primaryClassStat;
	public int[] heroicClassStat;
	public int[] secondaryClassStat;
	

	public string 	ClassName 				{ get; set;}
	public string 	ClassDescription 		{ get; set;}
	public int 		Embodiment 				{ get; set;}
	public int 		Influence 				{ get; set;}

	 public int Strength	{ get; set;}
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

	 public int Rage		{ get; set;}
	 public int Phase		{ get; set;}

	 public int Momentum	{ get; set;}
	 public int Balance		{ get; set;}
	 public int Luck		{ get; set;}
	 public int Perception	{ get; set;}
	 public int Judgement	{ get; set;}
	 public int Chaos		{ get; set;}




}
