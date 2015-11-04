namespace Hazzard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_roll = new System.Windows.Forms.Button();
            this.btn_raise = new System.Windows.Forms.Button();
            this.btn_decrease = new System.Windows.Forms.Button();
            this.lbl_money = new System.Windows.Forms.Label();
            this.lbl_money_counter = new System.Windows.Forms.Label();
            this.lbl_current_bid = new System.Windows.Forms.Label();
            this.lbl_current_bid_counter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_first_roll = new System.Windows.Forms.Label();
            this.lbl_second_roll = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_roll
            // 
            this.btn_roll.Location = new System.Drawing.Point(12, 12);
            this.btn_roll.Name = "btn_roll";
            this.btn_roll.Size = new System.Drawing.Size(64, 23);
            this.btn_roll.TabIndex = 0;
            this.btn_roll.Text = "Roll";
            this.btn_roll.UseVisualStyleBackColor = true;
            this.btn_roll.Click += new System.EventHandler(this.btn_roll_Click);
            // 
            // btn_raise
            // 
            this.btn_raise.Location = new System.Drawing.Point(12, 41);
            this.btn_raise.Name = "btn_raise";
            this.btn_raise.Size = new System.Drawing.Size(64, 23);
            this.btn_raise.TabIndex = 1;
            this.btn_raise.Text = "Raise";
            this.btn_raise.UseVisualStyleBackColor = true;
            this.btn_raise.Click += new System.EventHandler(this.btn_raise_Click);
            // 
            // btn_decrease
            // 
            this.btn_decrease.Location = new System.Drawing.Point(12, 70);
            this.btn_decrease.Name = "btn_decrease";
            this.btn_decrease.Size = new System.Drawing.Size(64, 23);
            this.btn_decrease.TabIndex = 2;
            this.btn_decrease.Text = "Decrease";
            this.btn_decrease.UseVisualStyleBackColor = true;
            this.btn_decrease.Click += new System.EventHandler(this.btn_decrease_Click);
            // 
            // lbl_money
            // 
            this.lbl_money.AutoSize = true;
            this.lbl_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_money.Location = new System.Drawing.Point(82, 15);
            this.lbl_money.Name = "lbl_money";
            this.lbl_money.Size = new System.Drawing.Size(54, 17);
            this.lbl_money.TabIndex = 3;
            this.lbl_money.Text = "Money:";
            // 
            // lbl_money_counter
            // 
            this.lbl_money_counter.AutoSize = true;
            this.lbl_money_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_money_counter.Location = new System.Drawing.Point(182, 15);
            this.lbl_money_counter.Name = "lbl_money_counter";
            this.lbl_money_counter.Size = new System.Drawing.Size(32, 17);
            this.lbl_money_counter.TabIndex = 4;
            this.lbl_money_counter.Text = "100";
            // 
            // lbl_current_bid
            // 
            this.lbl_current_bid.AutoSize = true;
            this.lbl_current_bid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_current_bid.Location = new System.Drawing.Point(82, 44);
            this.lbl_current_bid.Name = "lbl_current_bid";
            this.lbl_current_bid.Size = new System.Drawing.Size(83, 17);
            this.lbl_current_bid.TabIndex = 3;
            this.lbl_current_bid.Text = "Current Bid:";
            // 
            // lbl_current_bid_counter
            // 
            this.lbl_current_bid_counter.AutoSize = true;
            this.lbl_current_bid_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_current_bid_counter.Location = new System.Drawing.Point(182, 44);
            this.lbl_current_bid_counter.Name = "lbl_current_bid_counter";
            this.lbl_current_bid_counter.Size = new System.Drawing.Size(24, 17);
            this.lbl_current_bid_counter.TabIndex = 4;
            this.lbl_current_bid_counter.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Roll 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Roll 2:";
            // 
            // lbl_first_roll
            // 
            this.lbl_first_roll.AutoSize = true;
            this.lbl_first_roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_first_roll.Location = new System.Drawing.Point(123, 73);
            this.lbl_first_roll.Name = "lbl_first_roll";
            this.lbl_first_roll.Size = new System.Drawing.Size(24, 17);
            this.lbl_first_roll.TabIndex = 4;
            this.lbl_first_roll.Text = "10";
            // 
            // lbl_second_roll
            // 
            this.lbl_second_roll.AutoSize = true;
            this.lbl_second_roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_second_roll.Location = new System.Drawing.Point(196, 73);
            this.lbl_second_roll.Name = "lbl_second_roll";
            this.lbl_second_roll.Size = new System.Drawing.Size(24, 17);
            this.lbl_second_roll.TabIndex = 4;
            this.lbl_second_roll.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 103);
            this.Controls.Add(this.lbl_second_roll);
            this.Controls.Add(this.lbl_first_roll);
            this.Controls.Add(this.lbl_current_bid_counter);
            this.Controls.Add(this.lbl_money_counter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_current_bid);
            this.Controls.Add(this.lbl_money);
            this.Controls.Add(this.btn_decrease);
            this.Controls.Add(this.btn_raise);
            this.Controls.Add(this.btn_roll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_roll;
        private System.Windows.Forms.Button btn_raise;
        private System.Windows.Forms.Button btn_decrease;
        private System.Windows.Forms.Label lbl_money;
        private System.Windows.Forms.Label lbl_money_counter;
        private System.Windows.Forms.Label lbl_current_bid;
        private System.Windows.Forms.Label lbl_current_bid_counter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_first_roll;
        private System.Windows.Forms.Label lbl_second_roll;
    }
}

