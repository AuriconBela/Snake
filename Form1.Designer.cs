﻿namespace Snake
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pbBoard = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbBoard).BeginInit();
            SuspendLayout();
            // 
            // pbBoard
            // 
            pbBoard.Dock = DockStyle.Fill;
            pbBoard.Location = new Point(0, 0);
            pbBoard.Name = "pbBoard";
            pbBoard.Size = new Size(800, 450);
            pbBoard.TabIndex = 0;
            pbBoard.TabStop = false;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbBoard;
        private System.Windows.Forms.Timer timer;
    }
}
