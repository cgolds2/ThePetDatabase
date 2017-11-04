namespace PawPrints
{
    partial class UploadImageForm
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
            this.pnlImagePreview = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlImagePreview
            // 
            this.pnlImagePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImagePreview.Location = new System.Drawing.Point(12, 12);
            this.pnlImagePreview.Name = "pnlImagePreview";
            this.pnlImagePreview.Size = new System.Drawing.Size(450, 334);
            this.pnlImagePreview.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(144, 381);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(170, 352);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(138, 23);
            this.btnChooseImage.TabIndex = 2;
            this.btnChooseImage.Text = "Choose Image";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // UploadImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 415);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pnlImagePreview);
            this.Name = "UploadImageForm";
            this.Text = "UploadImageForm";
            this.Load += new System.EventHandler(this.UploadImageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlImagePreview;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnCancel;
    }
}