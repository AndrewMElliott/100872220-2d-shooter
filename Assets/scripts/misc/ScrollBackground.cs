/* Source File: Scripts/misc
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Script that scrolls the background left until the set EndPoint is reached,
 * 				Then the background repositions itself to the right of the camera to scroll back
 * 				through the game area.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
	[SerializeField]
	private float scrollSpeed;
	[SerializeField]
	private float endPointX;

	[SerializeField]
	private float repositionX;


	void Update () {
		Vector2 position = new Vector2 (transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y);
		transform.position = position;

		if (transform.position.x <= endPointX)
			transform.position = new Vector2 (repositionX, transform.position.y);
	}


}
