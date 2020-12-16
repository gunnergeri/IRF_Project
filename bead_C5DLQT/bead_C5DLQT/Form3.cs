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
    public partial class Form3 : Form
    {

        Database1Entities context = new Database1Entities();
        public Form3()
        {
            InitializeComponent();

            context.Hypeshops.Load();
            dataGridView1.DataSource=context.Hypeshops.Local;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in context.Hypeshops
                                        where x.Modell.StartsWith(textBox1.Text)
                                        select x).ToList();


        }
    }
}
