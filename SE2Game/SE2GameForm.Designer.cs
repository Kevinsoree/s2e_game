namespace SE2Game
{
    partial class SE2GameForm
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
            this.components = new System.ComponentModel.Container();
            this.picGameWorld = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lbHP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGameWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // picGameWorld
            // 
            this.picGameWorld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGameWorld.Location = new System.Drawing.Point(9, 10);
            this.picGameWorld.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picGameWorld.Name = "picGameWorld";
            this.picGameWorld.Size = new System.Drawing.Size(481, 481);
            this.picGameWorld.TabIndex = 0;
            this.picGameWorld.TabStop = false;
            this.picGameWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picGameWorld_Paint);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 33;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(495, 440);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbHP
            // 
            this.lbHP.AutoSize = true;
            this.lbHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHP.ForeColor = System.Drawing.Color.DarkRed;
            this.lbHP.Location = new System.Drawing.Point(542, 466);
            this.lbHP.Name = "lbHP";
            this.lbHP.Size = new System.Drawing.Size(51, 25);
            this.lbHP.TabIndex = 6;
            this.lbHP.Text = "100";
            this.lbHP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(492, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "HP:";
            // 
            // btnRandomMap
            // 
            this.btnRandomMap.Location = new System.Drawing.Point(495, 10);
            this.btnRandomMap.Name = "btnRandomMap";
            this.btnRandomMap.Size = new System.Drawing.Size(96, 23);
            this.btnRandomMap.TabIndex = 9;
            this.btnRandomMap.Text = "Randomize map";
            this.btnRandomMap.UseVisualStyleBackColor = true;
            this.btnRandomMap.Click += new System.EventHandler(this.btnRandomMap_Click);
            // 
            // SE2GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 496);
            this.Controls.Add(this.btnRandomMap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHP);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picGameWorld);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "SE2GameForm";
            this.Text = "SE2GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.picGameWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGameWorld;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRandomMap;
    }
}