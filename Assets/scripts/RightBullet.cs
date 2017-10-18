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
	//private Transform bulletPos = this.transform.position; 

	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * bulletSpeed * Time.deltaTime);
		DelayDestroy (2f);
	}

	public void Destroy(){
		Destroy (gameObject);
	}

	public void DelayDestroy(float time){
		Destroy (gameObject, time);
	}

	void OnTriggerEnter2D(Collider2D col){
		
		EnemyAI target = col.gameObject.GetComponent<EnemyAI> ();
		if (target != null) {
			target.SetDamage (damage);
		}
		Destroy (gameObject);
	}	

}
