using UnityEngine;
using System.Collections;

public class eventManager : MonoBehaviour {
	//Creates a reference of itself or a Singleton nice try.
	public static eventManager mainEventManager;
	public delegate void dialogsShowing();
	public static event dialogsShowing onDialogShowing;
	public static event dialogsShowing notDialogShowing;


	void Awake(){
		//Check if there is a gameController, if not create it. If there is but is not this one, destroy it.
		if (mainEventManager == null) {
			DontDestroyOnLoad (gameObject);
			mainEventManager = this;
		} else if (mainEventManager != this) {
			Destroy(gameObject);
		}
		
		
	}

	void isShowingDialogs(){
		if (onDialogShowing != null) {
			onDialogShowing ();
		}
	}

	void isNotShowingDialogs(){
		if(onDialogShowing != null)
				notDialogShowing();
	}
	
}


