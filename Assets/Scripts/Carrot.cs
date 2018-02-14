using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
	public float speed =50f;
	// Use this for initialization
	void Start () {
		StartCoroutine(instObj());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		// if (transform.position.x>9 || transform.position.x< -9) {
		// 	Destroy(this.gameObject);
		// }
	}

	
     IEnumerator instObj () {
		 yield return new WaitForSeconds(1.5f);
		 Destroy(gameObject);
	 }
}
