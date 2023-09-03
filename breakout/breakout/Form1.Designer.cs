namespace breakout
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.area = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.intervalBall = new System.Windows.Forms.Timer(this.components);
            this.area.SuspendLayout();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.area.Controls.Add(this.info);
            this.area.Controls.Add(this.button1);
            this.area.Location = new System.Drawing.Point(12, 12);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(572, 544);
            this.area.TabIndex = 0;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.playArea);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.ForeColor = System.Drawing.Color.White;
            this.info.Location = new System.Drawing.Point(201, 283);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(166, 36);
            this.info.TabIndex = 1;
            this.info.Text = "Game Over";
            this.info.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.disabled);
            // 
            // timer
            // 
            this.timer.Interval = 32;
            this.timer.Tick += new System.EventHandler(this.startGame);
            // 
            // intervalBall
            // 
            this.intervalBall.Interval = 15;
            this.intervalBall.Tick += new System.EventHandler(this.ballAnimate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(596, 577);
            this.Controls.Add(this.area);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.movePlayer);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.stopPlayer);
            this.area.ResumeLayout(false);
            this.area.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel area;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer intervalBall;
        private System.Windows.Forms.Label info;
    }
}

