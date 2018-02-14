using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

	public int jumpForce = 600, direction = 0;

	public GameObject carrotOriginal;
	private GameObject carrot; 
	private Rigidbody2D rb;
	private bool ground = true;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		carrot = Instantiate(carrotOriginal, transform.position, Quaternion.identity) as GameObject;
 		carrot.SetActive(true);
		StartCoroutine(Shot());
	}
	
	// Update is called once per frame
	void Update () {
		if (ground){
			direction = 0;
			ground = false;
			rb.AddForce(Vector2.up*jumpForce);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			ground = true;
		}
	}

	IEnumerator Shot () {
		 yield return new WaitForSeconds(1f);
		carrot = Instantiate(carrotOriginal, transform.position, Quaternion.identity) as GameObject;
 		carrot.SetActive(true);
		StartCoroutine(Shot());
	 }
}
