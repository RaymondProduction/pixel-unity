﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour {
	public float speed =20f;

	public Sprite[] sprites = new Sprite[5];

	private bool shot_run = true, ground = false;
	public GameObject shot_original;
	private GameObject shot;
	private Rigidbody2D rb;
	public int jumpForce = 1000, direction = 0;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale =0;
		GetComponent<SpriteRenderer>().sprite = sprites[3];
		GetComponent<CircleCollider2D>().enabled = false;
		//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
	}
	void Update(){
		if (Input.GetKey(KeyCode.LeftArrow) && GetComponent<SpriteRenderer>().sprite != sprites[4]) {
			direction = 1;
			GetComponent<SpriteRenderer>().sprite = sprites[1];
		//	transform.Translate(Vector2.left * speed * Time.deltaTime);
			rb.MovePosition(rb.position+Vector2.left * speed * Time.deltaTime);
		}

		if (GetComponent<SpriteRenderer>().sprite == sprites[3] && ground) {
			GetComponent<SpriteRenderer>().sprite = sprites[4];
		}

		if (GetComponent<SpriteRenderer>().sprite == sprites[4] && ground && Input.GetKey(KeyCode.UpArrow)) {
			jumpForce = 200;
			rb.gravityScale = 1f;
			GetComponent<CircleCollider2D>().enabled = true;
		}

		if (Input.GetKey(KeyCode.RightArrow) && GetComponent<SpriteRenderer>().sprite != sprites[4]) {
			jumpForce = 1000;
			direction = 2;
			GetComponent<SpriteRenderer>().sprite = sprites[2];
		//	transform.Translate(Vector2.right * speed * Time.deltaTime);
			rb.MovePosition(rb.position+Vector2.right * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow) && ground /*rb.IsTouchingLayers()*/){
			direction = 0;
			ground = false;
			GetComponent<SpriteRenderer>().sprite = sprites[0];
			rb.AddForce(Vector2.up*jumpForce);
			//transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKey(KeyCode.Space) && shot_run) {
			if (direction != 0) {
				shot_run = false;
				StartCoroutine(instObj());
				transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);
				shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
				shot.SetActive(true);
				//if (direction == 2) shot.GetComponent<Shot>().speed = 100f;
				if (direction == 1) shot.GetComponent<Shot>().speed = -shot.GetComponent<Shot>().speed;
				//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
			}
		}
	}

    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			ground = true;
		}
	}

     IEnumerator instObj () {
		 yield return new WaitForSeconds(0.1f);
		// Destroy(shot);
		 shot_run = true;
	 }
}
