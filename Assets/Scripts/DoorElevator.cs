using UnityEngine;
using System.Collections;

public class DoorElevator : MonoBehaviour {

	public Transform RightDoor, LeftDoor;
	public float Speed = 5f, TempSpeed, CloseSpeed, Limit;
	private Vector3 RightVectIn, LeftVectIn, RightLimit, LeftLimit;
	private SpriteRenderer Right, Left;
	public ElevatorBehaviour Lift;


	void Start()
	{
		RightVectIn = RightDoor.position;
		LeftVectIn = LeftDoor.position;
		TempSpeed = Speed;
		CloseSpeed = Speed;

		Right = RightDoor.GetComponent<SpriteRenderer> ();
		Left = LeftDoor.GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		RightVectIn.y = RightDoor.position.y;
		RightLimit.x = RightVectIn.x + Limit;
		LeftVectIn.y = LeftDoor.position.y;

	}

	public void OpenDoor()
	{
		RightDoor.transform.Translate (Vector3.right * TempSpeed/10 * Time.deltaTime);
		LeftDoor.transform.Translate (Vector3.left * TempSpeed/10 * Time.deltaTime);

		if ((float)RightDoor.position.x >= (float)RightLimit.x) 
		{
			TempSpeed = 0;
			Lift.SetOpening(false);

			Right.sortingOrder = 1;
			Left.sortingOrder = 1;
		}
				else 
						TempSpeed = Speed;
	}

	public void CloseDoor()
	{
		RightDoor.transform.Translate (Vector3.left * CloseSpeed/10 * Time.deltaTime);
		LeftDoor.transform.Translate (Vector3.right * CloseSpeed/10 * Time.deltaTime);

		Right.sortingOrder = 3;
		Left.sortingOrder = 3;
		if (RightDoor.position.x <= RightVectIn.x) 
		{
			Lift.SetEnding (true);
			CloseSpeed = 0;
		} else
			CloseSpeed = Speed;
	}
}
