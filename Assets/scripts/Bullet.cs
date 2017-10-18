using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private float bulletLife;
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
		Debug.Log ("Object name: " + col.tag);
		if (col.tag == "Player") {

		} else if (col.tag == "Enemy Ship") {
			Destroy (gameObject);
		}
	}	

}
