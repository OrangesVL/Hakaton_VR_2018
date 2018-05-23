
using System;
using Model;
using UnityEngine;

namespace Managers
{
	public class EventManager : Singleton<EventManager>
	{
		public Action<Command> OnClickTileCreate = command => {Debug.Log("Tile Create"); };
	}
}
