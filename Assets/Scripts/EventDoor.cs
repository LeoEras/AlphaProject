using UnityEngine;
using System.Collections;

public class EventDoor : MonoBehaviour {
	public GameObject movable;
	[Tooltip("Velocidad de movimiento en X")]
	public float speedX;
	[Tooltip("Velocidad de movimiento en Y")]
	public float speedY;
	[Tooltip("Maximo valor referente a la posicion local de la puerta en X")]
	public float maxX;
	[Tooltip("Maximo valor referente a la posicion local de la puerta en Y")]
	public float maxY;
	[Tooltip("Minimo valor referente a la posicion local de la puerta en X")]
	public float minX;
	[Tooltip("Minimo valor referente a la posicion local de la puerta en Y")]
	public float minY;
	[Tooltip("Eje por el cual la puerta se mueve true->X, false->Y")]
	public bool direction;
	public bool open;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		OpenCloseDoor ();
	}

	//Si entra en el area definida como trigger
	void OnTriggerStay2D(Collider2D other){
		if (Input.GetKeyDown (KeyCode.E)) {
			open = !open;
		}
	}

	void OpenCloseDoor(){
		if (open) {
				movable.transform.localPosition = new Vector3 (Mathf.Clamp(movable.transform.localPosition.x + speedX * Time.deltaTime, minX, maxX), 
				                                               Mathf.Clamp(movable.transform.localPosition.y + speedY * Time.deltaTime, minY, maxY), 
				                                               0);
		} else {
				movable.transform.localPosition = new Vector3 (Mathf.Clamp(movable.transform.localPosition.x - speedX * Time.deltaTime, minX, maxX), 
				                                               Mathf.Clamp(movable.transform.localPosition.y - speedY * Time.deltaTime, minY, maxY), 
				                                               0);
		}
	}
}