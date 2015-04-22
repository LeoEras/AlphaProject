using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {
	public Transform player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Follow ();
//		transform.position = new Vector3(Mathf.Clamp (transform.position.x, 1.65f, 45f), 
//		                                 Mathf.Clamp (transform.position.y, 1.45f, 5.3f), 
//		                                 transform.position.z);
	}

	void Follow(){
		this.transform.position = new Vector3(player.position.x, player.position.y, -10);
	}
}
