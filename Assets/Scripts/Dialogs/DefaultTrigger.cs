using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultTrigger : MonoBehaviour {
	
	//Handles where starts and end the conversation.
	public int dialogCountMin;
 	public int dialogCountMax;

	//If it's attached to NPC should not destroy this object for instance. Otherwise it's one time dialog.
	public bool attachedToNPC;

	//Handles which Avatars to show.
	public bool showMC;
	


	void Start (){
		//If the game didnt start, then add all coins to the game. If it did find the coin in the List,
		if (gameManager.myGameManager.gameHasStarted == false) {
			GetmeOntheTriggerList ();
		} else if (gameManager.myGameManager.gameHasStarted == true) {
			if(findMeOnTheTriggerList() == -1){
				Destroy(gameObject);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			stablishConversationIndex();
			if(attachedToNPC){
				dialogManager.myDialogManager.SendMessage("inConversationRadio", SendMessageOptions.DontRequireReceiver);
				dialogManager.myDialogManager.SendMessage("detectConversationType", SendMessageOptions.DontRequireReceiver);
			}
			if(!attachedToNPC){
				//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show;
				dialogManager.myDialogManager.SendMessage("showDialogs", SendMessageOptions.DontRequireReceiver);
				removeMeFromTheTriggerList();
				//Kill this object to make sure same dialog is not trigger twice
				Destroy(gameObject);
			}
			//Show Matilda or not
			if(showMC){
				dialogManager.myDialogManager.SendMessage("showMatilda", SendMessageOptions.DontRequireReceiver);
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			//isOnTrigger = false;
		}
	}
	
	void GetmeOntheTriggerList(){
		//Insert the object into the CointList
		string objectName = gameObject.name.ToString ();
		dialogManager.myDialogManager.dialogTriggerList.Add (objectName);
	}
	
	int findMeOnTheTriggerList(){
		//Find the object into the CointList as return the Index as INT
		string objectName = gameObject.name.ToString ();
		int theIndex = dialogManager.myDialogManager.dialogTriggerList.IndexOf(objectName);
		return theIndex;
	}
	
	void removeMeFromTheTriggerList(){
		//Remove the object from the List
		dialogManager.myDialogManager.dialogTriggerList.RemoveAt (findMeOnTheTriggerList());
	}
	void stablishConversationIndex(){
		dialogManager.myDialogManager.SendMessage ("stablishMin", dialogCountMin, SendMessageOptions.DontRequireReceiver);
		dialogManager.myDialogManager.SendMessage ("stablishMax", dialogCountMax, SendMessageOptions.DontRequireReceiver);
	}
}