using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatAllocationButtons : MonoBehaviour {

	public static Canvas StatAllocationMenu;

	public static Text[] PrimaryNumbers = new Text[12];
	public static Text[] HeroicNumbers = new Text[2];
	public static Text[] SecondaryNumbers = new Text[5];
	public static Text[] PointsToAlloc = new Text[3];



	
	void Awake(){
		StatAllocationMenu = GetComponent<Canvas>();
		StatAllocationMenu.enabled = false;

		for (int i=0; i<6; i++){ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<Text> () [(i*3)+4];}
		for (int i=6; i<12; i++){ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<Text> () [(i*3)+4+3];}
		for (int i=0; i<2; i++) { HeroicNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<Text> () [(i*3)+4+(14*3)];}
		for (int i=0; i<5; i++) { SecondaryNumbers [i] = 	StatAllocationMenu.GetComponentsInChildren<Text> () [(i*3)+4];}
		for (int i=0; i<3; i++) { PointsToAlloc [i] = 		StatAllocationMenu.GetComponentsInChildren<Text> () [(i*3)+4];}


	}


	void Update(){
		if (StatAllocationMenu.enabled == true) {
		
		
		
		
		
		
		
		
		}

	}

}
