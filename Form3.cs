using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_final
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void sheet3BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sheet3BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Sheet3' table. You can move, or remove it, as needed.
            this.sheet3TableAdapter.Fill(this.database1DataSet.Sheet3);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sheet3TableAdapter.FillBy(this.database1DataSet.Sheet3, "%"+ dataToolStripTextBox.Text+ "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show(); this.Close();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void sheet3DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void sheet3DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {try {
                int rowindex = e.RowIndex;
                DataGridViewRow row = sheet3DataGridView.Rows[rowindex];
                String s = row.Cells[0].Value + "";
                String s2 = s.Split('-')[0];
             //MessageBox.Show(s2.Trim());
                string path = ("Resources/" + s2.Trim() + ".jpg").Replace(" ", "");
              //    MessageBox.Show(path);
                Image imgcircle = Image.FromFile(path);
                pictureBox1.Image = imgcircle;
                //   MessageBox.Show(s2);
            }

            catch (Exception) { }
        }
    }
}
