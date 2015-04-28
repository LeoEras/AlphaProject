using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	[Tooltip("Next node attached for the teleport. Null if this is the last Teleporter")]
	public Transform nextNode;
	[Tooltip("Set the number of seconds the teleporter works before shutting down or up. Set to 3 seconds if left in 0 value")]
	public int teleportEnablerTimer;
	[Tooltip("The teleporter state. True for enabled, false for disabled")]
	public bool state;
	//Checks whether the user is fixed to the teleporter.transform.position
	private bool fixedPos;
	//Gets who is getting in the teleporter
	private GameObject user;
	//Calculates the direction for the teleporter to catch the user
	private Vector2 vec;
	private float acum;
	
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(0 , 9);
		Physics2D.IgnoreLayerCollision(0 , 8);
		if(teleportEnablerTimer == 0)
			teleportEnablerTimer = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(state && fixedPos && Input.GetKey(KeyCode.Q) && nextNode != null && user != null){
			acum = acum + Time.deltaTime * 5f;
			user.GetComponent<Rigidbody2D>().position = Vector3.Lerp(transform.position, nextNode.position, acum);
			if(acum >= 1){
				fixedPos = false;
				acum = 0;
				user = null;
			}
		}
		
//		if(!state && user != null){
//			if(user.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SphereState")){
//				Debug.Log(user.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0));
//			} else {
//				user.GetComponent<Animator>().SetBool("TeleportEnter", true);
//				user.GetComponent<Animator>().SetBool("Sphere", true);
//			}
//			
//		}
			
		StartCoroutine("TeleporterState");
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		user = coll.gameObject;
	}
	
	void OnTriggerStay2D(Collider2D coll){
		if(state)
		{	
			vec = transform.position - user.transform.position;
			if(nextNode == null)
			{
				user.GetComponent<Animator>().SetBool("Sphere", false);
				user.GetComponent<Animator>().SetBool("TeleportEnter", false);
				user.GetComponent<Rigidbody2D>().velocity = vec * 0.5f;
			}
			else
			{
				user.GetComponent<Animator>().SetBool("TeleportEnter", true);
				user.GetComponent<Animator>().SetBool("Sphere", true);
				user.GetComponent<Rigidbody2D>().velocity = vec * 5f;	
			}
			if(vec.magnitude < 0.25f)
			{
				fixedPos = true;
				user.transform.position = transform.position;
			}
		}
		else 
		{
			user.GetComponent<Animator>().SetBool("Sphere", false);
			user.GetComponent<Animator>().SetBool("TeleportEnter", false);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll){
		if(!state)
			user = null;
	}
	
	IEnumerator TeleporterState() {
		if(state && user != null)
		{
			yield return new WaitForSeconds(teleportEnablerTimer);
			state = false;
		}
		else 
		{
			yield return new WaitForSeconds(teleportEnablerTimer);
			state = true;
		}
	}
}
