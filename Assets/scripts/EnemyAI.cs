using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	[SerializeField]
	private float health = 3f;
	[SerializeField]
	private float shipSpeed = 0.05f;


	void Start () {
		
	}
	

	void Update () {
		MoveShip ();
		Explode ();
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
			Destroy (gameObject);
		}
	}
}
