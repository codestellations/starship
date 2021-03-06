﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
	
	public GameObject bulletPrefab;
	int bulletLayer;

	public float fireDelay = 10f;
	float delay = 2;
	float cooldownTimer = 0;

	Transform player;


	void Start() {
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {

		if(player == null) {
			// Find the player's ship!
			GameObject go = GameObject.FindWithTag ("Player");
			
			if(go != null) {
				player = go.transform;
			}
		}

		cooldownTimer -= Time.deltaTime;
		
		if( cooldownTimer <= 0 && player != null) {
			// SHOOT!
			// Debug.Log ("Enemy Pew!");
			// cooldownTimer = fireDelay;
			cooldownTimer = delay;

			Vector3 offset = transform.rotation * bulletOffset;
			bulletPrefab = Resources.Load("Missile") as GameObject;
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
