using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInitEvents : MonoBehaviour {

	VRTK.VRTK_InteractableObject interactGrab;
	void Start () {
		interactGrab = GetComponent<VRTK.VRTK_InteractableObject>();

		if (interactGrab == null) {
			Debug.LogError("Not found InteractGrab");
			return;
		}

		interactGrab.InteractableObjectGrabbed += new VRTK.InteractableObjectEventHandler(OnInteractGrabBlock);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnInteractGrabBlock(object send, VRTK.InteractableObjectEventArgs args) {
		return;
	}
}
