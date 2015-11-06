using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	 int i = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(i%100<50){

			transform.position+= new Vector3 ((float)0.5* Time.deltaTime, 0.5f*Time.deltaTime, 0);
			i++;}
		else {

			transform.position+= new Vector3 ((float)0.5* Time.deltaTime, -0.5f*Time.deltaTime, 0);
			i++;};
		if (transform.position.x > 10) {
			transform.position= new Vector3 (-11f,3.5f,0);
		}
	}
}
