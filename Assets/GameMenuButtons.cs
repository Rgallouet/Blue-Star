using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public static bool gameMenuNewGame;
	public static bool gameMenuLoadGame;	
	public static bool gameMenuQuit;

	void Start() {
		gameMenuNewGame = false;
		gameMenuLoadGame = false;	
		gameMenuQuit = false;
	}


	public void StartNewGame(){
		gameMenuNewGame = true;
		Debug.Log ("clicking New game");
		Debug.Log (gameMenuNewGame);
	}

	public void LoadGame(){
		gameMenuLoadGame = true;
	}

	public void QuitGame(){
		gameMenuQuit = true;
		Debug.Log ("clicking Quit game");
		Debug.Log (gameMenuQuit);

	}
}
