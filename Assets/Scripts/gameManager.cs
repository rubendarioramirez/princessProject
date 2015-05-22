using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {
	
	//Creates a reference of itself
	public static gameManager myGameManager;

	//Get access to Dialog references
	private GameObject levelCanvas;
	private Text dialogText;
	// Create a list of dialog lines
	public List<string> dialogList;
	
	//Other levelthings
	public float levelStartDelay =2f;
	private Text levelText;
	private GameObject levelImage;

	//Coins Count
	public int coinsAmount = 0;
	
	//Handles the current progress of the game
	public int gameProgress = 0;


	//Level 2 variables (House Scene)
	public bool chestHasBeenOpened = false;

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
			Hero.myPlayer.transform.position = new Vector2 (-2.5f, -0.2f);
			dismissDialogs ();
		} else if (Application.loadedLevelName == "Main" && gameProgress > 0) {
			Hero.myPlayer.transform.position = new Vector2 (-5, -4);
			dismissDialogs ();
		} 


	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Coins: " + coinsAmount);
		//GUI.Label(new Rect(10, 40, 64, 64), textureToDisplay);
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
		//Set the dialog depending the TriggerPoint
		dialogText.text = dialogList[DialogCount];
		levelCanvas.SetActive (true);
		}
	public void dismissDialogs(){
		Hero.myPlayer.SendMessage("showDialogs", false, SendMessageOptions.DontRequireReceiver);
		levelCanvas.SetActive(false);
	}

}
		