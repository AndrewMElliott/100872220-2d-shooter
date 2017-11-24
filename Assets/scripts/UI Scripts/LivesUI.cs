/* Source File: Scripts/UI Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Updates Lives UI with current player Lives stat from PlayerStatsManager.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour {

	private Text lifeText;
	void Awake () {
		lifeText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		lifeText.text = "Lives: " + PlayerStatsManager.GetPlayerLives ();
	}
}
