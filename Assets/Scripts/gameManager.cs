using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {
	
	//Creates a reference of itself or a Singleton nice try.
	public static gameManager myGameManager;

	//Declare Enumerator with only 2 possible MCs for any type of dialog.
	public enum MCToshow{
		Matilda, 
		Transparent
	};

	//Declare Enumerator with possible NPCs for any type of dialog.
	public enum NPCToshow{
 		Transparent,
		Fisherman,
		FarmerWoman
	};
	
	//Get access to Dialog references
	private GameObject levelCanvas;
	private Text dialogText;
		
	//Other levelthings
	public float levelStartDelay =2f;
	private Text levelText;
	private GameObject levelImage;

	//Handles the current progress of the game
	public bool gameHasStarted = false;
	public int gameProgress = 0;
	public int coinsAmount = 0;
	public List<string> coinsList = new List<string>();

	//Level 2 variables (House Scene)
	public bool chestHasBeenOpened = false;
	public bool noteHasBeenFound = false;
	public bool fishermanQuestStarted = false;

	//Player settings
	public Vector2 playerPosition; 


	void Awake(){
		//Check if there is a gameController, if not create it. If there is but is not this one, destroy it.
		if (myGameManager == null) {
			DontDestroyOnLoad (gameObject);
			myGameManager = this;
		} else if (myGameManager != this) {
			Destroy(gameObject);
		}


	}

	void OnLevelWasLoaded(){
		if (Application.loadedLevelName == "bedroom_scene") {;
			gameHasStarted =false;
		} else if (Application.loadedLevelName == "Main") {;
			gameHasStarted =true;

		} 
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Coins: " + coinsAmount);
	}
	// Use this for initialization
	void Start () {
		//Game has started
		gameHasStarted = true;

		//Avoid destroying the gameManager when switching scenes.
		Object.DontDestroyOnLoad(this);
	}

	public void updatePlayerPosition(Vector2 updatedPosition){
		playerPosition = updatedPosition;
	}
		
}
		