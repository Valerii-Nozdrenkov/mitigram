using System;
using System.Numerics;
using Traveler.Models;

namespace Traveler.Extensions;

public static class EnumExtensions
{
    public static Move GetMove(this char move)
    {
        switch (move)
        {
            case 'F': return Move.Forward;
            case 'B': return Move.Backward;
            case 'L': return Move.Left;
            case 'R': return Move.Right;
        }

        throw new ArgumentException(nameof(move));
    }

    public static Direction GetDirection(this char direction)
    {
        switch (direction)
        {
            case 'N': return Direction.North;
            case 'S': return Direction.South;
            case 'W': return Direction.West;
            case 'E': return Direction.East;
        }

        throw new ArgumentException(nameof(direction));
    }

    public static Complex DirectionToComplex(this Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return -Complex.ImaginaryOne;
            case Direction.South:
                return Complex.ImaginaryOne;
            case Direction.West:
                return -Complex.One;
            case Direction.East:
                return Complex.One;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}