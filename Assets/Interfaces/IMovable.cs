using System;

namespace Interfaces
{
    public enum MoveType
    {
        ThrustStart,
        ThrustStop,
        RotateLeft,
        RotateRight,
        RotateNone,
    }
    
    public interface IMovable
    {
        public event EventHandler<MovementEventArgs> Moved;
        public class MovementEventArgs : EventArgs
        {
            public MoveType MoveType;
        }

        public void SetThrusting(bool isThrusting, MoveType thrustType);
        public void SetRotating(bool isRotating, MoveType directionType);
        
    }
}