using Services;
using UnityEngine;

namespace Model
{
    public class MapRobot
    {
        private int[,] _map;

        public MapRobot()
        {
            Robot = new UnitOnMap(new Point(0,0), Directions.Down); // Down ->
            _map = new int[5, 5];
            for(var x = 0; x < _map.GetLength(0); x++)
            {
                for(var y=0; y< _map.GetLength(1); y++)
                {
                    _map[x, y] = 0;
                }
            }
            _map[2, 1] = 1;
            _map[2, 2] = 1;
            _map[3, 3] = 2;
        }
        public UnitOnMap Robot { get; set; }

        public bool HaveErrors()
        {
            return !RobotIsInsideMap() || RobotOnErrorTile();
        }
        public bool HaveWictory()
        {
            return _map[Robot.Point.X, Robot.Point.Y] == 2;
        }
        private bool RobotIsInsideMap()
        {
            return Robot.Point.X >= 0 && Robot.Point.X < _map.GetLength(0) && Robot.Point.Y >= 0 && Robot.Point.Y < _map.GetLength(1);
        }
        private bool RobotOnErrorTile()
        {
            return _map[Robot.Point.X, Robot.Point.Y] == 1;
        }

        public void ShowLog()
        {
            var log = "";
            for (var x = 0; x < _map.GetLength(0); x++)
            {
                for (var y = 0; y < _map.GetLength(1); y++)
                {
                    if (Robot.Point.X == x && Robot.Point.Y == y) log += "x \t";
                    else   log += _map[x, y] + "\t";
                }

                log += "\n";
            }

            Debug.Log(log + "\n" + Robot.Directions);
        }
    }
}