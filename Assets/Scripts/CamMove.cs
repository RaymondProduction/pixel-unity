using UnityEngine;

public class CamMove : MonoBehaviour {

	public GameObject pixel;	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (pixel.transform.position.x, pixel.transform.position.y, -10f);
	}
}
