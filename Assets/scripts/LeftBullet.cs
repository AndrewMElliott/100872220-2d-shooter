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
	//private Transform bulletPos = this.transform.position; 


	// Update is called once per frame
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

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Trigger Object: " + col.tag);
		if (col.tag == "Player") {
			Debug.Log ("Player Detected: " + col.tag);
			ShipController target = col.gameObject.GetComponent<ShipController> ();
			target.SetDamage (damage);
		} else if (col.tag == "Enemy Ship") {
			Debug.Log ("AI Detected: " + col.tag);
			EnemyAI target = col.gameObject.GetComponent<EnemyAI> ();
			target.SetDamage (damage);
		}

		Destroy (gameObject);
	}	
}
