using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour {
	[SerializeField]
	private float fireRate = 0.05f;
	private float fireCoolDown = 0.0f;
	[SerializeField]
	private GameObject bulletOnePrefab;
	[SerializeField]
	private GameObject bulletTwoPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey (KeyCode.Space) && Time.time > fireCoolDown + fireRate) || (Input.GetKeyDown(KeyCode.Space))){

			GameObject bullet = Instantiate (bulletOnePrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x + 0.2f, transform.position.y);
			bullet.transform.position = spawnPoint;

			fireCoolDown = Time.time;
		}
	}
}
