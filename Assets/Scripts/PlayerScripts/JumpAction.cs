using UnityEngine;
using System.Collections;

public class JumpAction : MonoBehaviour {
	private int cont = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
		CheckFall();
	}

	void Jump(){
		if (Attributes.grounded) {
			Attributes.anim.SetBool("Falling", false);
			cont = 0;
			if(Input.GetKeyDown(KeyCode.Space))
				Attributes.anim.SetBool("JumpButton", true);
		} else {
			if(Input.GetKeyDown(KeyCode.DownArrow) && cont == 0){
				GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Attributes.jumpHeight);
				cont++;
			}
		}
	}
	
	void CheckFall(){
		if(this.GetComponent<Rigidbody2D>().velocity.y < -4.0f)
		{
			Attributes.anim.SetBool("JumpButton", false);
			Attributes.anim.SetBool("Falling", true);
		}
	}
	
	void Up(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Attributes.jumpHeight);
	}
}
