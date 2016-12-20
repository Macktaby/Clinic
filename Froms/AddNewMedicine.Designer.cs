namespace Clinic.Froms
{
    partial class AddNewMedicine
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
            this.btn_addMedicineAction = new System.Windows.Forms.Button();
            this.txt_medName = new System.Windows.Forms.TextBox();
            this.txt_dose = new System.Windows.Forms.TextBox();
            this.txt_arDesc = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_conc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_addMedicineAction
            // 
            this.btn_addMedicineAction.Location = new System.Drawing.Point(412, 200);
            this.btn_addMedicineAction.Name = "btn_addMedicineAction";
            this.btn_addMedicineAction.Size = new System.Drawing.Size(75, 23);
            this.btn_addMedicineAction.TabIndex = 0;
            this.btn_addMedicineAction.Text = "Add Medicine";
            this.btn_addMedicineAction.UseVisualStyleBackColor = true;
            this.btn_addMedicineAction.Click += new System.EventHandler(this.btn_addMedicineAction_Click);
            // 
            // txt_medName
            // 
            this.txt_medName.Location = new System.Drawing.Point(83, 37);
            this.txt_medName.Name = "txt_medName";
            this.txt_medName.Size = new System.Drawing.Size(163, 20);
            this.txt_medName.TabIndex = 1;
            // 
            // txt_dose
            // 
            this.txt_dose.Location = new System.Drawing.Point(83, 172);
            this.txt_dose.Name = "txt_dose";
            this.txt_dose.Size = new System.Drawing.Size(163, 20);
            this.txt_dose.TabIndex = 2;
            // 
            // txt_arDesc
            // 
            this.txt_arDesc.Location = new System.Drawing.Point(357, 86);
            this.txt_arDesc.Multiline = true;
            this.txt_arDesc.Name = "txt_arDesc";
            this.txt_arDesc.Size = new System.Drawing.Size(163, 61);
            this.txt_arDesc.TabIndex = 3;
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(83, 86);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(163, 61);
            this.txt_desc.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Medicine\r\nName";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "English\r\nDescription";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Concentration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dose";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Arabic\r\nDescription";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_conc
            // 
            this.txt_conc.Location = new System.Drawing.Point(357, 37);
            this.txt_conc.Name = "txt_conc";
            this.txt_conc.Size = new System.Drawing.Size(163, 20);
            this.txt_conc.TabIndex = 11;
            // 
            // AddNewMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 247);
            this.Controls.Add(this.txt_conc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.txt_arDesc);
            this.Controls.Add(this.txt_dose);
            this.Controls.Add(this.txt_medName);
            this.Controls.Add(this.btn_addMedicineAction);
            this.Name = "AddNewMedicine";
            this.Text = "Add New Medicine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addMedicineAction;
        private System.Windows.Forms.TextBox txt_medName;
        private System.Windows.Forms.TextBox txt_dose;
        private System.Windows.Forms.TextBox txt_arDesc;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_conc;
    }
}