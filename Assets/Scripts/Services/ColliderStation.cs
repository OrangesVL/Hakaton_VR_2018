using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStation : MonoBehaviour {

    public GameObject Block;
    public string tag = "Block";

    private void Start()
    {
        CreateBlock();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals(tag))
        {
            CreateBlock();

            //other.gameObject.GetComponent<Rigidbody>().isKinematic= false;
            return;
        }
        
    }

    void CreateBlock()
    {
        if (Block == null)
        {
            Debug.LogError("Not found Prefab");
            return;
        }
        GameObject obj = Instantiate(Block, transform.position, transform.rotation);
        //Rigidbody rigibody = Block.GetComponent<Rigidbody>();
        //rigibody.isKinematic = true;
        //rigibody.useGravity = false;
    }
}
