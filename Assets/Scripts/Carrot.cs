using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
	public float speed;
	public GameObject repsawn;
	private GameObject spaceDie;
	void Start () {
		StartCoroutine(instObj());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		Color tmp = other.GetComponent<SpriteRenderer> ().color;
		if (other.tag == "Player" && tmp.a > 0.2f) {
			tmp.a -= 0.1f;
			other.GetComponent<SpriteRenderer> ().color = tmp;
			Destroy(gameObject);
		}
		if (other.tag == "Player" && other.GetComponent<SpriteRenderer>().sprite == other.GetComponent<Pixel>().sprites[3]) {
			other.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
		}
		if (other.tag == "Player" && tmp.a<=0.2f) {
			repsawn.GetComponent<Respawn>().Repsawn(other);
		}
	}
     IEnumerator instObj () {
		 yield return new WaitForSeconds(3f);
		 Destroy(gameObject);
	 }
}
