﻿namespace Clinic.Froms
{
    partial class AddPastHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.btn_addValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Value";
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(12, 58);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(260, 20);
            this.txt_value.TabIndex = 1;
            // 
            // btn_addValue
            // 
            this.btn_addValue.Location = new System.Drawing.Point(96, 123);
            this.btn_addValue.Name = "btn_addValue";
            this.btn_addValue.Size = new System.Drawing.Size(92, 41);
            this.btn_addValue.TabIndex = 2;
            this.btn_addValue.Text = "Add Past History Value";
            this.btn_addValue.UseVisualStyleBackColor = true;
            this.btn_addValue.Click += new System.EventHandler(this.btn_addValue_Click);
            // 
            // AddPastHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.btn_addValue);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.label1);
            this.Name = "AddPastHistory";
            this.Text = "Add Past History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Button btn_addValue;
    }
}