
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
		public Action OnCommandComplete = () => { Debug.Log("Command complete"); };
		public Action<List<CheckCommand>> OnCommandsChecked = commands => { Debug.Log("Commands Checked"); };
	}
}
