/* Source File: Scripts/Player Stat Manager Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Resets player stats on scene load. Attached to Level Manager GO.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOne : MonoBehaviour {

	void Awake(){
		PlayerStatsManager.ResetStats ();
	}
}
