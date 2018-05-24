using System;
using UnityEngine;

namespace Model
{
    public enum Commands
    {
        Forward,
        Back,
        RotateRight,
        RotateLeft
    }
    
    [Serializable]
    public class Command : MonoBehaviour
    {
        [SerializeField] private Commands _nameCommand;
        [SerializeField] private int _parametr;

        public int Parametr
        {
            get { return _parametr; }
            set { _parametr = value; }
        }
        public Commands NameCommand
        {
            get { return _nameCommand; }
            set { _nameCommand = value; }
        }
        
    }
}