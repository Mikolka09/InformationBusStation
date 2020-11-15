using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationBusStation
{
    public partial class Form2 : Form
    {
        public InfoList list { get; set;} = new InfoList();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = list.nomer;
            textBox2.Text = list.type;
            textBox3.Text = list.punktNaz;
            textBox4.Text = list.dataOtpr.ToShortDateString();
            textBox5.Text = list.timeOtpr;
            textBox6.Text = list.dataPrib.ToShortDateString();
            textBox7.Text = list.timePrib;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.nomer = textBox1.Text;
            list.type = textBox2.Text;
            list.punktNaz = textBox3.Text;
            list.dataOtpr = Convert.ToDateTime(textBox4.Text);
            list.timeOtpr = textBox5.Text;
            list.dataPrib = Convert.ToDateTime(textBox6.Text);
            list.timePrib = textBox7.Text;
        }
    }
}
