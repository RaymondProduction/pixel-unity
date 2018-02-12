using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float speed =100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		if (transform.position.x>9 || transform.position.x< -9) {
			Destroy(this.gameObject);
		}
	}
}
