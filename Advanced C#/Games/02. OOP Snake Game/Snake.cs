namespace _02.OOP_Snake_Game
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;

    public class Snake : IRenderable
    {
        private Queue<Position> elements;

        public Snake()
        {
            this.elements = new Queue<Position>();
            this.InitializeSnake();
            this.HasEatenApple = false;
            this.IsDead = false;
        }

        public bool HasEatenApple { get; set; }

        public bool IsDead { get; set; }

        public void Move(Position direction)
        {
            var snakeHeadPosition = this.elements.Last();
            var nextSnakePosition = new Position(snakeHeadPosition.x + direction.x, snakeHeadPosition.y + direction.y);
            this.elements.Enqueue(nextSnakePosition);
            
            if (!this.HasEatenApple)
            {
                this.elements.Dequeue();
            }

            this.HasEatenApple = false;
        }

        public void Clear(IRenderer renderer)
        {
            renderer.Render(this.elements.First().x, this.elements.First().y, ' ');            
        }

        public void Render(IRenderer renderer)
        {
            foreach (var position in this.elements)
            {
                renderer.Render(position.x, position.y, 'o');
            }
        }

        private void InitializeSnake()
        {
            Position p1 = new Position(0, 0);
            Position p2 = new Position(1, 0);
            Position p3 = new Position(2, 0);

            this.elements.Enqueue(p1);
            this.elements.Enqueue(p2);
            this.elements.Enqueue(p3);
        }
    }
}
