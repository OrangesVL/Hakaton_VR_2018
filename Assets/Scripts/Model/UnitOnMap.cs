using System;
using Services;
using UnityEngine;

namespace Model
{
    public class UnitOnMap
    {
        private Point _point;
        private Directions _direction;

        public Directions Directions {
            get { return _direction; }
            set {
                Debug.Log("CHANGE DIRECTIONS!!!");
                _direction = value;
            }
        }

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
            if (Directions == Directions.Down)
            {
                Directions = Directions.Right;
                return;
            }
            if (Directions == Directions.Left)
            {
                Directions = Directions.Down;
                return;
            }
            if (Directions == Directions.Up)
            {
                Directions = Directions.Left;
                return;
            }
            if (Directions == Directions.Right)
            {
                Directions = Directions.Up;
                return;
            }
            //if (_direction == 0)
            //{
            //    _direction = (Directions)3;
            //    return;
            //}
            //_direction = (Directions)(((int)_direction-1)%3);
        }
        public void RotateRight()
        {
            if (Directions == Directions.Down)
            {
                Directions = Directions.Left;
                return;
            }
            if (Directions == Directions.Left)
            {
                Directions = Directions.Up;
                return;
            }
            if (Directions == Directions.Up)
            {
                Directions = Directions.Right;
                return;
            }
            if (Directions == Directions.Right)
            {
                Directions = Directions.Down;
                return;
            }
        }
        public void MoveForward()
        {
            switch (_direction)
            {
                case Directions.Up:
                    _point.Y--;
                    break;
                case Directions.Down:
                   _point.Y++;
                    break;
                case Directions.Left:
                    _point.X--;
                    break;
                case Directions.Right:
                    _point.X++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", _direction, null);
            }
        }

        public void MoveBack()
        {
            switch (_direction)
            {
                case Directions.Up:
                     _point.Y++;
                    break;
                case Directions.Down:
                     _point.Y--;
                    break;
                case Directions.Left:
                     _point.X++;
                    break;
                case Directions.Right:
                     _point.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", _direction, null);
            }
        }

    }
}