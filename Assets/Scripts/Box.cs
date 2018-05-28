using Managers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public string tag = "Block";
	List<GameObject> elements;
	public GameObject point;
    Vector3 startPoint;
    public float offset = 1f;

    public int maxElements = 2;
    public bool _isWork = false;

	// Use this for initialization
	void Start () {
        elements = new List<GameObject>();
        startPoint = point.transform.position;

        if (point == null) {
			Debug.LogError("Not init Point");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
    private void FinishWork()
    {
        _isWork = false;
    }
    private void OnEnable()
    {
        //EventManager.Instance.OnCommandComplete += FinishWork;
    }
    private void OnDisable()
    {
        if (EventManager.Instance == null) return;
        //EventManager.Instance.OnCommandComplete -= FinishWork;
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
			newPosition.x += offset;
			point.transform.position = newPosition;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals(tag)) {
            if (elements.Count >= maxElements)
            {
                return;
            }

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
			newPosition.x += offset;
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
			//rigidbody.isKinematic = false;
            rigidbody.velocity = Vector3.zero;
            elements.Remove(other.gameObject);

            Vector3 position = startPoint;
            foreach (GameObject elements in elements)
            {
                elements.transform.position = position;
                position.x += offset;
            }
            point.transform.position = position;
		}
	}
    public void OnClickButton()
    {
        //if (_isWork) return;
        //Debug.Log("Button CLick");
        if (SceneManager.Instance.IsWork) return;
        SceneManager.Instance.IsWork = true;
        List<Command> commands = new List<Command>();
        foreach (var elemnt in elements)
        {
            commands.Add(elemnt.GetComponent<Command>());
        }
        EventManager.Instance.OnStartExecuteCommands(commands);
        //_isWork = true;
    }
    public void Reset()
    {
        foreach (var elemnt in elements)
        {
            Destroy(elemnt);
        }
        elements.Clear();
        point.transform.position = startPoint;
    }
}
