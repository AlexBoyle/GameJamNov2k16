﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure; 
using UnityEngine.SceneManagement;



public class ImmortalObjectScript : MonoBehaviour {
	private bool[] players;
	private int winner = -1;
	private  int curlvl = 0;
	private int count = 0;
	private int menuLevel;
	public GameObject playerFab;
	void Start (){
		menuLevel = SceneManager.GetActiveScene ().buildIndex;
		GameObject.DontDestroyOnLoad (gameObject);
	}

	void OnLevelWasLoaded(int level) {
		curlvl = level;
		if (curlvl > menuLevel) {
			for (int i = 0; i < players.Length; i++) {
				if(players[i]) {
					//spawn players
				}
			}
		}
	}
	public void win(int a){
		winner = a;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
	public bool[] getPlayers(){
		return players;
	}
	public void setPlayers(bool[] a){
		players = a;
	}
}