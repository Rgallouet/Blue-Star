using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

    public static GameInformation instance = null;
	public static int Slot;
    public static BasePlayer BasePlayer;

	void Start(){
        

		//Check if instance already exists : if not, set instance to this
		if (instance == null) instance = this;

		//If instance already exists and it's not this:
		else if (instance != this) Destroy(gameObject);

        BasePlayer = new BasePlayer();

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
    }
    
	


}
