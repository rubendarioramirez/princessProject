using UnityEngine;
using System.Collections;

public class DefaultTrigger : MonoBehaviour {
	
	public int dialogCount;
//	public int NPCToShow;

	//Get an instance of MC to show on UIDialogs	
	public gameManager.MCToshow showMConDialog;
	public gameManager.NPCToshow showNPConDialog;

	public bool IwasRemoved = false;

	void Start (){
		//If the game didnt start, then add all coins to the game. If it did find the coin in the List,
		// if it's not there means it was already collected so destroy it
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
			//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show
			//MyGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
			gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);

			//Handles the MCto show drop down menu. Just 2 options always.
			if(showMConDialog == gameManager.MCToshow.Transparent){
				mc_dialog_controller.my_mc_dialog_controller.SendMessage("displayMCAvatar", 1, SendMessageOptions.DontRequireReceiver);
			}
			else if(showMConDialog == gameManager.MCToshow.Matilda){
				mc_dialog_controller.my_mc_dialog_controller.SendMessage("displayMCAvatar", 0, SendMessageOptions.DontRequireReceiver);
			}

			//Handles the NPC to show dropdown menu
			switch(showNPConDialog){
			case gameManager.NPCToshow.Transparent:
				npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 0, SendMessageOptions.DontRequireReceiver);
				break;
			case gameManager.NPCToshow.Fisherman:
				npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 1, SendMessageOptions.DontRequireReceiver);
				break;
			}

			removeMeFromTheTriggerList();
			//Kill this object to make sure same dialog is not trigger twice
			Destroy(gameObject);
		}
	}
	
	void GetmeOntheTriggerList(){
		//Insert the object into the CointList
		string objectName = gameObject.name.ToString ();
		gameManager.myGameManager.dialogTriggerList.Add (objectName);
	}
	
	int findMeOnTheTriggerList(){
		//Find the object into the CointList as return the Index as INT
		string objectName = gameObject.name.ToString ();
		int theIndex = gameManager.myGameManager.dialogTriggerList.IndexOf(objectName);
		return theIndex;
	}
	
	void removeMeFromTheTriggerList(){
		//Remove the object from the List
		gameManager.myGameManager.dialogTriggerList.RemoveAt (findMeOnTheTriggerList());
	}

}
