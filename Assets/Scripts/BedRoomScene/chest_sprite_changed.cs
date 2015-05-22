using UnityEngine;
using System.Collections;

public class chest_sprite_changed : MonoBehaviour {

	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	private bool spacePressed;
	public int dialogCount;


	private SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spacePressed = false;
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			spacePressed = true;
		}

	}	

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {

			if(spacePressed)
			{
				ChangeTheDamnSprite (); // call method to change sprite
				gameManager.myGameManager.SendMessage("showDialogs", dialogCount, SendMessageOptions.DontRequireReceiver);
				gameManager.myGameManager.chestHasBeenOpened = true;
				gameManager.myGameManager.gameProgress++;
			}
		}
	
	}


	void ChangeTheDamnSprite ()
	{
		if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = sprite2;
		}
		else
		{
			spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
		}
		spacePressed = false;
	}
}
