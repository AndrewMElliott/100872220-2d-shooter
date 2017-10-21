using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	[SerializeField]
	private float shipSpeed = 0.2f;
	[SerializeField]
	private float enemyCollisionDamage = 2f;


	[SerializeField]
	private float maxHealth = 5f;

	[SerializeField]
	private GameObject explosionPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ShipControls ();
		Explode ();
	}

	public void SetDamage(float damage){
		PlayerStatsManager.SetPlayerHealth (damage * -1f);
	}

	private void ShipControls ()
	{

		if (Input.GetKey (KeyCode.W)) {
			Vector2 position = this.transform.position;
			position.y += shipSpeed;
			if (position.y > 4.6f) {

			} else {
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			Vector2 position = this.transform.position;
			position.y -= shipSpeed;
			if (position.y < -4.6f) {

			} else {
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			Vector2 position = this.transform.position;
			position.x -= shipSpeed;
			if(position.x < -7.2f)
			{

			}else{
				this.transform.position = position;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector2 position = this.transform.position;
			position.x += shipSpeed;
			if(position.x > 8.9f)
			{

			}else{
				this.transform.position = position;
			}
		}

	}
	private void Explode(){
		if (PlayerStatsManager.GetPlayerHealth() < 1f && PlayerStatsManager.GetCanSpawn()) {
			GameObject anim = Instantiate (explosionPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x , transform.position.y);
			anim.transform.position = spawnPoint;
			PlayerStatsManager.SetPlayerLives (-1f);
			if (PlayerStatsManager.GetPlayerLives () > 0f) {
				Vector2 startPos = new Vector2 (-5.3f, 0f);
				transform.position = startPos;
				PlayerStatsManager.SetPlayerHealth (maxHealth);
				PlayerStatsManager.SetUpgradePoints (-10f);
			} else {
				
				Destroy (gameObject);
				PlayerStatsManager.SetCanSpawn (false);
			}
		}
	}

	 void OnTriggerEnter2D(Collider2D col){		
		if (col.tag == "UpgradeCoin") {
			//Debug.Log ("Trigger Collision: " + col.tag);
			CoinValue value = col.gameObject.GetComponent<CoinValue> ();
			PlayerStatsManager.SetPlayerScore (value.GetCoinValue());
			value.PassUpgradeValue ();
			Destroy (col.gameObject);
		}
		if (col.tag == "Enemy Ship") {
			PlayerStatsManager.SetPlayerHealth (enemyCollisionDamage);
			EnemyAI whoops = col.gameObject.GetComponent<EnemyAI> ();
			whoops.SetDamage (100f);
		}
	}
}
