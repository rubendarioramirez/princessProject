using UnityEngine;
using System.Collections;

public class conversationTrigger : MonoBehaviour {

	public int DialogMin;
	public int DialogMax;	

	//Count from MIN to MAX
	public int spacePressedTimes;
	//It's already in the radius of the NPC?
	public bool isonTrigger;
	
	//Get an instance of MC to show on UIDialogs	
	public gameManager.MCToshow showMConDialog;
	public gameManager.NPCToshow showNPConDialog;


	void Start () {
		//Make sure pressedtimes and dialogmin matches to improve coherence
		spacePressedTimes = DialogMin;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			isonTrigger = true;
		}
	}	

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			isonTrigger = false;
			spacePressedTimes = DialogMin;
		}	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isonTrigger) {
				if(gameManager.myGameManager.noteHasBeenFound == true){
					if (spacePressedTimes <= DialogMax) {
						gameManager.myGameManager.SendMessage ("showDialogs", spacePressedTimes, SendMessageOptions.DontRequireReceiver);
						showAvatars ();
						if (spacePressedTimes == DialogMax) {
							gameManager.myGameManager.fishermanQuestStarted = true;
							gameManager.myGameManager.SendMessage ("dismissDialogs", SendMessageOptions.DontRequireReceiver);	
						}
					}
					spacePressedTimes++;
				}
			}
		}
	}

	void showAvatars(){
		//Handles the NPC to show dropdown menu
		switch(showNPConDialog){
		case gameManager.NPCToshow.Transparent:
			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 0, SendMessageOptions.DontRequireReceiver);
			break;
		case gameManager.NPCToshow.Fisherman:
			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 1, SendMessageOptions.DontRequireReceiver);
			break;
		case gameManager.NPCToshow.FarmerWoman:
			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 2, SendMessageOptions.DontRequireReceiver);
			break;
		}
	}

}
