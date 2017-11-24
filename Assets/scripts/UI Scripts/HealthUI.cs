/* Source File: Scripts/UI Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Script updates Player health UI with health stats from PlayerStatManager.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour {

	private Text healthText;
	void Awake () {
		healthText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "Health: " + PlayerStatsManager.GetPlayerHealth ();
	}
}
