using UnityEngine;
using System.Collections;

public class BackgroundAllocation {

    public string PlayerFirstName;
    public string PlayerLastName;
    public string PlayerBio;
    public string PlayerGender;
    

    public void StoreLastInfo(string playerFirstName,string playerLastName,string playerBio, string playerGender)
    {

        PlayerFirstName =   playerFirstName;
        PlayerLastName =    playerLastName;
        PlayerBio =         playerBio;
        PlayerGender =      playerGender;

        GameInformation.BasePlayer.PlayerFirstName = 	playerFirstName;
		GameInformation.BasePlayer.PlayerLastName = 	playerLastName;
		GameInformation.BasePlayer.PlayerBio = 			playerBio;
		GameInformation.BasePlayer.PlayerGender=        playerGender;
		
	}


}
