using UnityEngine;
using System.Collections;

public class PlatformMov : MonoBehaviour {

//This Script will let a class move up/down or right/left with each speed, on 'x' as on 'y'.
//MaxLong is the maximum displacement on the 'x' axis.
//High is the maximum displacement on the 'y' axis.
	public float MaxLong = 0.0f, High = 5.0f, OscilationSpeedY = 3.0f, OscilationSpeedX = 0.0f;
	private Vector3 PosInitial;
	
//This will start a point just up or right from the object, by adding the firs position with the MaxLong or High.	
	void Start(){
		High = High + transform.position.y;
		MaxLong = MaxLong + transform.position.x;
		PosInitial.y = transform.position.y;
		PosInitial.x = transform.position.x;
	}

	void Update () {
		PlatformMotion();
	}


	void PlatformMotion()
	{
	//If the Object position on the 'y' axis is greater than the top, the platform will lower.
		if (transform.position.y >= High)
			OscilationSpeedY = OscilationSpeedY * -1;
	//If the Object position on the 'y' axis is the same as its original position, the platform will upper.
		if (transform.position.y <= PosInitial.y - 0.1f)
			OscilationSpeedY = OscilationSpeedY * -1;


	//If the Object position on the 'x' axis is greater than the Maximum Long, the platform will go to the left.
		if (transform.position.x >= MaxLong)
			OscilationSpeedX = OscilationSpeedX * -1;
	//if the Object position on the 'x' axis is the same as its original position, the platform will go to the right.
		if (transform.position.x <= PosInitial.x - 0.01f)
			OscilationSpeedX = OscilationSpeedX * -1;
	
	//this are the speed on 'x' axis and 'y' axis.
		transform.Translate ( Vector2.up * OscilationSpeedY * Time.deltaTime );
		transform.Translate ( Vector2.right * OscilationSpeedX * Time.deltaTime );
		
	}
}