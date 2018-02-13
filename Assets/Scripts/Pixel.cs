using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour {
	public float speed =20f;

	public Sprite[] sprites = new Sprite[3];

	private bool shot_run = true, ground = false;
	public GameObject shot_original;
	private GameObject shot;
	private Rigidbody2D rb;
	public int jumpForce = 600, direction = 0;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
	}
	void Update(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			direction = 1;
			GetComponent<SpriteRenderer>().sprite = sprites[1];
		//	transform.Translate(Vector2.left * speed * Time.deltaTime);
			rb.MovePosition(rb.position+Vector2.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
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
		print(other.gameObject.tag);
		if (other.gameObject.tag == "Ground") {
			ground = true;
		}
	}

     IEnumerator instObj () {
		 yield return new WaitForSeconds(0.5f);
		// Destroy(shot);
		 shot_run = true;
	 }
}
