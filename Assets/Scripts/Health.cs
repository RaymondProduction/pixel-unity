using UnityEngine;

public class Health : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other){
		Debug.Log("Health");
		if (other.tag == "Player") {
			other.transform.localScale = new Vector3(1F, 1F, 1F);
			gameObject.SetActive(false);
		}
	}
}
