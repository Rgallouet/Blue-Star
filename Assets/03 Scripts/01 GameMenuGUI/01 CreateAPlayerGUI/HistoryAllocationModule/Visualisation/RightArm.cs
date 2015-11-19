using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightArm : MonoBehaviour {

	public Sprite[] RightArmSprites = new Sprite[9];

	float timer=3f;
	float delay=3f;

	void Update() {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (this.gameObject.GetComponentInChildren<Image>().sprite == RightArmSprites[0]){
				this.gameObject.GetComponentInChildren<Image>().sprite=RightArmSprites[1];
				timer=delay;
				Debug.Log ("Go to 1");
			} else if(this.gameObject.GetComponentInChildren<Image>().sprite == RightArmSprites[1]){
				this.gameObject.GetComponentInChildren<Image>().sprite = RightArmSprites[0];
				timer=delay;
				Debug.Log ("Go to 0");

			}
		
		}
	
	}


	public void UpdateSprite(int SpriteNum) {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = RightArmSprites [SpriteNum];
	}

}
