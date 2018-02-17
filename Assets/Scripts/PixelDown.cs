using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDown : MonoBehaviour {

	public GameObject pixel, mainCamera, rabbit;
	public Sprite smileSadness;
	private bool ground = false;

	public AudioSource speack, speakSadness, speackUp;
	void Start(){
		speack.Play();
	}

    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			speakSadness.Play();
			GetComponent<SpriteRenderer>().sprite = smileSadness;
			ground = true;
		}
	}
	void Update(){
		if (ground && Input.GetKeyDown(KeyCode.UpArrow)) {
			gameObject.SetActive(false);
			mainCamera.GetComponent<CamMove>().pixel = pixel;
			rabbit.GetComponent<Rabbit>().pixel = pixel;
			speackUp.Play();
			pixel.SetActive(true);
		}
	}
}
