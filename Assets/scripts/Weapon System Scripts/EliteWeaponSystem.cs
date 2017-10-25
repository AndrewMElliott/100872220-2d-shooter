using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteWeaponSystem : MonoBehaviour {
	private float fireRate = 2f;
	private float fireCooldown = 0f;
	[SerializeField]
	private GameObject bulletOnePrefab;
	[SerializeField]
	private GameObject bulletTwoPrefab;
	[SerializeField]
	private GameObject bulletThreePrefab;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	private void Shoot(){
		if (Time.time > fireCooldown) {
			fireCooldown = Time.time + fireRate;

			GameObject bullet = Instantiate (bulletOnePrefab) as GameObject;
			GameObject bulletTwo = Instantiate (bulletTwoPrefab) as GameObject;
			GameObject bulletThree = Instantiate (bulletThreePrefab) as GameObject;

			Vector2 spawnPoint = new Vector2 (transform.position.x - 0.2f, transform.position.y);
			bullet.transform.position = spawnPoint;
			bulletTwo.transform.position = spawnPoint;
			bulletThree.transform.position = spawnPoint;
		}
	}
}
