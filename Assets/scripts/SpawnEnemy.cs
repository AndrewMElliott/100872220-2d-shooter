using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;
	private Vector2 spawnPoint;
	[SerializeField]
	private float spawnTime = 2f;
	private float spawnCooldown = 0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Spawn ();
	}

	private void Spawn(){
		if (Time.time > spawnCooldown) {

			spawnCooldown = Time.time + spawnTime;
			float positionY = Random.Range (-4.2f, 4.2f);
			GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			spawnPoint = new Vector2 (transform.position.x, positionY);
			enemy.transform.position = spawnPoint;
		}
	}
}
