using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Moves_Test
{
    public partial class Form1 : Form
    {
        private bool left, right, up, down;
        private string leftDir = "../../Resources/CharL.gif";
        private string rightDir = "../../Resources/CharRight.gif";
        private string upDir = "../../Resources/CharUp.gif";
        private string downDir = "../../Resources/CharDown.gif";
        private bool leftSet, rightSet, upSet, downSet;

        public Form1()
        {
            InitializeComponent();
            Character.Image = Image.FromFile(rightDir);
        }

        private void GameTime_Tick(object sender, EventArgs e)
        {
            if (left)
            {
                Character.Left -= 1;
            }

            if (right)
            {
                Character.Left += 1;
            }

            if (down)
            {
                Character.Top += 1;
            }

            if (up)
            {
                Character.Top -= 1;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            Character.Enabled = true;

            if (e.KeyCode == Keys.Down)
            {
                down = true;
                if (!downSet)
                {
                    Character.Image = Image.FromFile(downDir);
                    rightSet = false;
                    leftSet = false;
                    upSet = false;
                    downSet = true;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                up = true;
                if (!upSet)
                {
                    Character.Image = Image.FromFile(upDir);
                    rightSet = false;
                    leftSet = false;
                    upSet = true;
                    downSet = false;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
                if (!leftSet)
                {
                    Character.Image = Image.FromFile(leftDir);
                    leftSet = true;
                    rightSet = false;
                    upSet = false;
                    downSet = false;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                right = true;
                if (!rightSet)
                {
                    Character.Image = Image.FromFile(rightDir);
                    rightSet = true;
                    leftSet = false;
                    upSet = false;
                    downSet = false;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Character.Enabled = false;

            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
