using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	[SerializeField]
	private float health = 2f;
	[SerializeField]
	private float shipSpeed = 0.1f;



	[SerializeField]
	private GameObject explosionPrefab;


	void Start () {
		
	}
	

	void Update () {
		MoveShip ();
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
