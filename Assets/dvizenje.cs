﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dvizenje : MonoBehaviour {
	private bool walking = false;
	private Vector3 spawnPoint;

	void Start () {
		spawnPoint = transform.position;
		
	}

	void Update () {
		if (walking) {
			transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
		}
		if (transform.position.y < -10f) {
			transform.position = spawnPoint;
		}
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("plane")) {
				walking = false;
			} else {
				walking = true;
			}
		}

	}
}
