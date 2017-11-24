/* Source File: Scripts/Weapon System Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Normal weapon scripts the normal enemy ship AI uses. 
 * */

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
		//adds a small random increase to the cooldown in order to help stagger the shots
		//when enemies spawn so they aren't shooting in unison.
		fireCooldown = Time.time + Random.Range (0f, 1.5f);
	}

	// Update is called once per frame
	void Update () {
		Shoot ();
	}
	//Checks for cooldown is up, then instantiates bullet.
	private void Shoot(){
		if (Time.time > fireCooldown) {
			fireCooldown = Time.time + fireRate;
			GameObject bullet = Instantiate (bulletPrefab) as GameObject;
			Vector2 spawnPoint = new Vector2 (transform.position.x - 0.2f, transform.position.y);
			bullet.transform.position = spawnPoint;
		}
	}
}
