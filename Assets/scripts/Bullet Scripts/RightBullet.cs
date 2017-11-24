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
 * 				Destroy based on coordinates, so the player can't kill enemies that are off screen.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private float bulletLife;
	[SerializeField]
	private float damage = 1f;
	[SerializeField]
	private ParticleSystem explosion;

	void Update () {
		transform.Translate (Vector2.right * bulletSpeed * Time.deltaTime);
		if (transform.position.x >= 8.9f)
			Destroy (gameObject);
	}

	public void Destroy(){
		Destroy (gameObject);
	}
	//Handle damage trigger. Pass damage to player if is triggered.	
	void OnTriggerEnter2D(Collider2D col){
		
		EnemyAI target = col.gameObject.GetComponent<EnemyAI> ();
		if (target != null) {
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
