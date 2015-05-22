using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class dialogTrigger : MonoBehaviour {
	
	private GameObject levelCanvas;
	private Text dialogText;
	private int dialogShowed = 0;
	private int gameProgress;
	public List<string> dialogs;
	
	//Game manager Reference
	public gameManager myGameManager;

	//Player reference
	public Hero myPlayer;


	// Use this for initialization
	void Start () {
		//Get current value of game Progress from GameManager.cs
		myGameManager.GetComponent<gameManager>();
		//Find UIDialog and create a reference
		levelCanvas = GameObject.Find ("UIDialog");
		//Find UIText and create a reference
		dialogText = GameObject.Find("dialogText").GetComponent<Text> ();
		//Make sure is not visible by default
		levelCanvas.SetActive (false);
		//Get gameProgress from Gamemanager
		gameProgress = myGameManager.gameProgress;

		//dialogShowed++;

		//Set up list of possible dialogs to show
		dialogs.Add ("Im wondering where is Pinoy?");
		dialogs.Add ("I will look in the house first");
		dialogs.Add ("mmm strange, he is not around");
		dialogs.Add ("Perhaps he is in the chest again");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			skipDialog();
		}
	}

	//When the trigger point is hit
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			//Unable player to move while showing Dialogs.
			myPlayer.SendMessage("showDialogs", true, SendMessageOptions.DontRequireReceiver);

			switch(gameProgress){
			case 0:
				dialogText.text = dialogs[0];
				dialogShowed++;

				break;
			case 1:
				dialogText.text = dialogs[2];
				dialogShowed++;
				break;
			}

			//Show dialog.
			levelCanvas.SetActive (true);

			//Update game progress.
			myGameManager.SendMessage("updateGameProgress", SendMessageOptions.DontRequireReceiver);
		}
	}

	//Skip the dialogs until there is no more to show
	void skipDialog(){
		if (dialogShowed == 1) {
			dialogText.text = dialogs[1];
			dialogShowed++;
		} else
		{
			dismissDialog();
		}
	
	}

	//Call when there is no more dialogs to show
	void dismissDialog(){
		levelCanvas.SetActive(false);
		//Inform the player that he can move now.
		myPlayer.SendMessage("showDialogs", false, SendMessageOptions.DontRequireReceiver);
		Destroy(this);
	}

}
