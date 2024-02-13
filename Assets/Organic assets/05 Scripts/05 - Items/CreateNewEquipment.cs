using UnityEngine;
using System.Collections;

public class CreateNewEquipment : MonoBehaviour {
	
	private BaseEquipment newEquipment;

	private string[] itemNames = new string[4] {"Common", "Great", "Amazing", "Insane"};
	private string[] itemDescr = new string[2] {"Some random shitty human stuff.", "That's just bad..."};



	void Start(){
		
		CreateEquipment ();
		
		Debug.Log (newEquipment.ItemName);
		Debug.Log (newEquipment.ItemDescription);
		Debug.Log (newEquipment.ItemID);
		Debug.Log (newEquipment.EquipmentType);
		
	}
	
	
	public void CreateEquipment () {
		
		newEquipment = new BaseEquipment ();
		
		//assign Base Item
		newEquipment.ItemName = itemNames[Random.Range (0,itemNames.Length)]+ " item";
		newEquipment.ItemDescription = itemDescr[Random.Range (0,itemDescr.Length)];
		newEquipment.ItemID = Random.Range (1, 101);
		
		//assign Base stat
		newEquipment.Size=Random.Range(1,101);
		newEquipment.Durability=Random.Range(1,101);
		newEquipment.Itemlevel=Random.Range(1,101);
		newEquipment.Itemlevelreq=Random.Range(1,101);
		
		newEquipment.SpellEffectID=Random.Range (1, 101);
		newEquipment.Armor=Random.Range(1, 10);

		//WeaponType
		ChooseEquipmentType ();
		
		
	}
	
	private void ChooseEquipmentType (){
		
		int randomTemp = Random.Range (1, 4);
		
		switch (randomTemp) {
		case 1:
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
			break;
		case 2:
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.ARM;
			break;
		case 3:
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEG;
			break;
		}
	}
}
