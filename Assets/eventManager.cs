using UnityEngine;
using System.Collections;

public class eventManager : MonoBehaviour {
	//Creates a reference of itself or a Singleton nice try.
	public static eventManager mainEventManager;
	public delegate void dialogsShowing();
	public static event dialogsShowing onDialogShowing;
	public static event dialogsShowing notDialogShowing;


	void Awake(){
		//	callTransition ("Once upon a time");
		//	Invoke ("HideLevelImage", levelStartDelay);
		
		//Check if there is a gameController, if not create it. If there is but is not this one, destroy it.
		if (mainEventManager == null) {
			DontDestroyOnLoad (gameObject);
			mainEventManager = this;
		} else if (mainEventManager != this) {
			Destroy(gameObject);
		}
		
		
	}

	void isShowingDialogs(){
		if(onDialogShowing != null)
			onDialogShowing();
	}

	void isNotShowingDialogs(){
		if(onDialogShowing != null)
				notDialogShowing();
	}

}
//	void OnGUI()
//	{
//		if (GUI.Button (new Rect (Screen.width / 2 - 50, 5, 100, 30), "Click")) {
//			if(onDialogShowing != null)
//				onDialogShowing();
//		}
//		if (GUI.Button (new Rect (Screen.width / 2 - 250, 5, 100, 30), "Not Showing Click")) {
//			if(onDialogShowing != null)
//				notDialogShowing();
//		}
//}


