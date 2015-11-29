﻿namespace TheSlum.GameObjects.Items
{
    public class Pill : Bonus
    {
        public Pill(string id)
            : base(id, 0, 0, 100)
        {
            this.Timeout = 1;
        }
    }
}
