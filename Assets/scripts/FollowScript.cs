using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
	public Transform transformToFollow;
	void Update () {
		transform.position = transformToFollow.position;
	}
}
