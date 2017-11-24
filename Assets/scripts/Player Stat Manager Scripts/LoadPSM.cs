/* Source File: Scripts/Player Stat Manager Scripts
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Script to instantiate player stat manager object when camera loads.
 * 				Instantiates Stat manager (which will be static) to allow other scripts to access it.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPSM : MonoBehaviour {
	
	public GameObject playerStatsManager;
	//https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
	//Instantiates static PlayerStatsManager object.
	void Awake () {
		if (PlayerStatsManager.instance == null) {
			Instantiate (playerStatsManager);
		}
	}
	


}
