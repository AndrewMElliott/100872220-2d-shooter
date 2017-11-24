/* Source File: Scripts/UI Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Displays Player score in the game over screen that is stored in the PlayerStatsManager.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	private Text gameOverScore;

	void Awake () {
		gameOverScore = GetComponent<Text> ();
		gameOverScore.text = PlayerStatsManager.GetPlayerScore().ToString();
	}


}
