using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bead_C5DLQT
{
    public partial class Form1 : Form
    {

        Database1Entities context = new Database1Entities();

        public Form1()
        {
            InitializeComponent();
            context.Hypeshops.Load();
            dataGridView1.DataSource = context.Hypeshops.Local;
            listBox1.DataSource = context.Hypeshops.Local;
            gettorles();
            listBox1.ValueMember = "Id";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = Convert.ToInt32(listBox1.SelectedValue);
            var z = (from x in context.Hypeshops
                     where x.Id ==  d
                     select x).FirstOrDefault();
            context.Hypeshops.Remove(z);
            context.SaveChanges();
            dataGridView1.Refresh();
            listBox1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gettorles();
        }

        private void gettorles()
        {
            listBox1.DataSource = (from x in context.Hypeshops
                                   where x.Megjelenés_év_.ToString().StartsWith(textBox1.Text)
                                   select x).ToList();
            listBox1.DisplayMember = "Modell";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
