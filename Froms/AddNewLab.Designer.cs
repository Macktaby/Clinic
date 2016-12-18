namespace Clinic.Froms
{
    partial class AddNewLab
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
            this.combo_labName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_labResult = new System.Windows.Forms.TextBox();
            this.txt_normalRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_addLabAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // combo_labName
            // 
            this.combo_labName.FormattingEnabled = true;
            this.combo_labName.Location = new System.Drawing.Point(20, 49);
            this.combo_labName.Name = "combo_labName";
            this.combo_labName.Size = new System.Drawing.Size(193, 21);
            this.combo_labName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lab name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lab Result";
            // 
            // txt_labResult
            // 
            this.txt_labResult.Location = new System.Drawing.Point(17, 109);
            this.txt_labResult.Name = "txt_labResult";
            this.txt_labResult.Size = new System.Drawing.Size(196, 20);
            this.txt_labResult.TabIndex = 4;
            // 
            // txt_normalRange
            // 
            this.txt_normalRange.Location = new System.Drawing.Point(242, 48);
            this.txt_normalRange.Name = "txt_normalRange";
            this.txt_normalRange.Size = new System.Drawing.Size(196, 20);
            this.txt_normalRange.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Normal Range";
            // 
            // btn_addLabAction
            // 
            this.btn_addLabAction.Location = new System.Drawing.Point(318, 106);
            this.btn_addLabAction.Name = "btn_addLabAction";
            this.btn_addLabAction.Size = new System.Drawing.Size(75, 23);
            this.btn_addLabAction.TabIndex = 7;
            this.btn_addLabAction.Text = "Add lab";
            this.btn_addLabAction.UseVisualStyleBackColor = true;
            this.btn_addLabAction.Click += new System.EventHandler(this.btn_addLabAction_Click);
            // 
            // AddNewLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 183);
            this.Controls.Add(this.btn_addLabAction);
            this.Controls.Add(this.txt_normalRange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_labResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_labName);
            this.Name = "AddNewLab";
            this.Text = "New Lab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_labName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_labResult;
        private System.Windows.Forms.TextBox txt_normalRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_addLabAction;
    }
}