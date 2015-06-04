using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class npc_dialog_controller : MonoBehaviour {

	//Creates a reference of itself or a Singleton nice try.
	public static npc_dialog_controller my_npc_dialog_controller;

	public Sprite transparent;				//Default
	public Sprite sprite1;					//Fisherman
	public Sprite sprite2;					//Farmer Woman
	private Image myCurrentSprite;

	void Awake(){
		//	callTransition ("Once upon a time");
		//	Invoke ("HideLevelImage", levelStartDelay);
		
		//Check if there is a gameController, if not create it. If there is but is not this one, destroy it.
		if (my_npc_dialog_controller == null) {
			DontDestroyOnLoad (gameObject);
			my_npc_dialog_controller = this;
		} else if (my_npc_dialog_controller != this) {
			Destroy(gameObject);
		}
		
		
	}

	// Use this for initialization
	void Start () {
		myCurrentSprite = GetComponent<UnityEngine.UI.Image>();
	}


	void displayNPCAvatar(int spriteToShow){
		switch(spriteToShow){
		case 0:
			myCurrentSprite.sprite = transparent;
			break;
		case 1:
			myCurrentSprite.sprite = sprite1;
			break;
		case 2:
			myCurrentSprite.sprite = sprite2;
			break;
		}

	}


}
