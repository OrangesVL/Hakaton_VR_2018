using System.Collections.Generic;
using System.Linq;
using Managers;
using Model;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        public Command[] Commands;

        public void CallEvent()
        {
            EventManager.Instance.OnStartExecuteCommands(Commands.ToList());
        }
    }
}