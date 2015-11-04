using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 ((float)0.5* Time.deltaTime, 0, 0) ;
	}
}
