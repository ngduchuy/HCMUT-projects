using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WoodController : MonoBehaviour
{
	public GameObject woodPrefab;

	private Vector3 startPoint, endPoint;
	private float height, length;

	private GameObject wood1, wood2;
	private float woodColliderHeight, woodColliderLength;
	private float storeRotation;
	private float distance, newScale;
	private float radius = 15f;
	private float power = 2000f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {
			//Explosive(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			print (Input.mousePosition);
		}	
	}

	void Init ()
	{
		height = GetComponent<BoxCollider2D> ().size.y;
		length = GetComponent<BoxCollider2D> ().size.x;
		print ("size: " + height + "\t" + length);
		storeRotation = transform.eulerAngles.z;

		float deltaX = Mathf.Cos (storeRotation) * length / 2;
		float deltaY = Mathf.Sin (storeRotation) * length / 2;
		startPoint = new Vector3 (transform.position.x - deltaX, transform.position.y - deltaY, 0);
		endPoint = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, 0);
	}

	void Explosive(Vector3 position) {
		Init ();
		Vector3 firstPosition = new Vector3((startPoint.x + position.x) /2, (startPoint.y + position.y)/2 -3f, transform.position.z);
		Vector3 secondPosition = new Vector3((endPoint.x + position.x) /2, (endPoint.y + position.y)/2 +3f, transform.position.z);
		wood1 = (GameObject) Instantiate(woodPrefab, firstPosition, Quaternion.identity);
		wood2 = (GameObject) Instantiate(woodPrefab, secondPosition, Quaternion.identity);
	}
/*
	void Explosive(Vector3 position) {
		storeRotation = transform.eulerAngles.z;
		transform.eulerAngles = Vector3.zero;
		woodColliderHeight = GetComponent<BoxCollider2D>().size.x;
		woodColliderLength = GetComponent<BoxCollider2D>().size.y;
		startPoint = transform.position.y - woodColliderSize /2;
		endPoint = transform.position.y + woodColliderSize/2;

		float distance = Mathf.Abs(endPoint - startPoint);
		print (distance);
		
		if (!(distance <= 0.1f)) {
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
	*/
}
