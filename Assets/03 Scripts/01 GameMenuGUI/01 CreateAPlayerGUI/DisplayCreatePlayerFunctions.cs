using UnityEngine;
using System.Collections;
using System.Linq;

public class DisplayCreatePlayerFunctions {

	private int classSelection;
	private string[] classSelectionNames = new string[] {"Butcher","Lord","Class3","Class4","Class5","Class6"};

	private HistoryAllocation historyAllocation = new HistoryAllocation();
	private StatAllocation statAllocation = new StatAllocation();
	private BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

	public Transform player;




	// Main steps
	public void DisplayClassSelections(){
		//A list of toggle buttons and each button will be a class
		classSelection=GUI.SelectionGrid(new Rect(100,100,100,300),classSelection,classSelectionNames,1);
		GUI.Label (new Rect (Screen.width-400, 100, 300, 300), FindClassDescription (classSelection));
	}


	public void DisplayStatAllocation(){
		//a list of stats with plus and minus buttons
		statAllocation.DisplayStatAllocationModule();
		}

	public void DisplayFinalSetup(){
		// name, history and gender
		backgroundAllocation.DisplayFinalSetup();
	}
	

	




	public string FindClassDescription(int classSelection){
		
		if (classSelection == 0) {
			BaseClass tempClass = new ButcherClass();
			return tempClass.ClassDescription;
			
		} else if (classSelection == 1) {
			BaseClass tempClass = new LordClass();
			return tempClass.ClassDescription;
		}
		return "When daddy asks, I'd better reply quickly...";
		
	}








	// Selecting the class and creating the character




}
