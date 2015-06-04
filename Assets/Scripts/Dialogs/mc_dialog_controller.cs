using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mc_dialog_controller : MonoBehaviour {

	//Creates a reference of itself or a Singleton nice try.
	public static mc_dialog_controller my_mc_dialog_controller;
	
	public Sprite transparent;				//Will always be matilda, this handles the MC
	public Sprite sprite1;					//Default
	private Image myCurrentSprite;


	void Awake(){
		//	callTransition ("Once upon a time");
		//	Invoke ("HideLevelImage", levelStartDelay);
		
		//Check if there is a gameController, if not create it. If there is but is not this one, destroy it.
		if (my_mc_dialog_controller == null) {
			DontDestroyOnLoad (gameObject);
			my_mc_dialog_controller = this;
		} else if (my_mc_dialog_controller != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		myCurrentSprite = GetComponent<UnityEngine.UI.Image>();
	}
	
	void displayMCAvatar(int spriteToShow){
		switch(spriteToShow){
		case 0:
			myCurrentSprite.sprite = sprite1;
			break;
		case 1:
			myCurrentSprite.sprite = transparent;
			break;
		}
		
	}
}
