
namespace _11CompSciFinalEval
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblScore = new System.Windows.Forms.Label();
            this.lblFood = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblRules = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Black;
            this.lblScore.Font = new System.Drawing.Font("Sitka Subheading", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(22, 32);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(84, 26);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score - 0";
            // 
            // lblFood
            // 
            this.lblFood.BackColor = System.Drawing.Color.Red;
            this.lblFood.Location = new System.Drawing.Point(340, 177);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(21, 21);
            this.lblFood.TabIndex = 1;
            // 
            // lblCountdown
            // 
            this.lblCountdown.BackColor = System.Drawing.Color.Black;
            this.lblCountdown.Font = new System.Drawing.Font("Sitka Subheading", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCountdown.ForeColor = System.Drawing.Color.White;
            this.lblCountdown.Location = new System.Drawing.Point(878, 32);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(76, 25);
            this.lblCountdown.TabIndex = 2;
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(543, 177);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(21, 21);
            this.lblTimer.TabIndex = 3;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Yellow;
            this.btnPlay.Font = new System.Drawing.Font("Sitka Display", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlay.Location = new System.Drawing.Point(340, 310);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(249, 107);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Start Game";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblRules
            // 
            this.lblRules.Font = new System.Drawing.Font("Sitka Subheading", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRules.ForeColor = System.Drawing.Color.White;
            this.lblRules.Location = new System.Drawing.Point(147, 108);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(648, 199);
            this.lblRules.TabIndex = 5;
            this.lblRules.Text = resources.GetString("lblRules.Text");
            this.lblRules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Sitka Subheading", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(274, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(388, 81);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "SPEEDSNAKE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.lblFood);
            this.Controls.Add(this.lblScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.Label lblTitle;
    }
}

