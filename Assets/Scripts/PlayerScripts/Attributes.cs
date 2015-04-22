using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {

	//This class Will have ALL the Attributes that the Main Character have.
	//The Attributes Can be booleans or a float value and always STATIC.
	//This class only apply on the Main Character.

	#region Attributes
	public static float speed = 5.0f, jumpHeight = 10f;
	public Transform gndColl;
	public GameObject player;
	public static bool grounded;
	public enum States{Main, Soul, Electro, Stun};
	public static int state = 0;
	public static Animator anim;
	public static float Restoration = 0.0005f;
	#endregion

	void Start(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		CheckGround ();
	}

	#region CheckConditionsMethods
	void CheckGround(){
		grounded = Physics2D.Linecast (this.transform.position, gndColl.position, 1 << LayerMask.NameToLayer("Ground"));
	}
	#endregion
}
