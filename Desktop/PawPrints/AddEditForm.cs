﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPrints
{
    public partial class AddEditForm : Form
    {
        private Animal animal;
        private bool newAnimal;

        //user adds animal
        public AddEditForm()
        {
            InitializeComponent();
            animal = new Animal();
            newAnimal = true;
        }

        //user edits animal
        public AddEditForm(Animal a)
        {
            InitializeComponent();
            animal = a;
            newAnimal = false;
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            Form frm = this;
            //autofill with previous information if any
            txtName.Text = animal.name;
            if (animal.age != default(DateTime))
            {
                dtpBirthday.Value = animal.age;

            }
            txtBreed.Text = animal.breed;
            txtAnimalType.Text = animal.animal_type;
            txtWeight.Text = animal.weight.ToString();
            cboSize.Text = animal.size;
            txtNotes.Text = animal.notes;
        }

        //redirects to picture upload
        private void pnlProfilePic_Click(object sender, EventArgs e)
        {
            using (UploadImageForm uploadForm = new UploadImageForm(false))
            {
                if (uploadForm.ShowDialog() == DialogResult.OK)
                {
                    string fname = uploadForm.filename;
                    WebHandeler.addPicture(fname, animal.id);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            animal.name = txtName.Text;
            animal.age = dtpBirthday.Value.Date;
            animal.breed = txtBreed.Text;
            animal.animal_type = txtAnimalType.Text;
            int temp;
            if (int.TryParse(txtWeight.Text, out temp))
            {
                animal.weight = temp;
            }
            else
            {
                if (temp != 0)
                {
                    MessageBox.Show("Weight must be a whole number");
                }
            }
            animal.size = cboSize.Text;
            animal.notes = txtNotes.Text;
            if (newAnimal)
            {
                animal.shelter_id = ProgramMain.currentUser.shelter_id;
                if(WebHandeler.addPet(animal) == 1)
                {
                    MessageBox.Show("Pet Added!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was a problem adding the pet.");
                }
            }
            else
            {
                if (WebHandeler.updatePet(animal) == 1)
                {
                    MessageBox.Show("Pet updated!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was a problem updating this animal.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
