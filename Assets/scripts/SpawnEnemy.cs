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
	//private bool spawnNormalShips = true;
	//private bool spawnEliteShips = false;
	[SerializeField]
	private float spawnEliteEvery = 5f;
	private float spawnsTillElite = 0f;
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
		if (spawnsTillElite < spawnEliteEvery) {
			SpawnNormal ();
		} else {
			SpawnElite ();
		}
	}

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
				spawnsTillElite++;
			}


		}
	}

	private void SpawnElite(){
		if (Time.time > spawnCooldown ) {
			if (spawnEliteEvery <= 15) {
				float[] yCoords = new float[] { 0f };
				GenerateElites (yCoords);
			} else if (spawnEliteEvery <= 25) {
				float[] yCoords = new float[] { 2f, -2f };
				GenerateElites (yCoords);
			} else if (spawnEliteEvery <= 35) {
				float[] yCoords = new float[] { 3f, 0f, -3f };
				GenerateElites (yCoords);
			}else if (spawnEliteEvery <= 45) {
				float[] yCoords = new float[] { 3.5f, 1.5f, -1.5f, -3.5f };
				GenerateElites (yCoords);
			}else if (spawnEliteEvery <= 65) {
				float[] yCoords = new float[] { 3.5f, 1.5f, 0f, -1.5f, 3.5f };
				GenerateElites (yCoords);
			}else if (spawnEliteEvery <= 85) {
				float[] yCoords = new float[] { 4f, 2.5f, 0.8f, -0.8f, -2.5f, -4f };
				GenerateElites (yCoords);
			}

			spawnsTillElite = 0f;
			if (normalSpawnsPerCD < 9)
				normalSpawnsPerCD++;

			if (spawnEliteEvery >= 1f)
				spawnEliteEvery += 10f;
		
			spawnCooldown += eliteWaveTime;
		}
	}
	private void GenerateElites(float[] yCoords){
		for (int i = 0; i < yCoords.Length; i++) {
			GameObject enemy = Instantiate (eliteEnemyPrefab) as GameObject;
			spawnPoint = new Vector2 (transform.position.x, yCoords [i]);
			enemy.transform.position = spawnPoint;
		}
	}
}
