using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

	public Vector2 updatePosition;

	// Use this for initialization
	void Start () {
	
		updatePosition = transform.position;

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			gameManager.myGameManager.SendMessage("updatePlayerPosition", updatePosition, SendMessageOptions.DontRequireReceiver);
		}
	}

}
