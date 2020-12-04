using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            if (File.Exists("nameoftable.txt"))
            {
                FileStream file = new FileStream("nameoftable.txt", FileMode.Open);

                StreamReader str = new StreamReader(file);
                try
                {
                    while (str.Peek() != -1)
                    {
                        string line = str.ReadLine();
                        if (line != "")
                            xx.Add(line, 1);
                    }
                }
                catch
                {
                    MessageBox.Show("there is two table has the same name");

                }
                file.Close();
                str.Close();
            }
            if (File.Exists("databasename.txt"))
            {
                FileStream file = new FileStream("databasename.txt", FileMode.Open);

                StreamReader str = new StreamReader(file);
                try
                {
                    while (str.Peek() != -1)
                    {
                        string line = str.ReadLine();
                        if (line != "")
                            comboBox1.Items.Add(line);
                    }
                }
                catch
                {
                    MessageBox.Show("there is two table has the same name");

                }
                file.Close();
                str.Close();
            }
            List<object> list = new List<object>();

            foreach (object obj in comboBox1.Items)
            {
                if (!list.Contains(obj))
                
                    list.Add(obj);
                    
                
            }
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(list.ToArray());


            ssi = list;
        





        }
        public Dictionary<string, int> xx = new Dictionary<string, int>();
        public static string passvalue = "";

        public static string mll = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int y = 0;
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].ReadOnly == true)
                    {
                        ++y;
                    }
                }



                if (y == 0)
                {
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Purple;

                    dataGridView1.CurrentRow.ReadOnly = true;
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Column3"].Value = false;
                }
                else
                    MessageBox.Show("Not Allowed");
            }





            else
            {

                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.White;

                dataGridView1.CurrentRow.ReadOnly = false;
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Column3"].Value = true;


            }


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }




        public static string passvluel = "";
        private int i = 0;
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {



        }


        private void button2_Click(object sender, EventArgs e)
        {

        }


        private int a = 1;
        private void label1_Click(object sender, EventArgs e)
        {




        }

        public static List<object> ssi;
        private void save_Click(object sender, EventArgs e)
        {


            XmlDocument doc = new XmlDocument();




            string filename = textBox2.Text;

















            a++;


            if (filename != "" && textBox1.Text != "")
            {

                string id = a.ToString();
                string name = textBox1.Text;
                if (!File.Exists(filename + ".xml"))
                {

                    try
                    {

                        xx.Add(textBox1.Text, 1);
                        XmlWriter writer = XmlWriter.Create(filename + ".xml");
                        writer.WriteStartDocument();
                        writer.WriteStartElement("tables");
                        writer.WriteStartElement("table");




                        writer.WriteStartAttribute("name", textBox1.Text);
                        writer.WriteStartElement("id");
                        writer.WriteString(id);
                        writer.WriteEndElement();
                        writer.WriteStartElement("numberofclumns");
                        int x = dataGridView1.Rows.Count - 1;

                        writer.WriteString(x.ToString());
                        writer.WriteEndElement();


                        for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
                        {

                            if (dataGridView1.Rows[i].ReadOnly == true && dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.Purple)
                            {
                                writer.WriteString(i.ToString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("name");
                                writer.WriteString(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("datatybe");
                                writer.WriteString(dataGridView1.Rows[i].Cells[1].Value.ToString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("allownull");
                                writer.WriteString("primarykey");
                                writer.WriteEndElement();

                            }
                            writer.WriteStartElement("details");


                            writer.WriteString(i.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("name");
                            writer.WriteString(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("datatybe");
                            writer.WriteString(dataGridView1.Rows[i].Cells[1].Value.ToString());
                            writer.WriteEndElement();
                            writer.WriteStartElement("allownull");
                            writer.WriteString(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();

                            dataGridView1.Rows.Clear();
                            FileStream file = new FileStream("nameoftable.txt", FileMode.Append);
                            StreamWriter str = new StreamWriter(file);
                            str.WriteLine(textBox1.Text);
                            FileStream file3 = new FileStream("databasename.txt", FileMode.Append);
                            StreamWriter sr = new StreamWriter(file3);
                            sr.WriteLine(filename);
                            sr.Close();
                            file3.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("error");
                    }

                }

                else
                {
                    try
                    {
                        XmlElement table = doc.CreateElement("table");


                        xx.Add(textBox1.Text, 1);
                        table.SetAttribute("name", textBox1.Text);







                        XmlElement node = doc.CreateElement("id");

                        node.InnerText = id;
                        table.AppendChild(node);
                        node = doc.CreateElement("numberofclumns");
                        int x = dataGridView1.Rows.Count - 1;
                        node.InnerText = x.ToString();
                        table.AppendChild(node);

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
                        {
                            if (dataGridView1.Rows[i].ReadOnly == true && dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.Purple)
                            {
                                node = doc.CreateElement("details");
                                node.InnerText = i.ToString();
                                table.AppendChild(node);
                                node = doc.CreateElement("name");
                                node.InnerText = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                table.AppendChild(node);
                                node = doc.CreateElement("datatype");
                                node.InnerText = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                table.AppendChild(node);
                                node = doc.CreateElement("allownull");
                                node.InnerText = "primarykey";
                                table.AppendChild(node);
                            }
                            node = doc.CreateElement("details");
                            node.InnerText = i.ToString();
                            table.AppendChild(node);
                            node = doc.CreateElement("name");
                            node.InnerText = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            table.AppendChild(node);
                            node = doc.CreateElement("datatype");
                            node.InnerText = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            table.AppendChild(node);
                            node = doc.CreateElement("allownull");
                            node.InnerText = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            table.AppendChild(node);
                        }

                        dataGridView1.Rows.Clear();









                        doc.Load(filename + ".xml");
                        XmlElement root = doc.DocumentElement;
                        root.AppendChild(table);
                        doc.Save(filename + ".xml");

                        comboBox1.Items.Add(filename);
                        FileStream file3 = new FileStream("databasename.txt", FileMode.Append);
                        StreamWriter sr = new StreamWriter(file3);
                        sr.WriteLine(filename);
                        sr.Close();
                        file3.Close();

                        FileStream file2 = new FileStream("nameoftable.txt", FileMode.Append);

                        StreamWriter str2 = new StreamWriter(file2);
                        dataGridView1.Rows.Clear();
                        str2.WriteLine(textBox1.Text);

                        str2.Close();
                        file2.Close();

                    }
                    catch
                    {
                        MessageBox.Show("error");
                    }
                }
























            }

            else
                MessageBox.Show("please enter name of data base an name of table");



        }
        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                if (dataGridView1.CurrentRow.ReadOnly == true && dataGridView1.CurrentRow.DefaultCellStyle.BackColor == Color.Purple)
                {

                    continue;
                }
                dataGridView1.Rows[i].Cells["Column3"].Value = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {














        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string filename = comboBox1.SelectedItem.ToString();


            XmlDocument doc = new XmlDocument();
            doc.Load(filename + ".xml");
            int j = 0;
            XmlNodeList list = doc.GetElementsByTagName("table");
            for (int i = 0; i < list.Count; ++i)
            {
                if (j == 0)

                    Tables.Items.Add(list[i].Attributes[1].Value);

                else
                    Tables.Items.Add(list[i].Attributes[0].Value);
                ++j;

            }





        }

        private void Tables_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Tables_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                i = 0;
                ++i;

                passvluel = Tables.SelectedItem.ToString();
              
                passvalue = comboBox1.SelectedItem.ToString();
                if (i == 1)
                {
                    Information f = new Information();
                    f.Show();

                }
            }
            catch
            {
                MessageBox.Show("Please select any item from comboBox");
            }


        }

        private void Tables_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Tables_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)



                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            }
            catch
            {
            }

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
           

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            Tables form = new Tables();
            form.Show();
        }

    }
    }

