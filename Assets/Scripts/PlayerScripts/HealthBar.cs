using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	//This is the script of the healtbar... it have an static method of the damage.
	private static Image imagen;
	//This Damage have to ve updated each time something hurt the player.
	private static float Damage = .0f;

	void Start()
	{
		imagen = GetComponent<Image> ();
		//This method will call the "Restoration" method each "0.01" seconds, so will ignore frames per seconds. 
		InvokeRepeating ("Restoration", .0f, 0.01f);
	}
	// Update is called once per frame
	void Update () {
		//Each time the player is on the "electro" state, the "InvokeRepeating" will call the "electroHurt" method.
		if (Attributes.state == (int)Attributes.States.Electro) 
		{
						InvokeRepeating ("ElectroHurt", 0, 0.01f);
		}
	}

	//The "Heal Factor" Script, this one heals fill the Health Bar each time "InvokeRepeating" method call this.
	//The Amount heal is "estrict" to the "restoration" variable, on the "Attributes". 
	public void Restoration()
	{
		//So it will heal ONLY if the player is on this states, main or stun... or maybe some others more!
		if (Attributes.state == (int)Attributes.States.Main || Attributes.state == (int)Attributes.States.Stun)
		{
			//this is the Fill Amount~
			imagen.fillAmount += Attributes.Restoration;
		}
	}
	
	public void ElectroHurt()
	{
		//each 0.01 seconds, that this is called, it will take damage equal to this.
		Debug.Log ("D:!!!" + Attributes.state);
		imagen.fillAmount -= 0.001f;
	}

	//this is the method to hurt the character!
	public static void DamageTaken()
	{
		Debug.Log ("Problemas!");
		int Prueba = 1;
		if (Prueba == 1)
		imagen.fillAmount -= Damage;

		Prueba = 0;
	}
}
