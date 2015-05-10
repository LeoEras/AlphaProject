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
	//Rigibody to use some methods for the lift and for the player.
	public Rigidbody2D Lift, PlayerBody;
	//This forces "ignores" other forces. At least gravity.
	public ConstantForce2D ConstantLift;
	public DoorElevator Door;

	//there's no reason to make this vector 3 public.
	private Vector3 Vect, Posi, Prueba;
	//this booleans will help me to open or close the door.
	private bool Opening = false, Closed = true;
	private float PlayerGravity;

	void OnCollisionStay2D(Collision2D Coll)
	{
		//technically this 'if' means if the user is almost at the middle of the Lift, the lift can move and is touching the lift.
		if (Turner.GetStatus() && Coll.collider.name.Equals ("Player")) {
			//This little block helps to move the user to the center of the lift.
			if(CoolDown == 5)
			{
				//This just going to make the movement automacly to the center... and rotate the player if is necessary.
				if(Player.position.x - transform.position.x > 0)
					Player.eulerAngles = new Vector2 (0, 180);
				else
					Player.eulerAngles = new Vector2 (0, 0);
				//This one moves the player... the another just makes it rotate.
				Player.position = Vector3.MoveTowards(Player.position, Posi, Attributes.speed/150);
			}
			if ( (float) Player.position.x == Vect.x)
			{
				//Making the gravity of the player to "0".
				PlayerBody.gravityScale = 0;
				//HERE'S AND ERROR!!... well is not aaan error... is just that... something...
				//It's a lie it's a lie, there's no error~
				Lift.isKinematic = false;

				//If that happends, the player won't move until reach the max. Height. that's the "stun" state of the player.
				Attributes.state = (int)Attributes.States.Stun;

				if (CoolDown > 2)
				{
					//So now, the door will open!
					Opening = true;
					Closed = false;
				}
				CoolDown = 2;
				//read the "DoorElevator.cs" Script to understand that once is open... the boolean "opening" becomes false
				if (Opening == false)
				{
					//Once is fully open... this have to close~
					Door.CloseDoor();	
				}
				//If is closed and won't open... well... the lift will rise (the "isKinematic" option must been here...
				//But for some reason when I put it here... well... just stop working =(
				if(Opening == false && Closed)
				{
					//As I said, the Lift will have a contant force, so will ignore gravity when is going up.
					ConstantLift.force = Vector2.up * Speed;
					//This will give the normal gravity to the player
					PlayerBody.gravityScale = PlayerGravity;
					//Going to stop ignore it!
					Physics2D.IgnoreLayerCollision (8, 8,false);
				}
			}
		}
		//So finally reach the top!... this what happend...
		if ((int)transform.position.y >= (int)Vect.y)
		{
			if(CoolDown >= 0 )
			{
				//This will open the door one more time!
				Opening = true;
				//This will make the player not to jump when the Lift suddenly stop.
				//It actually make not to move anywhere... but just for a few fraction of seconds.
				PlayerBody.velocity = Vector3.zero;
				//Once the lift reach the top... there's a tiny cooldown, that actually ends few fraction of seconds the player reach the top.
				CoolDown -= 1;
			}
			//Now the player won't move until the door is fully open!... because that's elegant(?)
			if (Opening == false)
			{
				//The player may move again... just if he want to :D
				Attributes.state = (int)Attributes.States.Main;
			}

		}
	}

	void Start()
	{
		//Have to change this to make the vector more... dinamyc.
		Posi = transform.position;
		Lift.isKinematic = true;
		PlayerGravity = PlayerBody.gravityScale;
		//To ignore the Ground Layer.
		Physics2D.IgnoreLayerCollision (8, 8);
	}


	// Update is called once per frame
	void Update () {
		ElevatorMovement ();
		Posi.y = Player.position.y;
		//This line will draw just to let know where the top is.
		Vect = transform.position;
		Vect.y = Height;
		Debug.DrawLine (transform.position, Vect, Color.blue);
		//Well if is opening... the door must open~ 
		//Read the "DoorElevator.cs" script to understan that once is fully open.. the "Opening" parameter becomes false
		if (Opening)
						Door.OpenDoor ();

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

	//Just setters used on the "DoorElevator.cs"
	public void SetOpening(bool IsOpening)
	{
		Opening = IsOpening;
	}

	public void SetEnding(bool IsClosed)
	{
		Closed = IsClosed;
	}
}
