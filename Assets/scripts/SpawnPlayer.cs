using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
	[SerializeField]
	private GameObject player;

	[SerializeField]
	private bool dead = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Spawn(){
		
		GameObject spwn = Instantiate (player) as GameObject;
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		spwn.transform.position = pos;
	}
}
