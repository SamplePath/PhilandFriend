﻿namespace TestBed
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
            this.cmdGetDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdGetDate
            // 
            this.cmdGetDate.Location = new System.Drawing.Point(61, 26);
            this.cmdGetDate.Name = "cmdGetDate";
            this.cmdGetDate.Size = new System.Drawing.Size(168, 54);
            this.cmdGetDate.TabIndex = 0;
            this.cmdGetDate.Text = "Get Date";
            this.cmdGetDate.UseVisualStyleBackColor = true;
            this.cmdGetDate.Click += new System.EventHandler(this.cmdGetDate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 357);
            this.Controls.Add(this.cmdGetDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdGetDate;
    }
}

