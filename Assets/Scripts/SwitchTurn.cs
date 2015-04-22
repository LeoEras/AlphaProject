using UnityEngine;
using System.Collections;

public class SwitchTurn : MonoBehaviour {

	public bool Switch;


	void OnTriggerStay2D(Collider2D Trig)
	{
		//This if just works if the switch Trigg a Player tag object... It means the player.
		//And if he press the Action button
		if (Trig.tag.Equals ("Player") && Input.GetKey (KeyCode.E)) 
		{
			Debug.Log ("Lift is on");
			Switch = true;
		}
	}
	// Update is called once per frame
	void Update () {
		GetStatus ();
	}

	public bool GetStatus()
	{
		//Well.. this turn down for what?!...(?) just return the state of the Switch, "Active"(true) or "Inactive"(false)
		return Switch;
	}
}
