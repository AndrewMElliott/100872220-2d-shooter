/* Source File: Scripts/UI Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Displays Player score that is stored in the PlayerStatsManager.
 * */

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
