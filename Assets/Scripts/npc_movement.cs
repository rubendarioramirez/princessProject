using UnityEngine;
using System.Collections;

public class npc_movement : MonoBehaviour {

	public float speed;
	public float random;
	private int walkDirection;
	private bool pause = false;
	private Animator anim;
	public int waitTime;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
		StartCoroutine(MyCoroutine(waitTime));

		random = Random.Range (0.1f, 0.8f);
		speed = random;
	}

	//Triggers a different walkDirection every 3 seconds
	IEnumerator MyCoroutine(int waitTime)
	{
		while (pause == false)
		{
		
			int randomDirection = Random.Range(0,5);
			walkDirection = randomDirection;
			yield return new WaitForSeconds(waitTime);

			/*
			walkDirection = 0;
				yield return new WaitForSeconds(waitTime);

			walkDirection = 1;
				yield return new WaitForSeconds(waitTime);

			walkDirection = 0;
				yield return new WaitForSeconds(waitTime);

			walkDirection = 2;
				yield return new WaitForSeconds(waitTime);

			walkDirection = 0;
			yield return new WaitForSeconds(waitTime);
				
			walkDirection = 3;
			yield return new WaitForSeconds(waitTime);

			walkDirection = 0;
			yield return new WaitForSeconds(waitTime);

			walkDirection = 4;
			yield return new WaitForSeconds(waitTime);
			*/

		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		catchDirection ();

	}

	void catchDirection(){
		switch (walkDirection) {
		case 0:
			idleChicken();
			break;
		case 1:
			walk_left();
			break;
		case 2:
			walk_right();
			break;
		case 3:
			walk_up();
			break;
		case 4:
			walk_down();
			break;
			
		} 
	}

	void walk_left()
	{
		transform.Translate (-speed * Time.deltaTime, 0, 0);
		anim.SetTrigger("walk_left");
	}
	void walk_right()
	{
		transform.Translate (speed * Time.deltaTime, 0, 0);
		anim.SetTrigger("walk_right");
	}
	void walk_up()
	{
		transform.Translate (0, speed * Time.deltaTime, 0);
		anim.SetTrigger("walk_up");
	}
	void walk_down()
	{
		transform.Translate (0, -speed * Time.deltaTime, 0);
		anim.SetTrigger("walk_down");
	}
	void idleChicken()
	{
		anim.SetTrigger("idle");
	}

	/* Deprecated way of chicken walking
	void walking(){
		if (origX - transform.position.x > distance) {
			switchDirection = true;
			anim.SetTrigger ("walk_left");
		} else if (origX - transform.position.x < -distance) {
			switchDirection = false;
			anim.SetTrigger ("walk_right");
		}
		if (switchDirection) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		} else {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}

	}
*/

}
