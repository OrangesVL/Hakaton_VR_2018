using System;
using System.Collections.Generic;
using Managers;
using Model;
using UnityEngine;

namespace Controllers
{
    public class CommandController
    {
        private MapRobot _map;
        private List<CheckCommand> _checkedCommands;

        public CommandController()
        {
            _map = new MapRobot();
            EventManager.Instance.OnStartExecuteCommands += StartExecuteCommands;
        }

        private void StartExecuteCommands(List<Command> commands)
        {
            Debug.Log("count mas = " +commands.Count);
            _checkedCommands = new List<CheckCommand>();
            foreach (var command in commands)
            {
                _map.ShowLog();
                ExecuteCommand(command);
                /*if (ExecuteCommand(command))
                    checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                else checkedCommands.Add(new CheckCommand {Command = command, IsError = true});*/
                _map.ShowLog();
            }
            EventManager.Instance.OnCommandsChecked(_checkedCommands);
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
                        if (_map.HaveErrors())
                        {
                            _map.Robot.MoveForward(false);
                            _checkedCommands.Add(new CheckCommand {Command = command, IsError = true});
                            return false;
                        }
                        _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    }
                    return true;
                }
                case Commands.Back:
                {
                    for (var index = 0; index < command.Parametr; index++)
                    {
                        _map.Robot.MoveForward(false);
                        if (_map.HaveErrors())
                        {
                            _map.Robot.MoveForward(true);
                            _checkedCommands.Add(new CheckCommand {Command = command, IsError = true});
                            return false;
                        }
                        _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    }
                    return true;
                }
                case Commands.RotateRight:
                {
                    _map.Robot.RotateRight();
                    _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                }
                    return true;
                case Commands.RotateLeft:
                {
                    _map.Robot.RotateLeft();
                    _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                }
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}