using System;
using System.IO;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void sheet1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sheet1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Sheet1' table. You can move, or remove it, as needed.
            this.sheet1TableAdapter.Fill(this.database1DataSet.Sheet1);

            button1.Visible = false;
            button2.Visible = false;
            label1.Visible = false;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sheet1TableAdapter.FillBy(this.database1DataSet.Sheet1,"%" +dataToolStripTextBox.Text+ "%");
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

        private void dataToolStripTextBox_Click(object sender, EventArgs e)
        {

        }
        String[] list;
        int index=0;
        private void sheet1DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {try
            {
                button1.Visible = true;
                button2.Visible = true;
                label1.Visible = true;

                int rowindex = e.RowIndex;
                DataGridViewRow row = sheet1DataGridView.Rows[rowindex];
                String s = row.Cells[0].Value + "";
                String s2 = s.Split(':')[1];
                String s3 = s2.Split('.')[0];
                String[] ll = s3.Split(',');
                list = new String[ll.Length];
                for (int ii = 0; ii < ll.Length; ii++)
                { list[ii] = ("Resources/" + ll[ii].Trim() + ".jpg").Replace(" ",""); }

                Image imgcircle = Image.FromFile(list[0]);
                pictureBox1.Image = imgcircle;
            }
            catch (Exception) { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            
            index--;
            
            if (index < 0)
                index=list.Length-1;
            Image imgcircle = Image.FromFile(list[index]);
            pictureBox1.Image = imgcircle;
        }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {try
            {

                index++;
                if (index > list.Length - 1)
                    index = 0;
                Image imgcircle = Image.FromFile(list[index]);
                pictureBox1.Image = imgcircle;
            }
            catch (Exception) { }
        }
    }
}
