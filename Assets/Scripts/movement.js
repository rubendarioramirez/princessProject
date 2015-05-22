#pragma strict


var speed = 1.5f;

function Start () {

}

function Update () {

 if (Input.GetKey(KeyCode.LeftArrow))
         {
         	Debug.Log("Left Pressed");
             transform.position += Vector3.left * speed * Time.deltaTime;
         }

}