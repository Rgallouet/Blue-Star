using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

	private static int xpToGive;
	private static LevelUp levelUpScript = new LevelUp();


	public static void AddExperience () {
		xpToGive = 1;
		Debug.Log (xpToGive);
		GameInformation.basePlayer.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();
	}

	public static void AddExperienceFromBattleLoss(){
		xpToGive = 0;
		Debug.Log (xpToGive);
		GameInformation.basePlayer.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();	
	}


	private static void CheckToSeeIfPlayerLeveled () {
		if (GameInformation.basePlayer.CurrentXP >= GameInformation.basePlayer.RequiredXP) {
			levelUpScript.levelUpCharacter();
			// Create lvl up script
		}
	}


}
