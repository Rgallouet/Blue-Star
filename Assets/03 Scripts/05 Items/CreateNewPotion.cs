using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

	private BasePotion newPotion;

	// Use this for initialization
	void Start () {
		CreatePotion ();

		Debug.Log (newPotion.ItemName);
		Debug.Log (newPotion.ItemDescription);
		Debug.Log (newPotion.ItemID);
		Debug.Log (newPotion.PotionType);
		Debug.Log (newPotion.PotionValue);

	}

	public void CreatePotion () {
		
		newPotion = new BasePotion ();
		
		//assign Base Item
		newPotion.ItemName = "Potion";
		newPotion.ItemDescription = "This is a damn fine potion, dude.";
		newPotion.ItemID = Random.Range (1, 101);
		
		//assign Base stat
		newPotion.Size=1;
		newPotion.Durability=1;
		newPotion.Itemlevel=1;
		newPotion.Itemlevelreq=1;
		
		newPotion.SpellEffectID=Random.Range (1, 101);
		newPotion.PotionValue=Random.Range(1, 10);

		//WeaponType
		ChoosePotionType ();
		
		
	}
	
	private void ChoosePotionType (){
		
		int randomTemp = Random.Range (1, 4);
		
		switch (randomTemp) {
		case 1:
			newPotion.PotionType = BasePotion.PotionTypes.HEALTH;
			break;
		case 2:
			newPotion.PotionType = BasePotion.PotionTypes.ACTION;
			break;
		case 3:
			newPotion.PotionType = BasePotion.PotionTypes.EFFECT;
			break;
		}
	}


}
