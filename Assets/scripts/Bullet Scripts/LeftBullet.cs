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

public class LeftBullet : MonoBehaviour {

	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private float bulletLife;
	[SerializeField]
	private float damage = 1f;
	[SerializeField]
	private ParticleSystem explosion;

	void Update () {
		transform.Translate (Vector2.left * bulletSpeed * Time.deltaTime);
		DelayDestroy (2f);
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
		}

		TriggerExplosion ();
		Destroy (gameObject);
	}	
	private void TriggerExplosion(){
		ParticleSystem particles = Instantiate (explosion) as ParticleSystem;
		particles.transform.position = this.transform.position;

	}
}
