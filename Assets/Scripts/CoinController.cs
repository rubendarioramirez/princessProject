using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			gameManager.myGameManager.coinsAmount++;
			Destroy(gameObject);
		}

	}

}
