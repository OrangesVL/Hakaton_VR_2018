using System;
using Services;

namespace Model
{
    public class UnitOnMap
    {
        private Point _point;
        private Directions _direction;

        public Point Point
        {
            get { return _point; }
        }

        public UnitOnMap(Point startPoint, Directions direction)
        {
            _direction = direction;
            _point = startPoint;
        }

        public void RotateLeft()
        {
            _direction = _direction - 1;
        }
        public void RotateRight()
        {
            _direction = _direction + 1;
        }
        public void MoveForward(bool flag)
        {
            switch (_direction)
            {
                case Directions.Up:
                    if (flag) _point.Y--;
                    else _point.Y++;
                    break;
                case Directions.Down:
                    if (flag) _point.Y++;
                    else _point.Y--;
                    break;
                case Directions.Left:
                    if (flag) _point.X--;
                    else _point.X++;
                    break;
                case Directions.Right:
                    if (flag) _point.X++;
                    else _point.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", _direction, null);
            }
        }
    }
}