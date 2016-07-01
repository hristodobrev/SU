namespace _02.OOP_Snake_Game
{
    public struct Position
    {
        public int x, y;

        public Position(int p1, int p2)
        {
            x = p1;
            y = p2;
        }

        public bool CompareTo(Position otherPosition)
        {
            if (this.x != otherPosition.x || this.y != otherPosition.y)
            {
                return false;
            }

            return true;
        }
    }
}
