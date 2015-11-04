using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
	int i=0;
	public GameObject newstar;
	// Use this for initialization
	void Start () {
		newstar.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, 1);
		if (i % 100 < 50) {
			transform.localScale += new Vector3 (1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);
			i++;
		} else {
			transform.localScale += new Vector3 (-1f * Time.deltaTime, -1f * Time.deltaTime, -1f * Time.deltaTime);
			i++;
			}
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("player"))
		{
			this.gameObject.SetActive (false);
			newstar.gameObject.SetActive(true);
		}
	}
}
