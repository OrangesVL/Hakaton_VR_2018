using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

    public AudioSource audioSource;

    public void StartAuido()
    {
        audioSource.Play();
    }
}
