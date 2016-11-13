using UnityEngine;
using System.Collections;

// script use
// bounds the camera to be locked within the range specified by the top left right and bottom bound variables
// also lerpes the camera size to always show the two players that are taken in

public class CameraFollow : MonoBehaviour {
	Camera mainCamera;
	public GameObject[] Player;
	private Transform[] players;
	private Transform[] playerGhosts;
	float cameraToUnits = 1.778114f;
	float lerpFactor = .025f;

	int numberOfPlayers = 0, introBuff = 60;

	public float topBound;
	public float leftBound;
	public float rightBound;
	public float bottomBound;
	public float cameraMaxSize;
	public float cameraMinSize;
	// Use this for initialization
	void Start () {
		Transform[] temp = new Transform[4];
		temp [0] = Player [0].transform;
		temp [1] = Player [1].transform;
		temp [2] = Player [2].transform;
		temp [3] = Player [3].transform;
		numberOfPlayers = 4;
		players = temp;
		mainCamera = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
			if (true) {
				adjustCamera ();
			} else {
				mainCamera.orthographicSize = cameraMaxSize;
				mainCamera.transform.position = new Vector3 (0, 3.5f, -100);
			}
	}
	void adjustCamera(){
		Vector3 p1Pos = players[0].position, p2Pos = players[1].position;
		Vector3 p3Pos = players[2].position, p4Pos = players[3].position;
		Vector3 midpoint = new Vector3((p1Pos.x + p2Pos.x + p3Pos.x + p4Pos.x)/4, (p1Pos.y +  p2Pos.y + p3Pos.y + p4Pos.y)/4, 0 );

		float currentDistance = Vector3.Distance (midpoint, p1Pos);
		if(currentDistance < Vector3.Distance (midpoint, p2Pos))
			currentDistance = Vector3.Distance (midpoint, p2Pos);
		if(currentDistance < Vector3.Distance (midpoint, p3Pos))
			currentDistance = Vector3.Distance (midpoint, p3Pos);
		if(currentDistance < Vector3.Distance (midpoint, p4Pos))
			currentDistance = Vector3.Distance (midpoint, p4Pos);
		currentDistance += 1;
		midpoint = new Vector3 (midpoint.x, midpoint.y, -100);
		// adjust camera to be big enough to show both players
		float newSize = ((cameraToUnits  * currentDistance)/2) + 2;
		float yDistance = Mathf.Abs( p1Pos.y - p2Pos.y);

		if (yDistance > newSize) {
			newSize = yDistance +1;
		}

		if (newSize < cameraMinSize) {
			newSize = cameraMinSize;
		} else if (newSize > cameraMaxSize) {
			newSize = cameraMaxSize;
		}
		mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize ,newSize, lerpFactor);

		// adjust camera to be in center of players

		float cameraBoundUp = midpoint.y + newSize;
		float cameraBoundDown = midpoint.y - newSize;
		// stop camera from leaving the ground
		if (cameraBoundUp > topBound) {
			midpoint.y = topBound - newSize;
		} else if (cameraBoundDown < bottomBound) {
			midpoint.y = bottomBound + newSize ;
		} 


		// control the x so that camera does show out of bounds
		float cameraBoundRight = midpoint.x +  (cameraToUnits * newSize);
		float cameraBoundLeft = midpoint.x -  (cameraToUnits * newSize);
		if (newSize == cameraMaxSize){
			midpoint.x = 0;
			midpoint.y = 3.5f;
		}
		else if ( cameraBoundRight >  rightBound){
			midpoint.x = rightBound - (cameraToUnits*newSize); 
		}else if (cameraBoundLeft < leftBound){
			midpoint.x = leftBound + (cameraToUnits*newSize);
		}  

		mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, midpoint, lerpFactor );
	}

}