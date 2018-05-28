using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionControll : MonoBehaviour {

    public WinUi winUi;

    private void OnEnable()
    {
        EventManager.Instance.OnWictory += winUi.Show;
        EventManager.Instance.OnStartExecuteCommands += commands => { winUi.Hide(); };
    }



}
