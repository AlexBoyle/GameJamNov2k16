﻿using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
	public Transform transformToFollow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transformToFollow.position;
	}
}
