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

           
          
        }
        public Dictionary<string, int> xx = new Dictionary<string, int>();
      
      /*  class table
        {
          
         
            public string name;
           public List<List<string>> columns;
         

           
            public table()
            {

                columns = new List<List<string>>();

            }
        };
       
        class database
        {
         
            
            public string name;

            List<table> Table;
            public database()
           {
             
              Table=new List<table>()
           }
        };
        */
      
                   
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             int y=0;
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].ReadOnly==true)
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
        

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Information f = new Information();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       
        private int a = 1;
        private void label1_Click(object sender, EventArgs e)
        {
            string filename = textBox2.Text;
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename + ".xml");
            XmlNodeList list = doc.GetElementsByTagName("table");
            try
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    xx.Add(list[i].Attributes[0].Value, 1);
                }
            }
            catch
            {
                MessageBox.Show("there is two or more than table has the same name");
            }


        }
         
            
        private void save_Click(object sender, EventArgs e)
        {
           
            
            XmlDocument doc = new XmlDocument();
           
           

        
            string filename = textBox2.Text;
            if (File.Exists("nameoftable.txt"))

            {
                FileStream file = new FileStream("nameoftable.txt", FileMode.Open);

            StreamReader  str=new StreamReader(file);
            try
            {
            
            xx.Add(str.ReadLine(),1);
            }
             catch
            {
                 MessageBox.Show("there is two table has the same name");
             }
            file.Close();
            str.Close();
            }



       












            a++;


            if (filename != "")
            {
                string id = a.ToString();
                string name = textBox1.Text;
                if (!File.Exists(filename + ".xml"))
                {


                    XmlWriter writer = XmlWriter.Create(filename + ".xml");
                    writer.WriteStartDocument();
                    writer.WriteStartElement("tables");
                    writer.WriteStartElement("table");

                    xx.Add(textBox1.Text, 1);
                    writer.WriteStartAttribute("name", textBox1.Text);
                    writer.WriteStartElement("id");
                    writer.WriteString(id);
                    writer.WriteEndElement();
                    writer.WriteStartElement("numberofclumns");
                    writer.WriteString(dataGridView1.Rows.Count.ToString());
                    writer.WriteEndElement();
                    try
                    {

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
                        }
                    }
                    catch
                    {
                        MessageBox.Show("there is value dosen have datatype or empty cell");
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();

                    dataGridView1.Rows.Clear();
                }

                else
                {
                    XmlElement table = doc.CreateElement("table");

                    try
                    {

                        xx.Add(textBox1.Text, 1);
                    }
                    catch
                    {
                        MessageBox.Show("please enter another name because exist the same name of cuurent table");
                    }
                   table.SetAttribute("name", textBox1.Text);
                         
                        
                     
                     
          
            
                   
                    XmlElement node = doc.CreateElement("id");

                    node.InnerText = id;
                    table.AppendChild(node);
                    node = doc.CreateElement("numberofclumns");
                    node.InnerText = dataGridView1.Rows.Count.ToString();
                    table.AppendChild(node);
                    try
                    {
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
                    }

                    catch
                    {
                        MessageBox.Show("there is value dosen have datatype or empty cell");
                    }


                    FileStream file2 = new FileStream("nameoftable.txt", FileMode.Append);

          StreamWriter str2=new StreamWriter(file2);
            dataGridView1.Rows.Clear();
          
            doc.Load(filename + ".xml");
            
            XmlNodeList list = doc.GetElementsByTagName("table");
            for (int i = 0; i < list.Count; ++i)
            {
                str2.WriteLine(list[i].Attributes[0].Value);

            }
            
            str2.Close();
            file2.Close();


            



                    doc.Load(filename + ".xml");
                    XmlElement root = doc.DocumentElement;
                    root.AppendChild(table);
                    doc.Save(filename + ".xml");



                }
                comboBox1.Items.Add(filename);




               
















                }
            else
                MessageBox.Show("please enter name of data base");


            
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
          



          string filename = textBox2.Text;
          FileStream file=new FileStream(filename+".xml",FileMode.OpenOrCreate);

          StreamWriter str=new StreamWriter(file);
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename + ".xml");
            
            XmlNodeList list = doc.GetElementsByTagName("table");
            for (int i = 0; i < list.Count; ++i)
            {
                str.WriteLine(list[i].Attributes[0].Value);

                listBox1.Items.Add(list[i].Attributes[0].Value);
            }
                
               

                
              
                
                
        

            }
            
        }

     
    }

