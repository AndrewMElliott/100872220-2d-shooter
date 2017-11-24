/* Source File: Scripts/UI Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Displays current upgrade status stored in the PlayerStatsManager.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

	private Text upgradeCounter;

	// Use this for initialization
	void Awake () {
		upgradeCounter = GetComponent<Text> ();
	}
	
	//Update the player Upgrade Score. 20 points is the max. Modulus used to divide tiers into x/10 slices.
	void Update () {
		if (PlayerStatsManager.GetUpgradePoints () == 20f) {
			upgradeCounter.text = "Next Upgrade: MAX";
		} else {
			upgradeCounter.text = "Next Upgrade: " + PlayerStatsManager.GetUpgradePoints () % 10 + "/10";
		}
	}
}
