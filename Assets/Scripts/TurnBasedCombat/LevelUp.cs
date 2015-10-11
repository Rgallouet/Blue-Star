using UnityEngine;
using System.Collections;

public class LevelUp {
	

	public void levelUpCharacter(){
		// excess of xp
		GameInformation.CurrentXP -= GameInformation.RequiredXP;

		//save your ass
		GameInformation.CurrentHP = GameInformation.HP;
		GameInformation.CurrentAP = GameInformation.AP;

		//level up
		GameInformation.PlayerLevel += 1;

		//give stat points

















		//determine the next amount of require xp
		DetermineRequiredXp ();
	}

	private void DetermineRequiredXp(){
		GameInformation.RequiredXP = (int)Mathf.Ceil(100f*Mathf.Pow(1.03f,GameInformation.PlayerLevel));
	}


}
