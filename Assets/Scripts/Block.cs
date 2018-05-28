using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public bool isAddBox = false;
	public bool isGrab = false;

	VRTK.VRTK_InteractableObject interactableObject;
	// public bool isGrape;

	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		interactableObject = GetComponent<VRTK.VRTK_InteractableObject>();
		
		if (interactableObject == null) {
			return;
		}

		interactableObject.InteractableObjectGrabbed += new VRTK.InteractableObjectEventHandler(InteractableObjectGrabbed);	
		interactableObject.InteractableObjectUngrabbed += new VRTK.InteractableObjectEventHandler(InteractableObjectUngrabbed);
	}

	public void InteractableObjectGrabbed(object sender, VRTK.InteractableObjectEventArgs e) {
		Debug.Log("Grabe Object");
		isGrab = true;
        GetComponent<Rigidbody>().isKinematic = true;
	}

	public void InteractableObjectUngrabbed(object sender, VRTK.InteractableObjectEventArgs e) {
		Debug.Log("UnGrabe Object");
		isGrab = false;
		if (rigidbody == null) {
			return;
		}

		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
