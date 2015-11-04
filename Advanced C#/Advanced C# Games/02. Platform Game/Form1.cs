using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02.Platform_Game
{
    public partial class Form1 : Form
    {

        bool right, left;
        bool jump;
        int gravity = 20;
        int force;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool rightCollision =
                player.Right > block.Left - 2
                && player.Right < block.Right + player.Width / 2
                && player.Bottom > block.Top
                && player.Top < block.Bottom;

            bool leftColision =
                player.Left < block.Right + 2
                && player.Left > block.Left - player.Width / 2
                && player.Bottom > block.Top
                && player.Top < block.Bottom;

            if (rightCollision)
            {
                right = false;
            }

            if (leftColision)
            {
                left = false;
            }

            if (right)
            {
                player.Left += 3;
            }

            if (left)
            {
                player.Left -= 3;
            }

            if (jump)
            {
                player.Top -= force;
                force--;
            }

            if (player.Right > block.Left && player.Left < block.Right && player.Top < block.Bottom && player.Bottom > block.Bottom + player.Height)
            {
                player.Top = block.Bottom;
                force = 0;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height;
                jump = false;
            }
            else
            {
                player.Top += 5;
            }

            if (player.Right > block.Left && player.Left < block.Right && player.Bottom < block.Bottom && player.Top + player.Height >= block.Top)
            {
                player.Top = block.Top - player.Height - 1;
                force = 0;
                jump = false;
            }

            if (player.Left + player.Width - 1 > block.Left && player.Left + player.Width + 5 < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                player.Top = screen.Height - block.Height - player.Height;
                force = 0;
                jump = false;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            if (!jump)
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                {
                    jump = true;
                    force = gravity;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }
    }
}
