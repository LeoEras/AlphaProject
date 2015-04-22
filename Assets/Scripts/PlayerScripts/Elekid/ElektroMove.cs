using UnityEngine;
using System.Collections;

public class ElektroMove : MonoBehaviour {
	
	public float Speed;
	public bool CanMoveR, CanMoveL, CanMoveU, CanMoveD;
	public int Prueba;
	public Transform MainChar;


	void Update()
	{
		Change ();
		Movement ();
	}
//this trigger works for the permission of the movement on the ElectroBall state.
	void OnTriggerEnter2D(Collider2D Trig)
	{

		if (Trig.gameObject.tag.Equals ("Cable")) 
		{
			//Here the gameObject is already an "ElektroBall"
			Debug.Log("Deberias de moverte >:C");
			Attributes.state = (int) Attributes.States.Electro;
		}

		//If touch the right Limit, it can't move to the right.
		if (Trig.gameObject.tag.Equals ("RightLimit") ) 
		{
			Debug.Log ("Entro en un limite derecho");
			CanMoveR = false;
		}
		//If touch the right Limit, it can't move to the Left.
		if (Trig.gameObject.tag.Equals ("LeftLimit") ) 
		{
			Debug.Log ("Entro en un limite izquierdo");
			CanMoveL = false;
		}
		//If touch the right Limit, it can't move to the Up.
		if (Trig.gameObject.tag.Equals ("UpLimit") ) 
		{
			Debug.Log ("Entro en un limite Arriba");
			CanMoveU = false;
		}
		//If touch the right Limit, it can't move to the Down.
		if (Trig.gameObject.tag.Equals ("DownLimit") ) 
		{
			Debug.Log ("Entro en un limite Abajo");
			CanMoveD = false;
		}

	}
	//This function allow to move if it can move.
	//NOTE: there must be gameObjects with the follower tags:
	// "RightLimit", if it can't move to the right
	// "LeftLimit", if it can't move to the left
	// "UpLimit", if it can't move to the up
	// "DownLimit", if it can't move to the down
	void OnTriggerExit2D(Collider2D Trig)
	{
		if (Trig.gameObject.tag.Equals ("RightLimit"))
		{
			Debug.Log ("Salio del limite derecho");
			CanMoveR = true;
		}

		if (Trig.gameObject.tag.Equals ("LeftLimit"))
		{
			Debug.Log ("Salio del limite izquierdo");
			CanMoveL = true;
		}

		if (Trig.gameObject.tag.Equals ("UpLimit"))
		{
			Debug.Log ("Salio del limite Superior");
			CanMoveU = true;
		}
		
		if (Trig.gameObject.tag.Equals ("DownLimit"))
		{
			Debug.Log ("Salio del limite Inferior");
			CanMoveD = true;
		}
		//this one just in case of an error or something.
		if (Trig.gameObject.tag.Equals ("Cable")) 
		{
			Debug.Log ("Se salio puej mi pez :c");
		}

	}

	void Movement()
	{
		//Let's remember that the "state '2' " is the "Elektroball" state.
		if (Attributes.state == 2) 
		{
			//To move to the right.
			if (Input.GetKey (KeyCode.RightArrow) && CanMoveR ) {
				transform.Translate (Vector3.right * Speed * Time.deltaTime);
			}
			//To the left.
			if (Input.GetKey (KeyCode.LeftArrow) && CanMoveL) {
				transform.Translate (Vector3.right * -Speed * Time.deltaTime);
			}
			//to move up.
			if (Input.GetKey (KeyCode.UpArrow) && CanMoveU) {
				transform.Translate (Vector3.up * Speed * Time.deltaTime);
			}
			//To move down.
			if (Input.GetKey (KeyCode.DownArrow) && CanMoveD) {
				transform.Translate (Vector3.down * Speed * Time.deltaTime);
			}
		}
	}
	//This is a 'plus' of the script... with this, the gameObject will change to ElektroBall to the Main Character.
	void Change()
	{
		if (Input.GetKey(KeyCode.D) && Attributes.state == 2 )
		{
			Attributes.state = (int) Attributes.States.Main;
			MainChar.transform.position = this.transform.position;
			this.gameObject.SetActive(false);
			MainChar.gameObject.SetActive(true);
			//Everithing on 'true' so is a reseting of the condition.
			CanMoveL = true;
			CanMoveR = true;
			CanMoveU = true;
			CanMoveD = true;
		}
	}

}
