/* Source File: Scripts/PlayerControllers
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Script to control the player ship. This script controls player movements,
 * 				fire control, death explosion animation and collision detection.
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {

	[SerializeField]
	private float shipSpeed = 0.2f;
	[SerializeField]
	private float enemyCollisionDamage = 2f;
	[SerializeField]
	private float maxHealth = 5f;
	[SerializeField]
	private GameObject explosionPrefab;
	private AudioSource[] allAudio;
	private AudioSource explosionSound;
	private AudioSource hurtSound;

	void Start(){
		allAudio = GetComponents<AudioSource> ();
		explosionSound = allAudio [1];
		hurtSound = allAudio [0];
	}
	// Update is called once per frame
	void Update () {
		ShipControls ();
		Explode ();

	}
	// sends damage to player stat manager. Positive number decreases health.
	public void SetDamage(float damage){
		PlayerStatsManager.SetPlayerHealth (damage * -1f);
	}
	//Moves ship around the game area. Standard WASD keys.
	private void ShipControls ()
	{
		if (Input.GetKey (KeyCode.W)) {
			Vector2 position = this.transform.position;
			position.y += shipSpeed;
			if (position.y > 4.6f) 
			{}
			else {
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			Vector2 position = this.transform.position;
			position.y -= shipSpeed;
			if (position.y < -4.6f) 
			{} 
			else {
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			Vector2 position = this.transform.position;
			position.x -= shipSpeed;
			if(position.x < -7.2f)
			{}
			else{
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector2 position = this.transform.position;
			position.x += shipSpeed;
			if(position.x > 8.9f)
			{}
			else{
				this.transform.position = position;
			}
		}
	}
	//Checks condition for player explosion
	private void Explode(){
		if (PlayerStatsManager.GetPlayerHealth() < 1f && PlayerStatsManager.GetCanSpawn()) {
			GameObject anim = Instantiate (explosionPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x , transform.position.y);
			anim.transform.position = spawnPoint;
			PlayerStatsManager.DecrementPlayerLives (1f);
			explosionSound.Play ();
			Spawn ();
		}
	}
	//Spawn player on death if there are lives left.
	private void Spawn(){
		if (PlayerStatsManager.GetPlayerLives () > 0f) {
			Vector2 startPos = new Vector2 (-5.3f, 0f);
			transform.position = startPos;
			PlayerStatsManager.SetPlayerHealth (maxHealth);
			PlayerStatsManager.SetUpgradePoints (-10f);
		} else {
			
			PlayerStatsManager.SetCanSpawn (false);
			SceneManager.LoadScene ("game_over");
			Destroy (gameObject);
		}
	}
	//trigger detection for enemy ships and coins.
	 void OnTriggerEnter2D(Collider2D col){		
		if (col.tag == "UpgradeCoin") {
			//Debug.Log ("Trigger Collision: " + col.tag);
			CoinValue value = col.gameObject.GetComponent<CoinValue> ();
			PlayerStatsManager.SetPlayerScore (value.GetCoinValue());
			value.PassUpgradeValue ();
			Destroy (col.gameObject);
		}
		if (col.tag == "Enemy Ship" || col.tag == "EliteEnemyShip") {
			PlayerStatsManager.SetPlayerHealth (-enemyCollisionDamage);
			EnemyAI collide = col.gameObject.GetComponent<EnemyAI> ();
			if (col.tag == "EliteEnemyShip") {
				collide.SetDamage (5f);
			} else {
				collide.SetDamage (100f);
			}
			hurtSound.Play ();
		}
	}
}
