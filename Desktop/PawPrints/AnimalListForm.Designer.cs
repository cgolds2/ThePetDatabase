namespace PawPrints
{
    partial class AnimalListForm
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
            this.btnAddPet = new System.Windows.Forms.Button();
            this.btnEditPet = new System.Windows.Forms.Button();
            this.dgvAnimalList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPet
            // 
            this.btnAddPet.Location = new System.Drawing.Point(12, 465);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(75, 23);
            this.btnAddPet.TabIndex = 5;
            this.btnAddPet.Text = "Add";
            this.btnAddPet.UseVisualStyleBackColor = true;
            // 
            // btnEditPet
            // 
            this.btnEditPet.Location = new System.Drawing.Point(397, 465);
            this.btnEditPet.Name = "btnEditPet";
            this.btnEditPet.Size = new System.Drawing.Size(75, 23);
            this.btnEditPet.TabIndex = 4;
            this.btnEditPet.Text = "Edit";
            this.btnEditPet.UseVisualStyleBackColor = true;
            // 
            // dgvAnimalList
            // 
            this.dgvAnimalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.petName,
            this.Picture});
            this.dgvAnimalList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAnimalList.Location = new System.Drawing.Point(12, 12);
            this.dgvAnimalList.Name = "dgvAnimalList";
            this.dgvAnimalList.Size = new System.Drawing.Size(460, 447);
            this.dgvAnimalList.TabIndex = 3;
            this.dgvAnimalList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // petName
            // 
            this.petName.HeaderText = "Name";
            this.petName.Name = "petName";
            // 
            // Picture
            // 
            this.Picture.HeaderText = "Profile Picture";
            this.Picture.Name = "Picture";
            this.Picture.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Picture.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Picture.Width = 200;
            // 
            // AnimalListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 497);
            this.Controls.Add(this.btnAddPet);
            this.Controls.Add(this.btnEditPet);
            this.Controls.Add(this.dgvAnimalList);
            this.Name = "AnimalListForm";
            this.Text = "AnimalListForm";
            this.Load += new System.EventHandler(this.AnimalListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.Button btnEditPet;
        private System.Windows.Forms.DataGridView dgvAnimalList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn petName;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
    }
}