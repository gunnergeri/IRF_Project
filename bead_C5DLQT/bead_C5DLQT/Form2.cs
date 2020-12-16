using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bead_C5DLQT
{
    public partial class Form2 : Form
    {

        private int totalsec;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
                this.comboBox2.Items.Add(i.ToString());

            }
            for(int j=0; j < 24; j++)
            {
                this.comboBox3.Items.Add(j.ToString());
            }
        }

        private void class11_Click_1(object sender, EventArgs e)
        {
            this.class11.Enabled = false;

            int min = int.Parse(this.comboBox1.SelectedItem.ToString());
            int sec = int.Parse(this.comboBox2.SelectedItem.ToString());
            int h = int.Parse(this.comboBox3.SelectedItem.ToString());

            totalsec = (h * 3600) + (min * 60) + sec;

            this.timer1.Enabled = true;
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (totalsec > 0)
            {
                totalsec--;
                int h = totalsec / 3600 ;
                int min = totalsec / 60 - (h*60);
                int sec = totalsec -(min*60)-(h*3600);
                this.label2.Text = h.ToString() + ":" + min.ToString() + ":" + sec.ToString();
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("DROP VAN!!");
            }
        }

 
    }

}

