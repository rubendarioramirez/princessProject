using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class houseTrigger : MonoBehaviour {

	private GameObject levelCanvas;
	private Text dialogText;
	private int dialogShowed = 0;
	
	// Use this for initialization
	void Start () {
		levelCanvas = GameObject.Find ("UIDialog");
		dialogText = GameObject.Find("dialogText").GetComponent<Text> ();
		dialogText.text = "Mmm im wondering where he is?";
		dialogShowed++;
		levelCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			skipDialog();
			
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			levelCanvas.SetActive (true);
		}
	}
	void skipDialog(){
		if (dialogShowed == 1) {
			dialogText.text = "Perhaps is again inside the chest?";
			dialogShowed++;
		} else
		{
			dismissDialog();
		}
		
	}
	void dismissDialog(){
		levelCanvas.SetActive(false);
		Destroy(this);
	}
	
}