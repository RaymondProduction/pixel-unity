using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDie : MonoBehaviour {

	public GameObject repsawn;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player")
        {
			repsawn.GetComponent<Respawn>().Repsawn(other);
		}
	}
}
