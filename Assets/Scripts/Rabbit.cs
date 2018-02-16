using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

	private int jumpForce = 106000, direction = 0;

	public GameObject carrotOriginal, pixel;
	private GameObject carrot; 
	private Rigidbody2D rb;
	private int  shootingTrigger = 0;
	private bool ground = false;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().flipX = true;
		ShootingByCarrot(-1F);
	}
	
	// Update is called once per frame
	void Update () {
		if (ground){
			direction = 0;
			ground = false;
			rb.AddForce(Vector2.up*jumpForce);
		}
		if (pixel.transform.position.x>transform.position.x && pixel.transform.position.y+2>transform.position.y &&  shootingTrigger==0) {
			shootingTrigger =1;
			GetComponent<SpriteRenderer>().flipX = false;
			StartCoroutine(Shot());
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			ground = true;
		}
	}

	void ShootingByCarrot(float partOfSpeed){
		carrot = Instantiate(carrotOriginal, new Vector2(transform.position.x, pixel.transform.position.y), Quaternion.identity) as GameObject;
		carrot.GetComponent<SpriteRenderer>().flipX = partOfSpeed < 0;
		carrot.GetComponent<Carrot>().speed *= partOfSpeed; 
 		carrot.SetActive(true);
	}

	IEnumerator Shot () {
		yield return new WaitForSeconds(Random.Range(0.5F,2F));
		ShootingByCarrot(1f);
		StartCoroutine(Shot());
	 }
}
