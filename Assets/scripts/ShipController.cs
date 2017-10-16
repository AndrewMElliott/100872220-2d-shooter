using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	[SerializeField]
	private float shipSpeed = 5f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveShip ();
	}

	private void MoveShip ()
	{

		if (Input.GetKey (KeyCode.W)) {
			Vector2 position = this.transform.position;
			position.y += shipSpeed;
			if (position.y > 4.6) {

			} else {
				this.transform.position = position;
			}
				

		}
		if (Input.GetKey (KeyCode.S)) {
			Vector2 position = this.transform.position;
			position.y -= shipSpeed;
			if (position.y < -4.6) {

			} else {
				this.transform.position = position;
			}

		}
		if (Input.GetKey (KeyCode.A)) {
			Vector2 position = this.transform.position;
			position.x -= shipSpeed;
			if(position.x < -7.2)
			{

			}else{
				this.transform.position = position;
			}

		}
		if (Input.GetKey (KeyCode.D)) {
			Vector2 position = this.transform.position;
			position.x += shipSpeed;
			if(position.x > 6.5)
			{

			}else{
				this.transform.position = position;
			}

		}
	}
}
