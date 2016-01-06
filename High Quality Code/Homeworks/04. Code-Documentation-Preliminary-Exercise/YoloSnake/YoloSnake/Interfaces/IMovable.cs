namespace YoloSnake.Interfaces
{
    using Enums;

    /// <summary>
    /// Moves a object from a position to another
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Returns current direction of movement
        /// </summary>
        Direction Direction { get; }

        
        void Move();

        /// <summary>
        /// Canges the current direction to a given one
        /// </summary>
        /// <param name="newDirection">
        /// The direction where we have to change to
        /// </param>
        /// <see cref="YoloSnake.Enums.Direction"/>
        void ChangeDirection(Direction newDirection);
    }
}