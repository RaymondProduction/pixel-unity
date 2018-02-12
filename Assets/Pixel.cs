using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour {
	public float speed =3f;
	public GameObject shot_original, obj;
	private GameObject shot;

	void Start(){
		//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
	}
	void Update(){
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKey(KeyCode.Space)) {
			StartCoroutine(instObj());
			//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
		}
	}

     IEnumerator instObj () {
		 yield return new WaitForSeconds(1.5f);
		 Instantiate(shot_original, transform.position, Quaternion.identity);
	 }
}
