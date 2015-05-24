using UnityEngine;
using System.Collections;

public class fisherman_trigger : MonoBehaviour {
	
	public int dialogCount;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show
			//MyGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
			gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
			npc_dialog_controller.my_npc_dialog_controller.SendMessage("displayNPCAvatar", 1, SendMessageOptions.DontRequireReceiver);
			gameManager.myGameManager.gameProgress++;

		}
	}
}
