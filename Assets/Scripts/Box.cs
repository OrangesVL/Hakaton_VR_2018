using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public string tag = "Block";
	List<GameObject> elements;
	public GameObject point;
	public int maxElements = 10;

	// Use this for initialization
	void Start () {
		elements = new List<GameObject>();

		if (point == null) {
			Debug.LogError("Not init Point");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Object is Enter");
		if (other.gameObject.tag.Equals(tag)) {

			if (elements.Count >= maxElements) {
				return;
			}

			Block block = other.gameObject.GetComponent<Block>();

			if (block.isAddBox || block.isGrab) {
				return;
			}

			block.isAddBox = true;

			Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.velocity = Vector3.zero;
			rigidbody.isKinematic = true;

			elements.Add(other.gameObject);

			other.gameObject.transform.position = point.transform.position;
			other.gameObject.transform.rotation = transform.rotation;
			Vector3 newPosition = point.transform.position;
			newPosition.z += 0.6f;
			point.transform.position = newPosition;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals(tag)) {
			Block block = other.gameObject.GetComponent<Block>();

			if (block.isGrab || block.isAddBox) {
				return;
			}

			block.isAddBox = true;

			Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.velocity = Vector3.zero;
			rigidbody.isKinematic = true;

			elements.Add(other.gameObject);

			other.gameObject.transform.position = point.transform.position;
			other.gameObject.transform.rotation = transform.rotation;
			Vector3 newPosition = point.transform.position;
			newPosition.z += 0.6f;
			point.transform.position = newPosition;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Equals(tag)) {
			Block block = other.gameObject.GetComponent<Block>();

			if (!block.isAddBox) {
				return;
			}

			block.isAddBox = false;

			Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
			// rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
		}
	}
}
