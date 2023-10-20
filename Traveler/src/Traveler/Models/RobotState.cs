using System;
using System.Numerics;
using Traveler.Extensions;

namespace Traveler.Models
{
    public record RobotState
    {
        public Complex Position { get; private set; }
        public Complex Direction { get; private set; }

        public RobotState(int positionX, int positionY, char direction)
        {
            Position = new Complex(positionX, positionY);
            Direction = direction.GetDirection().DirectionToComplex();
        }

        public void Move(Move move)
        {
            switch (move)
            {
                case Models.Move.Forward:
                    MoveForward();
                    break;
                case Models.Move.Backward:
                    MoveBackward();
                    break;
                case Models.Move.Left:
                    RotateLeft();
                    break;
                case Models.Move.Right:
                    RotateRight();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(move), move, null);
            }
        }

        public (int, int, char) ToTupleFormat()
        {
            var direction = 'N';
            if (Direction.Real > 0)
            {
                direction = 'E';
            }
            else if (Direction.Imaginary > 0)
            {
                direction = 'S';
            }
            else if (Direction.Real < 0)
            {
                direction = 'W';
            }

            return new ValueTuple<int, int, char>(Convert.ToInt32(Position.Real), Convert.ToInt32(Position.Imaginary), direction);
        }

        private void MoveForward()
        {
            Position += Direction;
        }

        private void MoveBackward()
        {
            Position -= Direction;
        }

        private void RotateLeft()
        {
            Direction *= -Complex.ImaginaryOne;
        }

        private void RotateRight()
        {
            Direction *= Complex.ImaginaryOne;
        }
    }
}