using Managers;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {
    public GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        EventManager.Instance.OnClickTileCreate += OnCreateBlock;
    }
    public void OnCreateBlock(Command command)
    {
        GameObject obj = Instantiate(block, transform.position, Quaternion.identity);
        Command comand = obj.GetComponent<Command>();
        comand.NameCommand = command.NameCommand;
        comand.Parametr = command.Parametr;
    }

    public void CreateBlock()
    {
        if (block == null)
        {
            return;
        }
        Instantiate(block, transform.position, Quaternion.identity);
    }
}
