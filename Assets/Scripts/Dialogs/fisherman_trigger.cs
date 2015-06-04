using UnityEngine;
using System.Collections;

public class fisherman_trigger : MonoBehaviour {
	
	public int dialogCount;
	public int npcToShow;
	private bool spacePressed;
	private int spacePressedTimes;

	void Start(){
		spacePressed = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			spacePressed = true;
		}
		
	}	
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if(spacePressed)
			{
				if(spacePressedTimes == 0){
					//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show
					//MyGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
					gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
					npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", npcToShow, SendMessageOptions.DontRequireReceiver);
					mc_dialog_controller.my_mc_dialog_controller.SendMessage("displayMCAvatar", 1, SendMessageOptions.DontRequireReceiver);
					gameManager.myGameManager.gameProgress++;
					spacePressed = false;
					spacePressedTimes++;
				}
				else if(spacePressedTimes == 1){
					gameManager.myGameManager.SendMessage("showDialogs", dialogCount+1, SendMessageOptions.DontRequireReceiver);
					spacePressed = false;
					spacePressedTimes++;
				}
				else {
					gameManager.myGameManager.SendMessage("dismissDialogs", SendMessageOptions.DontRequireReceiver);
					spacePressed = false;
				}
			}

		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			spacePressedTimes = 0;
		}
	}
}
