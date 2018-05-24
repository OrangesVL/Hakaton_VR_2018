using Services;
using UnityEngine;

namespace Model
{
    public class MapRobotMovement
    {
        private int[,] _map;

        public MapRobotMovement()
        {
            Robot = new UnitOnMap(new Point(0,0), Directions.Down);
            _map = new [,]
            {
                {0,1,0},
                {1,1,0},
                {0,0,0}
            };
        }
        public UnitOnMap Robot { get; private set; }

        public bool HaveErrors()
        {
            return !RobotIsInsideMap() || RobotOnErrorTile();
        }
        private bool RobotIsInsideMap()
        {
            return Robot.Point.X >= 0 && Robot.Point.X < _map.GetLength(0) && Robot.Point.Y >= 0 && Robot.Point.Y < _map.GetLength(1);
        }
        private bool RobotOnErrorTile()
        {
            return _map[Robot.Point.X, Robot.Point.Y] == 1;
        }
    }
}