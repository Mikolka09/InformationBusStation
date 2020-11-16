using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationBusStation
{
    public partial class Form3 : Form
    {
        public List<InfoList> info { get; set; } = new List<InfoList>();
        bool sort = true;
        public Form3()
        {
            InitializeComponent();

        }


        public void InfoAddList()
        {
            foreach (var item in info)
            {
                ListViewItem it = new ListViewItem(item.nomer);
                it.SubItems.Add(item.type);
                it.SubItems.Add(item.punktNaz);
                it.SubItems.Add(item.dataOtpr.ToShortDateString());
                it.SubItems.Add(item.timeOtpr);
                it.SubItems.Add(item.dataPrib.ToShortDateString());
                it.SubItems.Add(item.timePrib);
                listView1.Items.Add(it);
            }
        }

        public void InfoAddList(List<InfoList> ls)
        {
            foreach (var item in ls)
            {
                ListViewItem it = new ListViewItem(item.nomer);
                it.SubItems.Add(item.type);
                it.SubItems.Add(item.punktNaz);
                it.SubItems.Add(item.dataOtpr.ToShortDateString());
                it.SubItems.Add(item.timeOtpr);
                it.SubItems.Add(item.dataPrib.ToShortDateString());
                it.SubItems.Add(item.timePrib);
                listView1.Items.Add(it);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && sort == true)
            {
                info.Sort(new NomerComparer());
                sort = false;
            }
            else if (e.Column == 0 && sort == false)
            {
                info.Sort(new NomerComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 1 && sort == true)
            {
                info.Sort(new TypeComparer());
                sort = false;
            }
            else if (e.Column == 1 && sort == false)
            {
                info.Sort(new TypeComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 2 && sort == true)
            {
                info.Sort(new PunktNazComparer());
                sort = false;
            }
            else if (e.Column == 2 && sort == false)
            {
                info.Sort(new PunktNazComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 3 && sort == true)
            {
                info.Sort(new DateOtprComparer());
                sort = false;
            }
            else if (e.Column == 3 && sort == false)
            {
                info.Sort(new DateOtprComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 4 && sort == true)
            {
                info.Sort(new TimeOtprComparer());
                sort = false;
            }
            else if (e.Column == 4 && sort == false)
            {
                info.Sort(new TimeOtprComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 5 && sort == true)
            {
                info.Sort(new DatePribComparer());
                sort = false;
            }
            else if (e.Column == 5 && sort == false)
            {
                info.Sort(new DatePribComparer());
                info.Reverse();
                sort = true;
            }
            if (e.Column == 6 && sort == true)
            {
                info.Sort(new TimePribComparer());
                sort = false;
            }
            else if (e.Column == 6 && sort == false)
            {
                info.Sort(new TimePribComparer());
                info.Reverse();
                sort = true;
            }
            listView1.Items.Clear();
            InfoAddList();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InfoAddList();
            comboBox1.Items.Add("");
            comboBox2.Items.Add("");
            comboBox3.Items.Add("");
            comboBox4.Items.Add("");
            foreach (var item in info)
            {
                if (!comboBox1.Items.Contains(item.dataOtpr.ToShortDateString()))
                    comboBox1.Items.Add(item.dataOtpr.ToShortDateString());
                if (!comboBox2.Items.Contains(item.timeOtpr))
                    comboBox2.Items.Add(item.timeOtpr);
                if (!comboBox3.Items.Contains(item.dataPrib.ToShortDateString()))
                    comboBox3.Items.Add(item.dataPrib.ToShortDateString());
                if (!comboBox4.Items.Contains(item.timePrib))
                    comboBox4.Items.Add(item.timePrib);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Все файлы (*.*)|*.*|Текстовые файлы (*.txt)|*.txt |PDF файлы (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding(1251)))
                {
                    foreach (var item in info)
                    {
                        sw.WriteLine(item.nomer);
                        sw.WriteLine(item.type);
                        sw.WriteLine(item.punktNaz);
                        sw.WriteLine(item.dataOtpr.ToShortDateString());
                        sw.WriteLine(item.timeOtpr);
                        sw.WriteLine(item.dataPrib.ToShortDateString());
                        sw.WriteLine(item.timePrib);
                    }
                }
            }
        }


        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<InfoList> ls = new List<InfoList>();
            foreach (var item in info)
            {

                if (item.dataOtpr.ToShortDateString() == comboBox1.Text && comboBox2.Text == ""
                    && comboBox3.Text == "" && comboBox4.Text == "")
                    ls.Add(item);
                if (item.dataOtpr.ToShortDateString() == comboBox1.Text && item.timeOtpr == comboBox2.Text
                    && comboBox3.Text == "" && comboBox4.Text == "")
                    ls.Add(item);
                if (item.dataOtpr.ToShortDateString() == comboBox1.Text && item.timeOtpr == comboBox2.Text
                    && item.dataPrib.ToShortDateString() == comboBox3.Text && comboBox4.Text == "")
                    ls.Add(item);
                if (item.dataOtpr.ToShortDateString() == comboBox1.Text && item.timeOtpr == comboBox2.Text
                    && item.dataPrib.ToShortDateString() == comboBox3.Text && item.timePrib == comboBox4.Text)
                    ls.Add(item);

                if (item.timeOtpr == comboBox2.Text && comboBox1.Text == ""
                    && comboBox3.Text == "" && comboBox4.Text == "")
                    ls.Add(item);
                if (item.timeOtpr == comboBox2.Text && comboBox1.Text == ""
                   && item.dataPrib.ToShortDateString() == comboBox3.Text && comboBox4.Text == "")
                    ls.Add(item);
                if (item.timeOtpr == comboBox2.Text && comboBox1.Text == ""
                  && item.dataPrib.ToShortDateString() == comboBox3.Text && item.timePrib == comboBox4.Text)
                    ls.Add(item);
                if (item.timeOtpr == comboBox2.Text && comboBox1.Text == ""
                    && comboBox3.Text == "" && item.timePrib == comboBox4.Text)
                    ls.Add(item);

                if (item.dataPrib.ToShortDateString() == comboBox3.Text && comboBox1.Text == ""
                    && comboBox2.Text == "" && comboBox4.Text == "")
                    ls.Add(item);
                if (item.dataPrib.ToShortDateString() == comboBox3.Text && comboBox1.Text == ""
                   && comboBox2.Text == "" && item.timePrib == comboBox4.Text)
                    ls.Add(item);
                if (item.dataPrib.ToShortDateString() == comboBox3.Text && item.dataOtpr.ToShortDateString() == comboBox1.Text
                    && comboBox2.Text == "" && comboBox4.Text == "")
                    ls.Add(item);

                if (item.timePrib == comboBox4.Text && comboBox1.Text == ""
                    && comboBox2.Text == "" && comboBox3.Text == "")
                    ls.Add(item);
                if (item.timePrib == comboBox4.Text && item.dataOtpr.ToShortDateString() == comboBox1.Text
                    && comboBox2.Text == "" && comboBox3.Text == "")
                    ls.Add(item);

            }
            if (ls.Count == 0)
            {
                listView1.Items.Clear();
                InfoAddList();
            }
            else
            {
                listView1.Items.Clear();
                InfoAddList(ls);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            listView1.Items.Clear();
            InfoAddList();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           string shapka =
           "\t\t\t\t СПИСОК ОТСОРТИРОВАННЫХ РЕЙСОВ\n" +
           "====================================================================================================\n"+
           "|| Номер ||   Тип    || Пункт Назнач. ||  Дата Отпр. || Время Отпр. ||  Дата Приб. || Время Приб. ||\n"+
           "====================================================================================================";
            string end =
           "====================================================================================================\n";

            using (StreamWriter sw = new StreamWriter("search_print.txt", false, Encoding.GetEncoding(1251)))
            {
                sw.WriteLine(shapka);
                foreach (var item in info)
                {
                    sw.WriteLine("|| {0}|| {1}|| {2}|| {3}|| {4}|| {5}|| {6}||", item.nomer.PadRight(6), item.type.PadRight(9), 
                        item.punktNaz.PadRight(14), item.dataOtpr.ToShortDateString().PadRight(12), item.timeOtpr.PadRight(12),
                        item.dataPrib.ToShortDateString().PadRight(12), item.timePrib.PadRight(12));
                }
                sw.WriteLine(end);
            }
            MessageBox.Show("Список рейсов напечатан в файл!!!");
        }
    }
}
