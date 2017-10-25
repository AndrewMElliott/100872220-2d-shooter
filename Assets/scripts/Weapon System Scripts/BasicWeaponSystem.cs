using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeaponSystem : MonoBehaviour {
	private float fireRate = 2f;
	private float fireCooldown;
	[SerializeField]
	private GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
		fireCooldown = Time.time + Random.Range (0f, 1.5f);
	}

	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	private void Shoot(){
		if (Time.time > fireCooldown) {
			fireCooldown = Time.time + fireRate;
			GameObject bullet = Instantiate (bulletPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x - 0.2f, transform.position.y);
			bullet.transform.position = spawnPoint;
		}
	}
}
