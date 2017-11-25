namespace PawPrints
{
    partial class CreateById
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblAnimalID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(67, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(142, 20);
            this.txtID.TabIndex = 0;
            // 
            // lblAnimalID
            // 
            this.lblAnimalID.AutoSize = true;
            this.lblAnimalID.Location = new System.Drawing.Point(7, 20);
            this.lblAnimalID.Name = "lblAnimalID";
            this.lblAnimalID.Size = new System.Drawing.Size(52, 13);
            this.lblAnimalID.TabIndex = 1;
            this.lblAnimalID.Text = "Animal ID";
            // 
            // lblName
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "lblName";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image";
            // 
            // btnUpload
            // 
            this.button1.Location = new System.Drawing.Point(94, 115);
            this.button1.Name = "btnUpload";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose Image";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlProfilePic
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(67, 50);
            this.panel1.Name = "pnlProfilePic";
            this.panel1.Size = new System.Drawing.Size(137, 59);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 188);
            this.btnConfirm.Name = "btnEdit";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // CreateById
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 227);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAnimalID);
            this.Controls.Add(this.txtID);
            this.Name = "CreateById";
            this.Text = "CreateById";
            this.Load += new System.EventHandler(this.CreateById_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblAnimalID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
    }
}