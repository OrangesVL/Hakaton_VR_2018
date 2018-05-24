
using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Managers
{
	public class EventManager : Singleton<EventManager>
	{
		public Action<Command> OnClickTileCreate = command => {Debug.Log("Tile Create"); };
		public Action<List<Command>> OnStartExecuteCommands = commands => { Debug.Log("Start Execute Commands"); };
		public Action<Command> OnCommandError = command => { Debug.Log("Error command " + command.NameCommand); };
		public Action<Command> OnCommandSuccess = command => { Debug.Log("Command success " + command.NameCommand); };
	}
}
