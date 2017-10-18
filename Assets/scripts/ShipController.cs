using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	[SerializeField]
	private float shipSpeed = 0.2f;
	[SerializeField]
	private float fireRate = 0.05f;
	[SerializeField]
	private float health = 5f;
	private float fireCoolDown = 0.0f;
	[SerializeField]
	private GameObject bulletPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ShipControls ();
		Explode ();
	}

	public void SetDamage(float damage){
		health -= damage;
	}

	private void ShipControls ()
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
		if ((Input.GetKey (KeyCode.Space) && Time.time > fireCoolDown + fireRate) || (Input.GetKeyDown(KeyCode.Space))){
			
			GameObject bullet = Instantiate (bulletPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x + 1.5f, transform.position.y);
			bullet.transform.position = spawnPoint;

			fireCoolDown = Time.time;
		}
	}
	private void Explode(){
		if (health <= 0f) {
			Vector2 startPos = new Vector2 (-5.3f, 0f);
			transform.position = startPos;
			health = 1;
		}
	}
}
