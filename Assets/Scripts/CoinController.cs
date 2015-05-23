using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinController : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {

			gameManager.myGameManager.coinsAmount++;
			removeMeFromTheCoinList();
			Destroy(gameObject);
			//Debug.Log("Quedan" + gameManager.myGameManager.coinsList.Count + " Coins ");
		}

	}

	void Start (){
		//If the game didnt start, then add all coins to the game. If it did find the coin in the List,
		// if it's not there means it was already collected so destroy it
		if (gameManager.myGameManager.gameHasStarted == false) {
			GetmeOntheCoinList ();
		} else if (gameManager.myGameManager.gameHasStarted == true) {
			if(findMeOnTheCoinList() == -1){
				Destroy(gameObject);
			}
		}


	}

	void GetmeOntheCoinList(){
		//Insert the object into the CointList
		string objectName = gameObject.name.ToString ();
		gameManager.myGameManager.coinsList.Add (objectName);
	}

	int findMeOnTheCoinList(){
		//Find the object into the CointList as return the Index as INT
		string objectName = gameObject.name.ToString ();
		int theIndex = gameManager.myGameManager.coinsList.IndexOf(objectName);
		return theIndex;
		}

	void removeMeFromTheCoinList(){
		//Remove the object from the List
		gameManager.myGameManager.coinsList.RemoveAt (findMeOnTheCoinList());
	}



}
