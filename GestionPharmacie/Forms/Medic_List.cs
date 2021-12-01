using GestionPharmacie.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPharmacie.Forms
{
    public partial class Medic_List : Form
    {
        public Medic_List()
        {
            InitializeComponent();
        }

        private void Medic_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacieDataSet.medic' table. You can move, or remove it, as needed.
            this.medicTableAdapter.Fill(this.pharmacieDataSet.medic);
          
        }

        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           int rowIndex = e.RowIndex; // Get the order of the current row 

            if (rowIndex != -1)
            {
                string newValue = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string idValue = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string columnHeader = guna2DataGridView1.Columns[e.ColumnIndex].DataPropertyName;

                // sent the new value and the column header to medic class to change value in database
                if (!String.IsNullOrEmpty(newValue))
                {

                    Medic m1 = new Medic();
                    if (m1.UpdateMedic(columnHeader, idValue, newValue))
                        MessageBox.Show("Updated with success", "Success");
                    else
                        MessageBox.Show("An error has occured. Please try again", "Error");
                }
                else
                    MessageBox.Show("Please enter a value", "Warning");
            }
        }
    }
}
