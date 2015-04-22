using UnityEngine;
using System.Collections;


//This script REQUIRED two tags, the "CableH" and/or the "CableV" tag.
//Needs the GameObject of the Electric Ball thing.
public class ElektroChange : MonoBehaviour {
	
	public Vector3 Posicion;
	public Transform Elekid;

	//This function activates every time the gameObject Stay on a Trigger tagged with the "CableH" or "CableV"
	void OnTriggerStay2D(Collider2D Trig)
	{
		//If the triggered object's tag is the "CableH", the position on the X axis won't change.
		//for this. the position of the Electric Ball thing on the X axis is equal of the x axis position of the GameObject.
		if (Trig.gameObject.tag.Equals ("CableH"))
		{
			Posicion = Trig.transform.position;
			if (Input.GetKey(KeyCode.R) )
			{
				Posicion.x = transform.position.x;
				Elekid.position = Posicion;

				Elekid.gameObject.SetActive(true);
				this.gameObject.SetActive(false);
				Attributes.state = (int) Attributes.States.Electro;
			}
		}
		//this does the same of the previous function, but the position change to the Y axis.
		if (Trig.gameObject.tag.Equals ("CableV"))
		{
			Posicion = Trig.transform.position;
			if (Input.GetKey(KeyCode.R) )
			{
				Posicion.y = transform.position.y;
				Elekid.position = Posicion;
				
				Elekid.gameObject.SetActive(true);
				this.gameObject.SetActive(false);
				Attributes.state = (int) Attributes.States.Electro;
			}
		}
	}

}
