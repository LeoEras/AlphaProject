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
	}

	void Jump(){
		if (Attributes.grounded) {
			cont = 0;
			if(Input.GetKeyDown(KeyCode.Space))
				GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Attributes.jumpHeight);
		} else {
			if(Input.GetKeyDown(KeyCode.DownArrow) && cont == 0){
				GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Attributes.jumpHeight);
				//GetComponent<Rigidbody2D>().AddForce(Vector2.up * Attributes.jumpHeight);
				cont++;
			}
		}
	}
}
