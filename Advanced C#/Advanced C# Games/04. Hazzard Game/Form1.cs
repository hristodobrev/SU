using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hazzard
{
    public partial class Form1 : Form
    {
        static int money = 100;
        static int currentBid = 10;
        static int firstRoll;
        static int secondRoll;
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            lbl_current_bid_counter.Text = currentBid.ToString();
            lbl_money_counter.Text = money.ToString();
        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            if (money >= currentBid)
            {
                money -= currentBid;
                lbl_money_counter.Text = money.ToString();
                firstRoll = rand.Next(20);
                secondRoll = rand.Next(10);
                lbl_first_roll.Text = firstRoll.ToString();
                lbl_second_roll.Text = secondRoll.ToString();
                if (firstRoll > secondRoll)
                {
                    money += 2 * currentBid;
                    lbl_money_counter.Text = money.ToString();
                }
            }
        }

        private void btn_raise_Click(object sender, EventArgs e)
        {
            currentBid += 10;
            lbl_current_bid_counter.Text = currentBid.ToString();
        }

        private void btn_decrease_Click(object sender, EventArgs e)
        {
            if (currentBid > 10)
            {
                currentBid -= 10;
                lbl_current_bid_counter.Text = currentBid.ToString();
            }
        }
    }
}
