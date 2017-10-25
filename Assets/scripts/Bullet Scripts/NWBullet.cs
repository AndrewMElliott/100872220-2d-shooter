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

	//private Transform bulletPos = this.transform.position; 


	// Update is called once per frame
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

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Player") {

			ShipController target = col.gameObject.GetComponent<ShipController> ();
			target.SetDamage (damage);
			Destroy (gameObject);
		}// else if (col.tag == "Enemy Ship") {

		//	EnemyAI target = col.gameObject.GetComponent<EnemyAI> ();
		//	target.SetDamage (damage);
		//}


	}	
}
