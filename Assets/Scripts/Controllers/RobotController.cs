using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Model;
using UnityEditor;
using UnityEngine;

namespace Controllers
{
    public class RobotController : MonoBehaviour
    {
        private Vector3 _targetPosition;
        public float Speed;
        private List<CheckCommand> _checkedCommands;

        private void OnEnable()
        {
            EventManager.Instance.OnCommandsChecked += OnExecuteCommands;
        }

        private IEnumerator ExecuteCommands()
        {
            foreach (var command in _checkedCommands)
            {
                Debug.Log("Error = " + command.IsError);
                if (command.IsError) continue;
                yield return Execute(command.Command);
            }

            EventManager.Instance.OnCommandComplete();
        }
        private IEnumerator Execute(Command command)
        {
            switch (command.NameCommand)
            {
                case Commands.Forward:
                {
                    yield return Move(transform.position + transform.forward.normalized);
                }
                    break;
                case Commands.Back:
                    yield return Move(transform.position - (-1*transform.forward.normalized));
                    break;
                case Commands.RotateRight:
                    for (var i = 0; i < 90; i++)
                    {
                        transform.transform.Rotate(Vector3.up);
                        yield return  new WaitForSeconds(.02f);
                    }
                    break;
                case Commands.RotateLeft:
                    for (var i = 0; i < 90; i++)
                    {
                        transform.transform.Rotate(-Vector3.up);
                        yield return  new WaitForSeconds(.02f);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            yield return null;
        }
        
        private IEnumerator Move(Vector3 targetPosition)
        {
            while (true)
            {
//                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*Speed);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
//                
//                Debug.Log("hihihi");

                yield return null;
                
                
                if (transform.position == targetPosition) yield break;

            }
                
        }
        private void OnExecuteCommands(List<CheckCommand> checkedCommands)
        {
            Debug.Log("count rob = " +checkedCommands.Count);
            _checkedCommands = checkedCommands;
            StartCoroutine(ExecuteCommands());
        }

    }
}