using System;
using System.Numerics;
using Traveler.Extensions;

namespace Traveler.Models
{
    public readonly struct RobotState : IEquatable<RobotState>
    {
        public Complex Position { get; }
        public Complex Direction { get; }

        public RobotState(int positionX, int positionY, char direction)
        {
            Position = new Complex(positionX, positionY);
            Direction = direction.GetDirection().DirectionToComplex();
        }

        public RobotState(Complex position, Complex direction)
        {
            Direction = direction;
            Position = position;
        }

        /// <summary>
        /// Moves the robot
        /// </summary>
        /// <param name="move">Direction</param>
        /// <returns>New robot position</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public RobotState Move(Move move)
        {
            switch (move)
            {
                case Models.Move.Forward:
                    return new RobotState(Position + Direction, Direction);
                case Models.Move.Backward:
                    return new RobotState(Position - Direction, Direction);
                case Models.Move.Left:
                    return new RobotState(Position, Direction * -Complex.ImaginaryOne);
                case Models.Move.Right:
                    return new RobotState(Position, Direction * Complex.ImaginaryOne);
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

        public bool Equals(RobotState other)
        {
            return Position.Equals(other.Position) && Direction.Equals(other.Direction);
        }

        public override bool Equals(object obj)
        {
            return obj is RobotState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, Direction);
        }
    }
}