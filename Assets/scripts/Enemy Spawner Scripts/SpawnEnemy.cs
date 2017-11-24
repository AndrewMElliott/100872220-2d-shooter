/* Source File: Scripts/Enemy Spawner Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: This script controls the enemy spawner behavior. 
 * 				Enemies are spawned in specific positions around the spawner object.
 * 				Number of normal enemies and elites increase over time.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject normalEnemyPrefab;
	[SerializeField]
	private GameObject eliteEnemyPrefab;
	private Vector2 spawnPoint;
	[SerializeField]
	private float spawnTime = 2f;
	private float spawnCooldown = 0f;
	private float normalSpawnsPerCD = 1f;

	[SerializeField]
	private float spawnEliteThreshold = 5f;
	private float normalSpawnCount = 0f;
	[SerializeField]
	private float eliteWaveTime = 10f;
	private float objectX; 
	private float objectY; 

	void Start () {
		objectX = transform.position.x;
		objectY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (normalSpawnCount < spawnEliteThreshold) {
			SpawnNormal ();
		} else {
			SpawnElite ();
		}
	}
	// Spawns normal enemies in 9 specific y positions.
	private void SpawnNormal(){
		if (Time.time > spawnCooldown) {
			List<float> yCoords = new List<float> {objectY+4f, objectY+3f, objectY+2f, objectY+1f, objectY, objectY-1f, objectY-2f, objectY-3f, objectY-4f};
			List<float> xCoords = new List<float> {objectX - 1f,objectX - 0.5f, objectX - 0f, objectX + 0.5f, objectX + 1f};
			spawnCooldown = Time.time + spawnTime;
			for (int i = 0; i < normalSpawnsPerCD; i++) {
				int positionX = Random.Range (0,5);
				int positionY = Random.Range (0,yCoords.Count);

				GameObject enemy = Instantiate (normalEnemyPrefab) as GameObject;
				spawnPoint = new Vector2 (xCoords[positionX], yCoords[positionY]);
				enemy.transform.position = spawnPoint;
				yCoords.RemoveAt(positionY);
				normalSpawnCount++;
			}


		}
	}
	//spawns elite enemies every x amount of normal spawn waves. 
	private void SpawnElite(){
		if (Time.time > spawnCooldown ) {
			if (spawnEliteThreshold <= 15) {
				float[] yCoords = new float[] { 0f };
				GenerateElites (yCoords);
			} else if (spawnEliteThreshold <= 25) {
				float[] yCoords = new float[] { 2f, -2f };
				GenerateElites (yCoords);
			} else if (spawnEliteThreshold <= 35) {
				float[] yCoords = new float[] { 3f, 0f, -3f };
				GenerateElites (yCoords);
			}else if (spawnEliteThreshold <= 45) {
				float[] yCoords = new float[] { 3.5f, 1.5f, -1.5f, -3.5f };
				GenerateElites (yCoords);
			}else if (spawnEliteThreshold <= 65) {
				float[] yCoords = new float[] { 3.5f, 1.5f, 0f, -1.5f, 3.5f };
				GenerateElites (yCoords);
			}else if (spawnEliteThreshold <= 85) {
				float[] yCoords = new float[] { 4f, 2.5f, 0.8f, -0.8f, -2.5f, -4f };
				GenerateElites (yCoords);
			}
			// increases normal enemies per wave by 1 after every elite wave.
			normalSpawnCount = 0f;
			if (normalSpawnsPerCD < 9)
				normalSpawnsPerCD++;

			//if (spawnEliteThreshold >= 1f)
				spawnEliteThreshold += 10f;
			//delay next normal spawn wave.
			spawnCooldown += eliteWaveTime;
		}
	}
	//spawn elite mobs at given coordinates.
	private void GenerateElites(float[] yCoords){
		for (int i = 0; i < yCoords.Length; i++) {
			GameObject enemy = Instantiate (eliteEnemyPrefab) as GameObject;
			spawnPoint = new Vector2 (transform.position.x, yCoords [i]);
			enemy.transform.position = spawnPoint;
		}
	}
}
