using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WoodController : MonoBehaviour {
	public GameObject woodPrefab;

	private int oldId = -1;
	private GameObject wood1, wood2;
	private float woodColliderSize, storeRotation;
	private float startPoint, endPoint, distance, newScale;
	private float radius = 15f;
	private float power = 2000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Explosive() {
		if (oldId == transform.GetInstanceID())
			return;
		oldId = transform.GetInstanceID();
		storeRotation = transform.eulerAngles.z;
		transform.eulerAngles = Vector3.zero;
		woodColliderSize = GetComponent<BoxCollider2D>().size.y;
		startPoint = transform.position.y - woodColliderSize /2;
		endPoint = transform.position.y + woodColliderSize/2;

		float distance = Mathf.Abs(endPoint - startPoint);
		print (distance);
		
		if (!(distance < 0.1f)) {
			wood1 = (GameObject) Instantiate(woodPrefab, new Vector3(transform.position.x, endPoint + (distance / 2), transform.position.z), Quaternion.identity);
			wood1.GetComponent<BoxCollider2D>().size.Set(wood1.GetComponent<BoxCollider2D>().size.x, distance/2);
			transform.position = new Vector3(transform.position.x, endPoint - (distance / 2), transform.position.z);
			transform.localScale = new Vector3(1, distance / woodColliderSize, 1);
		}

	}

	
	private void manageChildren()
	{
		foreach (Transform childTransform in transform)
		{
			if (childTransform.tag.Equals("Explosive"))
			{
				Collider[] colliders = Physics.OverlapSphere(childTransform.position, radius);
				
				foreach (Collider hit in colliders)
				{
					if (hit && hit.GetComponent<Rigidbody>())
					{
						hit.GetComponent<Rigidbody>().AddExplosionForce(power, childTransform.position, radius, 3.0F);
					}
				}
				Destroy(childTransform.gameObject);
			}
		}
	}
}
