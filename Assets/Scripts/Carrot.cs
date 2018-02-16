using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
	public float speed;
	public Sprite bum;
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
			StartCoroutine(buM());
		}
		if (other.tag == "Player" && tmp.a<=0.2f) {
			repsawn.GetComponent<Respawn>().Repsawn(other);
		}
	}

    private IEnumerator buM()
    {
		 speed = 0;
		 gameObject.GetComponent<SpriteRenderer>().sprite = bum;
         yield return new WaitForSeconds(0.1f);
		 Destroy(gameObject);
    }

    IEnumerator instObj () {
		 yield return new WaitForSeconds(10f);
		 Destroy(gameObject);
	 }
}
