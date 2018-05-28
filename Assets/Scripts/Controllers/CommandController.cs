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
            EventManager.Instance.OnCommandComplete += () => { _map = new MapRobot(); };
        }

        private void StartExecuteCommands(List<Command> commands)
        {
            Debug.Log("count mas = " +commands.Count);
            _checkedCommands = new List<CheckCommand>();
            foreach (var command in commands)
            {
                _map.ShowLog();
                ExecuteCommand(command);
                //_map.ShowLog();
            }
            _map.ShowLog();
            EventManager.Instance.OnCommandsChecked(_checkedCommands);
        }
        private void ExecuteCommand(Command command)
        {
            switch (command.NameCommand)
            {
                case Commands.Forward:
                    for (var index = 0; index < command.Parametr; index++)
                    {
                        _map.Robot.MoveForward();
                        if (_map.HaveErrors())
                        {
                            _map.Robot.MoveBack();
                            _checkedCommands.Add(new CheckCommand {Command = command, IsError = true});
                                break;
                        }

                        if (_map.HaveWictory()) {
                            _checkedCommands.Add(new CheckCommand { Command = command, IsError = false, IsWictory = true});
                                break;
                        }
                        _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    }
                    break;
                case Commands.Back:
                    for (var index = 0; index < command.Parametr; index++)
                    {
                        _map.Robot.MoveBack();
                        if (_map.HaveErrors())
                        {
                            _map.Robot.MoveForward();
                            _checkedCommands.Add(new CheckCommand {Command = command, IsError = true});
                                break;
                        }
                        if (_map.HaveWictory())
                        {
                            _checkedCommands.Add(new CheckCommand { Command = command, IsError = false, IsWictory = true });
                                break;
                        }
                        _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    }
                    break;
                case Commands.RotateRight:
                     
                    _map.Robot.RotateRight();
                    _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    break;
                case Commands.RotateLeft:
                    _map.Robot.RotateLeft();
                    _checkedCommands.Add(new CheckCommand {Command = command, IsError = false});
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}