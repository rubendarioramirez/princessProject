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
	// Create a list of dialog lines
	public List<string> dialogList;
	public List<string> dialogTriggerList = new List<string>();
	
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
	//	callTransition ("Once upon a time");
	//	Invoke ("HideLevelImage", levelStartDelay);

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
			dismissDialogs ();
			gameHasStarted =false;
		} else if (Application.loadedLevelName == "Main") {
			dismissDialogs ();
			gameHasStarted =true;

		} 
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Coins: " + coinsAmount);
	}
	// Use this for initialization
	void Start () {
		//Find UIDialog and create a reference
		levelCanvas = GameObject.Find ("UIDialog");
		//Find UIText and create a reference
		dialogText = GameObject.Find("dialogText").GetComponent<Text> ();
		//Make sure is not visible by default
		levelCanvas.SetActive (false);


		//Set up list of possible dialogs to show
		dialogList.Add ("Im wondering where is Pinoy?");						//0
		dialogList.Add ("I think i should check in the house first");			//1
		dialogList.Add ("Maybe he is in the chest again");						//2
		dialogList.Add ("Come on Pinoy, stop hiding");							//3
		dialogList.Add ("Im wondering who moved that Bookshelf");				//4

		//Fisherman Dialogs
		dialogList.Add ("\nPinoy is in the castle, \ncan you help me to open the gate?");							//5
		dialogList.Add ("\nMy mother has the key,\n but I cant comeback until");									//6
		dialogList.Add ("I get enough fish for supper \n. And i have no baits ");									//7
		dialogList.Add ("Will you help me if i find bait");														//8
		dialogList.Add ("Of course!");																			//9

		//Bedroom Scene
		dialogList.Add ("Oh a note!");											//10

		//Farmer Dialogs
		dialogList.Add ("Im looking for Pinoy \n can you help me?");										//11
		dialogList.Add ("Im sorry,\n I just sell baits");													//12
		dialogList.Add ("Oh, ok bye ");																		//13
		dialogList.Add ("Looks like i need some baits at the end ");										//14
		dialogList.Add ("Sure, it will be 20 coins");														//15


		//Game has started
		gameHasStarted = true;

		//Avoid destroying the gameManager when switching scenes.
		Object.DontDestroyOnLoad(this);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			dismissDialogs();
		}
	}		
	/// Show and dismiss dialogs /// 
	public void showDialogs(int DialogCount){
		//Unable player to move while showing Dialogs.
		Hero.myPlayer.SendMessage("showDialogs", true, SendMessageOptions.DontRequireReceiver);
		eventManager.mainEventManager.SendMessage ("isShowingDialogs", SendMessageOptions.DontRequireReceiver);
		//Set the dialog depending the TriggerPoint
		dialogText.text = dialogList[DialogCount];
		levelCanvas.SetActive (true);	
	}
	public void dismissDialogs(){
		Hero.myPlayer.SendMessage("showDialogs", false, SendMessageOptions.DontRequireReceiver);
		eventManager.mainEventManager.SendMessage("isNotShowingDialogs", SendMessageOptions.DontRequireReceiver);
		levelCanvas.SetActive(false);
	}

	public void updatePlayerPosition(Vector2 updatedPosition){
		playerPosition = updatedPosition;
	}
		
}
		