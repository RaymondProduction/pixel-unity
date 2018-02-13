using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDie : MonoBehaviour {

	public GameObject repsawn;

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log("Respawn");
		if (other.tag == "Player") {
			other.transform.position = repsawn.transform.position;
			other.transform.localScale = new Vector3(1F, 1F, 1F);
		}
	}
}
