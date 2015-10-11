using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

	private static int xpToGive;
	private static LevelUp levelUpScript = new LevelUp();


	public static void AddExperience () {
		xpToGive = GameInformation.PlayerLevel * 100;
		Debug.Log (xpToGive);
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();
	}

	public static void AddExperienceFromBattleLoss(){
		xpToGive = GameInformation.PlayerLevel * 10;
		Debug.Log (xpToGive);
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();	
	}


	private static void CheckToSeeIfPlayerLeveled () {
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) {
			levelUpScript.levelUpCharacter();
			// Create lvl up script
		}
	}


}
