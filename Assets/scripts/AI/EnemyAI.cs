/* Source File: Scripts/AI
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: This script sets the enemy ship behavior.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	
	[SerializeField]
	private float health = 2f;
	[SerializeField]
	private float shipSpeed = 0.1f;
	[SerializeField]
	private GameObject[] coinPrefab;
	[SerializeField]
	private GameObject explosionPrefab;


	void Update () {
		MoveShip ();
		if (health <= 0f) { 
			Explode ();
		}
		
		if (transform.position.x <= -9f) 
			Destroy (gameObject);
	}

	public void SetDamage(float damage){
		health -= damage;
	}

	private void MoveShip(){
		transform.Translate (Vector2.left * shipSpeed);
	}
		
	private void Explode(){
		GameObject anim = Instantiate (explosionPrefab) as GameObject;
		Vector2 spawnPoint = new Vector2 (transform.position.x , transform.position.y);
		anim.transform.position = spawnPoint;
		DropItem ();
		PlayerStatsManager.SetPlayerScore (1f);
		Destroy (gameObject); 
	}

	private void DropItem(){
		float rng = Random.Range (1, 11);
		if (gameObject.tag == "EliteEnemyShip") {
			GameObject coin = Instantiate(coinPrefab[1]) as GameObject;
			coin.transform.position = transform.position;
		}
		else if (rng <= 4) {
			GameObject coin = Instantiate(coinPrefab[0]) as GameObject;
			coin.transform.position = transform.position;
		}
	}
}
