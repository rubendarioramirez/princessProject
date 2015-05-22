using UnityEngine;
using System.Collections;

public class bookShelfTrigger : MonoBehaviour {

	//public gameManager MyGameManager;
	public int dialogCount;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if(gameManager.myGameManager.chestHasBeenOpened == true)
			{
			//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show
			//MyGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
			gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
			gameManager.myGameManager.gameProgress++;
			//Kill this object to make sure same dialog is not trigger twice
			Destroy(gameObject);
			}
		}
	}
}
