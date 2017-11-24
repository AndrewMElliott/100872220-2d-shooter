/* Source File: Scripts/misc
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Simple destroy script for animations to trigger.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	void DestroyMe(){
		Destroy(gameObject);
	}
}
