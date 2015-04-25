using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public bool State;
	private static bool Reebot = false;
	public Transform Player;


	void OnTriggerEnter2D(Collider2D Trigg)
	{
		if (Trigg.gameObject.tag.Equals ("Player")) 
		{
			Reebot = true;
		}
	}

	void OnTriggerExit2D(Collider2D Trigg)
	{
		if (Trigg.gameObject.tag.Equals ("Player")) 
		{
			Reebot = false;
			State = true;
			Debug.Log ("Sali");
		}

	}
	

	// Update is called once per frame
	void Update () {

		if (Attributes.state == (int)Attributes.States.Death)
			Respawn ();

		if (Reebot) 
		{
			State = false;
		}
	}

	public void Respawn()
	{
		if (State) 
		{
			Player.position = transform.position;
			Player.gameObject.SetActive(true);
			Attributes.state = (int)Attributes.States.Main;
		}
	}
}
