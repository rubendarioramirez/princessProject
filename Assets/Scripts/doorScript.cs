using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

	private string Scenename;
	// Use this for initialization
	void Start () {
		Scenename = Application.loadedLevelName;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if(Scenename == "bedroom_scene"){
				Application.LoadLevel ("main"); 
			}
			else if (Scenename == "Main"){
				Application.LoadLevel ("bedroom_scene"); 
			}
		
		}
	}
}
