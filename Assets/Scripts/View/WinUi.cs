using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUi : MonoBehaviour {


    public Animator animator;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("Show");
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
