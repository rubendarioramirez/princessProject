using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dialogManager : MonoBehaviour
{	//Creates a reference of itself or a Singleton nice try.
	public static dialogManager myDialogManager;

	//Enables logs
	public bool debugMode = false;

	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect ((Screen.width - 700)/2, (Screen.height)/2, 600, 200);
	// Only show it if needed.
	public bool show = false;
	// Create a list of dialog lines
	public List<string> dialogList;
	public List<string> dialogTriggerList = new List<string>();

	//Font type
	public Font guiFont;

	//MC Avatar
	public Texture MCavatar;
	public bool showMCAvatar;

	//Specify the type of dialog it's going on.
	public bool isConversation;
	public bool isOnTrigger;
	public bool conversationFinished;

	public int currentDialogMin;
	public int currentDialogMax;
	public int currentDialog; 

	void Awake(){
		//Check if there is a D, if not create it. If there is but is not this one, destroy it.
		if (myDialogManager == null) {
			DontDestroyOnLoad (gameObject);
			myDialogManager = this;
		} else if (myDialogManager != this) {
			Destroy(gameObject);
		}
		
		
	}
	
	void Start(){
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


	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Return)) {
			if(isConversation == false){
				conversationFinished = true;
				if(conversationFinished)
				{
					dismissDialogs();
				}
			}
			else if (isConversation == true){
				if(isOnTrigger)
				{
					showDialogs();
					if(!conversationFinished && currentDialogMin == currentDialogMax ){

							conversationFinished = true;

					}
					else if(conversationFinished)
					{
						dismissDialogs();
					}
					currentDialogMin++;
				}

			}
		}
	}

	void OnGUI () 
	{
		if (show) {
			detectConversationType();
			currentDialog = currentDialogMin;
			windowRect = GUI.Window (0, windowRect, DialogWindow, "Dialog");

			if(showMCAvatar){
				drawMC();
			} 
		}
	}
	
	// This is the actual window that displays the dialogs.
	void DialogWindow (int windowID)
	{

		GUI.skin.font = guiFont;
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 24;
		myStyle.normal.textColor = Color.white;
		GUI.Label(new Rect(10, 10, 300, 20), dialogList[currentDialog], myStyle);
	}
	public void drawMC(){
		GUI.DrawTexture (new Rect (200, 300, 100, 250), MCavatar);
	}

	//Dialogs functions
	public void stablishMin(int dialogMin){
		currentDialogMin = dialogMin;
		if (debugMode) {Debug.Log ("Current Dialog min is " + dialogMin);}
	}
	public void stablishMax(int dialogMax){
		currentDialogMax = dialogMax;
		if (debugMode) {Debug.Log ("Current Dialog max is " + dialogMax);}
	}
	public void detectConversationType(){
		if (currentDialogMin == currentDialogMax) {
			isConversation = false;
			if (debugMode) {Debug.Log ("Is a conversation is " + isConversation);}
		} else if (currentDialogMin != currentDialogMax){
			isConversation = true;
			if (debugMode) {Debug.Log ("Is a conversation is " + isConversation);}
		}
	}

	public void showDialogs(){
		show = true;
		eventManager.mainEventManager.SendMessage ("isShowingDialogs", SendMessageOptions.DontRequireReceiver);
		}
	
	public void dismissDialogs(){
		resetDialogManager ();
		eventManager.mainEventManager.SendMessage ("isNotShowingDialogs", SendMessageOptions.DontRequireReceiver);
	}

	void resetDialogManager(){
		show = false;
		showMCAvatar = false;
		conversationFinished = false;
	}

	public void showMatilda(){
		showMCAvatar = true;
	}
	public void inConversationRadio(){
		isOnTrigger = true;
		Debug.Log("Is on NPC trigger area");
	}



}