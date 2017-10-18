using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	[SerializeField]
	private float health = 2f;
	[SerializeField]
	private float shipSpeed = 0.1f;
	private float maxY;
	private float minY;
	[SerializeField]
	private float fireRate = 2f;
	private float fireCooldown = 0f;
	[SerializeField]
	private GameObject bulletPrefab;
	[SerializeField]
	private GameObject explosionPrefab;


	void Start () {
		
	}
	

	void Update () {
		MoveShip ();
		Shoot ();
		Explode ();
		if (transform.position.x <= -9f) {
			Destroy (gameObject);
		}
	}

	public void SetDamage(float damage){
		health -= damage;
	}

	private void MoveShip(){
		transform.Translate (Vector2.left * shipSpeed);
	}

	private void Shoot(){
		if (Time.time > fireCooldown) {
			fireCooldown = Time.time + fireRate;
			GameObject bullet = Instantiate (bulletPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x - 1.2f, transform.position.y);
			bullet.transform.position = spawnPoint;
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		

	}

	private void Explode(){
		if (health <= 0f) {
			GameObject anim = Instantiate (explosionPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x , transform.position.y);
			anim.transform.position = spawnPoint;
			Destroy (gameObject);
		}
	}
}
