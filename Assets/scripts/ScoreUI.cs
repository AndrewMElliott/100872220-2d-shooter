using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
	 private Text scoreText;
	 
	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "SCORE: " + PlayerStatsManager.GetPlayerScore ();
	}
}
