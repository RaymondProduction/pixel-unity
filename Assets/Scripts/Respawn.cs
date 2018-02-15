using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	public void Repsawn(Collider2D other)
    {
        Debug.Log("Respawn");
		Color tmp = other.GetComponent<SpriteRenderer>().color;
		tmp.a = 1;
		other.GetComponent<SpriteRenderer>().color = tmp;
		other.transform.position = transform.position;
		other.transform.localScale = new Vector3(1F, 1F, 1F);
    }
}
