﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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

            listBox1.DataSource = context.Hypeshops.Local;
            gettorles();
            listBox1.ValueMember = "Id";



        }





        private void gettorles()
        {
            listBox1.DataSource = (from x in context.Hypeshops
                                   where x.Megjelenés_év_.ToString().StartsWith(textBox1.Text)
                                   select x).ToList();
            listBox1.DisplayMember = "Modell";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gettorles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = Convert.ToInt32(listBox1.SelectedValue);
            var z = (from x in context.Hypeshops
                     where x.Id == d
                     select x).FirstOrDefault();
            context.Hypeshops.Remove(z);
            context.SaveChanges();
            listBox1.Refresh();
            gettorles();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var s in context.Hypeshops)
                {
                    sw.Write(s.Modell);
                    sw.Write(";");
                    sw.Write(s.Vásárlási_ár);
                    sw.Write(";");
                    sw.Write(s.Resell_Ár);
                    sw.Write(";");
                    sw.Write(s.Méret);
                    sw.Write(";");
                    sw.Write(s.Megjelenés_év_);
                    sw.Write(";");
                    sw.WriteLine();
                }


            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = (from x in context.Hypeshops
                                   where x.Modell.StartsWith(textBox2.Text)
                                   select x).ToList();
            listBox1.DisplayMember = "Modell";
        }

        private void databutton_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();

        }
    }
}