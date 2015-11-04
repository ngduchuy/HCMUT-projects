using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	private Rigidbody2D rb;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		movement = this.transform.position;
		movement = new Vector3(1f, 0, 1);
		rb.AddForce (movement * speed);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate( 0.0f, 0.0f,0.1f*Time.deltaTime);

		
	}

}
