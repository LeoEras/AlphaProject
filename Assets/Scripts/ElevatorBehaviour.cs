using UnityEngine;
using System.Collections;

public class ElevatorBehaviour : MonoBehaviour {

	//This is the switch that will activate the Lift.
	public SwitchTurn Turner;
	public Transform Player;
	//This floats have:
	// > the speed the lift will up (as a force)
	// > the Height the Lift will up
	// >A cooldown that only works to the player to not to move for a sec when the lift reach the top.
	public float Speed, Height, CoolDown = 5f;
	//there's no reason to make this vector 3 public.
	private Vector3 Vect, Posi, Prueba;
	//Rigibody to use some methods for the lift and for the player.
	public Rigidbody2D Lift, PlayerBody;
	//This forces "ignores" other forces. At least gravity.
	public ConstantForce2D ConstantLift;

	void OnCollisionStay2D(Collision2D Coll)
	{
		//technically this 'if' means if the user is almost at the middle of the Lift, the lift can move and is touching the lift.
		if (Turner.GetStatus() && Coll.collider.name.Equals ("Player")) {

			if(CoolDown == 5)
			{

				if(Player.position.x - transform.position.x > 0)
					Player.eulerAngles = new Vector2 (0, 180);
				else
					Player.eulerAngles = new Vector2 (0, 0);

				Player.position = Vector3.MoveTowards(Player.position, Posi, Attributes.speed/150);
			}
			if ( (float) Player.position.x == Vect.x)
			{
				CoolDown = 2;
				//If that happends, the player won't move until reach the max. Height. that's the "stun" state of the player.
				Attributes.state = (int)Attributes.States.Stun;
				//As I said, the Lift will have a contant force, so will ignore gravity when is going up.
				ConstantLift.force = Vector2.up * Speed;
				Lift.isKinematic = false;
			}
		}
		//So finally reach the top!... this what happend...
		if ((int)transform.position.y >= (int)Vect.y)
		{
			//The player may move again... just if he want to :D
			Attributes.state = (int)Attributes.States.Main;
			if(CoolDown >= 0)
			{
				//This will make the player not to jump when the Lift suddenly stop.
				//It actually make not to move anywhere... but just for a few fraction of seconds.
				PlayerBody.velocity = Vector3.zero;
				//Once the lift reach the top... there's a tiny cooldown, that actually ends few fraction of seconds the player reach the top.
				CoolDown -= 1;
			}


		}
	}

	void Start()
	{
		//Have to change this to make the vector more... dinamyc.
		Posi = transform.position;
		Lift.isKinematic = true;
	}


	// Update is called once per frame
	void Update () {
		ElevatorMovement ();
		Posi.y = Player.position.y;
		//This line will draw just to let know where the top is.
		Vect = transform.position;
		Vect.y = Height;
		Debug.DrawLine (transform.position, Vect, Color.blue);

	}

	public void ElevatorMovement()
	{
		//This method will suddenly stop the Lift!... once this reach the top~
		if ((int)transform.position.y >= (int)Vect.y) {
			Lift.velocity = Vector3.zero;
			//Making it kinematic just to be sure that the lift won't move... anymore!
			Lift.isKinematic = true;
		}
	}
}
