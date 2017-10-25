using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("trigger: " + col.name);
	}
}
