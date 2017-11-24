/* Source File: Scripts/Bullet Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: This script controls the bullet projectile behaviours.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWBullet : MonoBehaviour {

	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private float bulletLife = 3f;
	[SerializeField]
	private float damage = 1f;
	[SerializeField]
	private ParticleSystem explosion;

	void Update () {
		Vector2 diagonal = new Vector2 (-1f * bulletSpeed * Time.deltaTime,0f);
		transform.Translate(diagonal);
		DelayDestroy (bulletLife);
	}

	public void Destroy(){
		Destroy (gameObject);
	}

	public void DelayDestroy(float time){
		Destroy (gameObject, time);
	}
	//Handle damage trigger. Pass damage to player if is triggered.
	void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Player") {

			ShipController target = col.gameObject.GetComponent<ShipController> ();
			target.SetDamage (damage);

			TriggerExplosion ();
			Destroy (gameObject);
		}
	}	
	private void TriggerExplosion(){
		ParticleSystem particles = Instantiate (explosion) as ParticleSystem;
		particles.transform.position = this.transform.position;

	}
}
