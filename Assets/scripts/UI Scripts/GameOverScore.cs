using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	private Text gameOverScore;

	// Use this for initialization
	void Awake () {
		gameOverScore = GetComponent<Text> ();
		gameOverScore.text = PlayerStatsManager.GetPlayerScore().ToString();
	}


}
