using System;
using Model;
using UnityEngine;

namespace Controllers
{
    public class RobotController : MonoBehaviour
    {
        public Animator Animator;
        public float Distance;
        public float Speed;

        private void Update()
        {
            Move();
        }

        private void ExecuteCommand(Command command)
        {
            switch(command.NameCommand)
            {
                case Commands.Forward:
                    break;
                case Commands.Back:
                    break;
                case Commands.RotateRight:
                    break;
                case Commands.RotateLeft:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.forward.normalized*Distance, Time.deltaTime * Speed);
        }
    }
}