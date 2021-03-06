﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}else{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Boundary"){
			return;
		}
		Instantiate (explosion, other.transform.position, other.transform.rotation);
		if(other.tag == "Player"){
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}