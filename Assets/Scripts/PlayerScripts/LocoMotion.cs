using UnityEngine;
using System.Collections;

public class LocoMotion: MonoBehaviour {
	//This enables the movement. For instance you shouldn't move left nor right as soon as you touch
	//a wall or something.
	public bool enable = true;
	private float moveDir;
	//This is the locomotion class, it have the simple movements of a character, as moving to right or left.
	//As this is the Main character Motion, it will check their Attributes to know the SPEED.
	void Start(){

	}


	// Update is called once per frame
	void Update () 
	{	
		if(Attributes.state == (int)Attributes.States.Main)
			Movement ();
	}

	void Movement()
	{
		//Movement direction controller
		moveDir = Input.GetAxisRaw ("Horizontal");
		if(Attributes.grounded && moveDir != 0)
			Attributes.anim.SetBool("Moving", true);
		else 
			Attributes.anim.SetBool("Moving", false);
		GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x +
		                                                   moveDir * Time.deltaTime * Attributes.speed, 
		                                                   GetComponent<Rigidbody2D>().position.y);
		//Facing angle controller
		if (moveDir > 0)
			transform.eulerAngles = new Vector2 (0, 0);
		else if (moveDir < 0)
			transform.eulerAngles = new Vector2 (0, 180);
	}
}

// the 'transform.eulerAngles':
// will rotate the Main character to the Completly Right if the user indicates the right arrow.
// or Will rotate the Main Character to the Completly Left if the user indicates the left arrow.
