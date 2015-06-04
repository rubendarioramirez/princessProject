using UnityEngine;
using System.Collections;

public class foundNoteTrigger : MonoBehaviour {

	//public gameManager MyGameManager;
	public int dialogCount;

	//Get access to NOTEUI
	private GameObject uiNote;


	void Start(){
		//Find UIDialog and create a reference, set it as not visible to start
		uiNote = GameObject.Find ("NoteUI");
		uiNote.SetActive (false);
	}


	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if(gameManager.myGameManager.chestHasBeenOpened == true)
			{
				//Ask Game manager to invoke ShowDialogs function and pass the specific dialog to show
				//MyGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
				gameManager.myGameManager.noteHasBeenFound = true;
				gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
				gameManager.myGameManager.gameProgress++;

				yield return new WaitForSeconds(3f);
				uiNote.SetActive(true);

				yield return new WaitForSeconds(3f);
				uiNote.SetActive(false);

				//Kill this object to make sure same dialog is not trigger twice
				Destroy(gameObject);
			}
		}
	}

}
