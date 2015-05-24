using UnityEngine;
using System.Collections;

public class UIDialogScript : MonoBehaviour {
	//Creates a reference of itself
	public static UIDialogScript myDialogScript;


	
	void Awake(){
		if (myDialogScript == null) {
			DontDestroyOnLoad (gameObject);
			myDialogScript = this;
		} else if (myDialogScript != this) {
			Destroy(gameObject);
		}
	}


}
