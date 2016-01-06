namespace YoloSnake.Interfaces
{
    /// <summary>
    /// Draws using a certain drawer
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws on a canvas using an implementation of a drawer
        /// </summary>
        /// <param name="drawer">
        /// Implementation of a drawer to a draw symbol in a certain point
        /// </param>
        void Draw(IDrawer drawer);
    }
}