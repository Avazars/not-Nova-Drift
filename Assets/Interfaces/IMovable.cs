namespace Interfaces
{
    public interface IMovable
    {
        public void Rotate(float impulse);
        public void Thrust(float force);
    }
}