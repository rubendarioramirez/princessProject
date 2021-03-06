﻿using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	//Creates a reference of itself
	public static Hero myPlayer;

	public float speed = 10f;
	private Animator animator;
	public bool showingDialog = false;

	void Awake(){
		if (myPlayer == null) {
			DontDestroyOnLoad (gameObject);
			myPlayer = this;
		} else if (myPlayer != this) {
			Destroy(gameObject);
		}
	}

	//Subscribe and unsubscribe object to the eventManager
	void OnEnable(){
		eventManager.onDialogShowing += showDialogs;
		eventManager.notDialogShowing += NotshowingDialogs;
	}
	void OnDisable(){
		eventManager.onDialogShowing -= showDialogs;
		eventManager.notDialogShowing -= NotshowingDialogs;
	}


	// Use this for initialization
	void Start () {
		//Avoid destroying the player when switching scenes
		animator = GetComponent<Animator>();
	}

	void Update () {
		if(!showingDialog){
			movement ();
		}

		if(showingDialog){
			animator.SetTrigger("idle");
		}


	}


	void movement()
	{

		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			animator.SetTrigger("walkRight");
		} 
		else if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(-Vector2.right * speed * Time.deltaTime);
			animator.SetTrigger("walkLeft");
		} 
		else if(Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
			animator.SetTrigger("walkUp");
		} 
		else if(Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(-Vector2.up * speed * Time.deltaTime);
			animator.SetTrigger("walkDown");
		} else
		{
			animator.SetTrigger("idle");
		}
	} 

	void showDialogs(){
		showingDialog = true;
	}

	void NotshowingDialogs(){
		showingDialog = false;
	}



}