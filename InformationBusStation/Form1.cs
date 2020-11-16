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
    public partial class Form1 : Form
    {
        List<InfoList> info = new List<InfoList>();
        bool sort = true;
        public Form1()
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "ДОБАВЛЕНИЕ РЕЙСА";
            InfoList list = new InfoList();
            f2.list = list;
            if (f2.ShowDialog() == DialogResult.OK)
            {
                info.Add(f2.list);
                listView1.Items.Clear();
                InfoAddList();
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfoList st = new InfoList();
            ListViewItem item = listView1.SelectedItems[0];
            st.nomer = item.SubItems[0].Text;
            st.type = item.SubItems[1].Text;
            st.punktNaz = item.SubItems[2].Text;
            st.dataOtpr = Convert.ToDateTime(item.SubItems[3].Text);
            st.timeOtpr = item.SubItems[4].Text;
            st.dataPrib = Convert.ToDateTime(item.SubItems[5].Text);
            st.timePrib = item.SubItems[6].Text;
            Form2 f2 = new Form2();
            f2.Text = "РЕДАКТИРОВАНИЕ РЕЙСА";
            f2.list = st;
            if (f2.ShowDialog() == DialogResult.OK)
            {
                int k = 0;
                for (int i = 0; i < info.Count; i++)
                {
                    if (info[i].nomer == st.nomer)
                    {
                        k = i;
                        break;
                    }
                }
                info.RemoveAt(k);
                info.Add(f2.list);
                listView1.Items.Clear();
                InfoAddList();
            }
        }

        private void dellToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfoList st = new InfoList();
            ListViewItem item = listView1.SelectedItems[0];
            st.nomer = item.SubItems[0].Text;
            int k = 0;
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].nomer == st.nomer)
                {
                    k = i;
                    break;
                }
            }
            info.RemoveAt(k);
            listView1.Items.Clear();
            InfoAddList();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Все файлы (*.*)|*.*|Текстовые файлы (*.txt)|*.txt |PDF файлы (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251)))
                {
                    while (!sr.EndOfStream)
                    {
                        InfoList list = new InfoList();
                        list.nomer = sr.ReadLine();
                        list.type = sr.ReadLine();
                        list.punktNaz = sr.ReadLine();
                        list.dataOtpr = Convert.ToDateTime(sr.ReadLine());
                        list.timeOtpr = sr.ReadLine();
                        list.dataPrib = Convert.ToDateTime(sr.ReadLine());
                        list.timePrib = sr.ReadLine();
                        info.Add(list);
                    }
                }
                InfoAddList();
                comboBox1.Items.Add("");
                foreach (var item in info)
                {
                    if (!comboBox1.Items.Contains(item.punktNaz))
                        comboBox1.Items.Add(item.punktNaz);
                }
                addComboBox2();
                comboBox1.SelectionStart = 0;
                comboBox2.SelectionStart = 0;
            }
        }

        public void addComboBox2()
        {
            comboBox2.Items.Add("");
            int i = 0;
            string time = "";
            bool p = true;
            while (i != 24)
            {
                if (i == 0)
                {
                    time = "0" + $"{i}:00";
                    comboBox2.Items.Add(time);
                }
                if (i < 10 && p == true)
                {
                    time = "0" + $"{i}:30";
                    comboBox2.Items.Add(time);
                    p = false;
                }
                if (i < 10 && p == false)
                {
                    time = i == 9 ? $"{i + 1}:00" : "0" + $"{i + 1}:00";
                    comboBox2.Items.Add(time);
                    p = true;
                }
                if (i >= 10 && p == true)
                {
                    time = $"{i}:30";
                    comboBox2.Items.Add(time);
                    p = false;
                }
                if (i >= 10 && p == false)
                {
                    time = $"{i + 1}:00";
                    comboBox2.Items.Add(time);
                    p = true;
                }
                i++;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool search = true;
            List<InfoList> list = new List<InfoList>();
            foreach (var item in info)
            {
                if (item.punktNaz == comboBox1.SelectedItem.ToString()
                    && Convert.ToDouble(item.timePrib.Replace(':', ',')) < Convert.ToDouble(comboBox2.SelectedItem.ToString().Replace(':', ',')))
                {
                    list.Add(item);
                    search = true;
                }
                else
                    search = false;

            }
            if (list.Count == 0)
                MessageBox.Show("ПОДХОДЯЩИХ РЕЙСОВ НЕ НАЙДЕНО!!!\n\n" +
                                        "Попробуйте изменить условия поиска!!!");
            Form3 f3 = new Form3();
            f3.Text = "СПИСОК ОТСОРТИРОВАННЫХ РЕЙСОВ";
            f3.info = list;
            f3.ShowDialog();
        }
    }

    public class InfoList
    {
        public string nomer;
        public string type;
        public string punktNaz;
        public DateTime dataOtpr;
        public string timeOtpr;
        public DateTime dataPrib;
        public string timePrib;
    }

    class DateOtprComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return DateTime.Compare(x.dataOtpr, y.dataOtpr);
        }
    }

    class DatePribComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return DateTime.Compare(x.dataPrib, y.dataPrib);
        }
    }

    class PunktNazComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return x.punktNaz.CompareTo(y.punktNaz);
        }
    }

    class NomerComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return x.nomer.CompareTo(y.nomer);
        }
    }

    class TimeOtprComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return x.timeOtpr.CompareTo(y.timeOtpr);
        }
    }

    class TimePribComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return x.timePrib.CompareTo(y.timePrib);
        }
    }

    class TypeComparer : IComparer<InfoList>
    {
        public int Compare(InfoList x, InfoList y)
        {
            return x.type.CompareTo(y.type);
        }
    }

}
