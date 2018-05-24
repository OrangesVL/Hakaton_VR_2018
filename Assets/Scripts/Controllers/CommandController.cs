using System;
using System.Collections.Generic;
using Managers;
using Model;

namespace Controllers
{
    public class CommandController
    {
        private MapRobotMovement _map;

        public CommandController()
        {
            _map = new MapRobotMovement();
            EventManager.Instance.OnStartExecuteCommands += StartExecuteCommands;
        }

        private void StartExecuteCommands(List<Command> commands)
        {
            foreach (var command in commands)
            {
                if (ExecuteCommand(command))
                {
                    EventManager.Instance.OnCommandSuccess(command);
                    continue;
                }
                
                EventManager.Instance.OnCommandError(command);
                return;
            }
        }
        private bool ExecuteCommand(Command command)
        {
            switch (command.NameCommand)
            {
                case Commands.Forward:
                {
                    for (var index = 0; index < command.Parametr; index++)
                    {
                        _map.Robot.MoveForward(true);
                        if (!_map.HaveErrors())return false;
                    }
                    return true;
                }
                case Commands.Back:
                {
                    for (var index = 0; index < command.Parametr; index++)
                    {
                        _map.Robot.MoveForward(false);
                        if (!_map.HaveErrors())return false;
                    }
                    return true;
                }
                case Commands.RotateRight:
                    break;
                case Commands.RotateLeft:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return false;
        }
    }
}