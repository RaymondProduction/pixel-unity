using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
	public float speed;
	public Sprite bum;
	public Vector2 target;
	private Vector2 target2;
	public GameObject repsawn;
	private GameObject spaceDie;
	void Start () {
		//transform.LookAt(target);
		StartCoroutine(instObj());
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector2.right * speed * Time.deltaTime);
		float step = (speed)* Time.deltaTime;
		// transform.position += transform.forward * speed * Time.deltaTime;
      	 transform.position = Vector2.MoveTowards(transform.position, target, step);
		//transform.Translate(target*Time.deltaTime*speed);
		 //transform.Translate(directionObject.transform.forward * Time.deltaTime * projectileSpeed, Space.Self);
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
		 yield return new WaitForSeconds(3f);
		 Destroy(gameObject);
	 }
}
//  Okay I solved it, 
//  transform.Translate(directionObject.transform.forward * Time.deltaTime * projectileSpeed, Space.Self); // directionObject whose transform looks at mouse input position. I'm not deleting post maybe someone will have similar problem.