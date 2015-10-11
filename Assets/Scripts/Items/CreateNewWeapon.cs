using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

	private BaseWeapon newWeapon;

	void Start(){
		
		CreateWeapon ();

		Debug.Log (newWeapon.ItemName);
		Debug.Log (newWeapon.ItemDescription);
		Debug.Log (newWeapon.ItemID);
		Debug.Log (newWeapon.WeaponType);

	}

	
	public void CreateWeapon () {

		newWeapon = new BaseWeapon ();

		//assign Base Item
		newWeapon.ItemName = "W" + Random.Range (1, 101);
		newWeapon.ItemDescription = "Some random shitty human weapon.";
		newWeapon.ItemID = Random.Range (1, 101);

		//assign Base stat
		newWeapon.Size=Random.Range(1,101);
		newWeapon.Durability=Random.Range(1,101);
		newWeapon.Itemlevel=Random.Range(1,101);
		newWeapon.Itemlevelreq=Random.Range(1,101);

		newWeapon.SpellEffectID=Random.Range (1, 101);
		newWeapon.Dmg_min=Random.Range(1, 10);
		newWeapon.Dmg_max = newWeapon.Dmg_min + Random.Range (1, 3);
		newWeapon.Frequence= newWeapon.Itemlevel*2/(newWeapon.Dmg_min + newWeapon.Dmg_max);

		//WeaponType
		ChooseWeaponType ();


	}

	private void ChooseWeaponType (){

		int randomTemp = Random.Range (1, 4);

		switch (randomTemp) {
		case 1:
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.AXE;
			break;
		case 2:
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
			break;
		case 3:
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
			break;
		}
	}
}
