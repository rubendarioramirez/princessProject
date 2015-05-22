using UnityEngine;
using System.Collections;

public class triggerScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onCollisionEnter (Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			Application.LoadLevel ("bedroom_scene"); 
			Debug.Log("Enter trigger");
		}
	}
}
