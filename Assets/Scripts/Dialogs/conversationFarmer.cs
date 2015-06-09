//using UnityEngine;
//using System.Collections;
//
//public class conversationFarmer : MonoBehaviour {
//	
//	public int dialogCountMin;
//	public int dialogCountMax;
//
//	//It's already in the radius of the NPC?
//	public bool isonTrigger;
//	
//	//Get an instance of MC to show on UIDialogs	
//	public gameManager.MCToshow showMConDialog;
//	public gameManager.NPCToshow showNPConDialog;
//	
//	
//	void OnTriggerEnter2D(Collider2D other){
//		if (other.tag == "Player") {
//
//			if (gameManager.myGameManager.fishermanQuestStarted == true) {
//				dialogCountMin = 14;
//				dialogCountMax = 16;
//			}
//			else if (gameManager.myGameManager.fishermanQuestStarted == false){
//				dialogCountMin = 11;
//				dialogCountMax = 14;
//			}
//
//			isonTrigger = true;
//		}
//	}	
//	
//	void OnTriggerExit2D(Collider2D other){
//		if (other.tag == "Player") {
//			isonTrigger = false;
//		}	
//	}
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetKeyDown (KeyCode.Space)) {
//				if (isonTrigger) {
//					if (spacePressedTimes <= DialogMax) {
//						gameManager.myGameManager.SendMessage ("showDialogs", spacePressedTimes, SendMessageOptions.DontRequireReceiver);
//						showAvatars ();
//						
//					}
//					if (spacePressedTimes == DialogMax) {
//						gameManager.myGameManager.SendMessage ("dismissDialogs", SendMessageOptions.DontRequireReceiver);
//					}
//				}
//				spacePressedTimes++;		
//		}
//	}
//	
//	void showAvatars(){
//		//Handles the NPC to show dropdown menu
//		switch(showNPConDialog){
//		case gameManager.NPCToshow.Transparent:
//			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 0, SendMessageOptions.DontRequireReceiver);
//			break;
//		case gameManager.NPCToshow.Fisherman:
//			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 1, SendMessageOptions.DontRequireReceiver);
//			break;
//		case gameManager.NPCToshow.FarmerWoman:
//			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 2, SendMessageOptions.DontRequireReceiver);
//			break;
//		}
//	}
//	
//}
