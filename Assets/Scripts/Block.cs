using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public bool isAddBox = false;


	VRTK.VRTK_InteractableObject interactableObject;

	// Use this for initialization
	void Start () {
		interactableObject = GetComponent<VRTK.VRTK_InteractableObject>();
		interactableObject.InteractableObjectGrabbed += new VRTK.InteractableObjectEventHandler(InteractableObjectGrabbed);	
	}

	public void InteractableObjectGrabbed(object sender, VRTK.InteractableObjectEventArgs e) {
		Debug.Log("Grabe Object");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
