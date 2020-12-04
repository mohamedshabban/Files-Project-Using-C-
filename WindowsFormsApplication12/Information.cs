using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication12
{
    public partial class Information : Form
    {
        public Information()

        {
            InitializeComponent();
          






            label1.Text = Form1.passvluel;

           seleceddata = Form1.passvalue;

           selectedtable = Form1.passvluel;
            XmlDocument doc = new XmlDocument();
            doc.Load(seleceddata + ".xml");
            XmlNodeList list = doc.GetElementsByTagName("table");
            List<int> liop = new List<int>();
            int p, k, o;
            p = 3;
            k = 4;
            o = 5;

                         for (int i = 0; i < list.Count; ++i)
            {

                XmlNodeList l;
                try
                {



                    if (list[i].Attributes[0].Value == selectedtable)
                    {
                        l = list[i].ChildNodes;
                        for (int j = 0; j < (int.Parse(l[1].InnerText)); ++j)
                        {

                            temp1.Add(l[p].InnerText);
                            temp2.Add(l[k].InnerText);
                            temp3.Add(l[o].InnerText);
                            dataGridView1.Columns.Add("name", l[p].InnerText);
                            dataGridView1.Columns.Add("name", l[k].InnerText);
                            dataGridView1.Columns.Add("name", l[o].InnerText);



                            p = p + 4;
                            k = k + 4;
                            o = o + 4;
                        }
                        p = 0;
                        k = 0;
                        o = 0;

                    }
                    else
                    {
                        int y = 0;                       
                        if (list[i].Attributes[1].Value ==selectedtable    )                   {
                            l = list[i].ChildNodes;
                            for (int j = 0; j < (int.Parse(l[1].InnerText)); ++j)
                            {
                                

                                
                                temp1.Add(l[p].InnerText);
                                temp2.Add(l[k].InnerText);
                                temp3.Add(l[o].InnerText);

                                dataGridView1.Columns.Add("name", l[p].InnerText);


                                p = p + 4;
                                k = k + 4;
                                o = o + 4;
                            }
                            p = 0;
                            k = 0;
                            o = 0;
                            
                        }

                    }
                }
                catch
                {
                }

                





              

                


                   
            }
        




        }
        private string selectedtable = "";
        private string seleceddata = "";
        private List<string> temp2 = new List<string>();
        private List<string> temp3 = new List<string>();
        private List<string> temp1 = new List<string>();
    
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
           [XmlRoot(ElementName = "information")]
    public    class information
        {
               public string n;
               public string id;
            public List<string> info;
            public information()
            {
                info = new List<string>();
            }
        }
      
     

        private void button1_Click(object sender, EventArgs e)
        {
            information inf = new information();
         
           
         
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                      inf.info.Add(cell.Value.ToString());
                    }
                    catch
                    {
                        
                    }
                   
                }
                inf.info.Add("new row");
            }

            inf.info.RemoveAt(inf.info.Count - 1);

               bool append=false;


            TextWriter writer = null;
            
            
               
            try
            {
                var serializer = new XmlSerializer(typeof(information));
                writer = new StreamWriter(selectedtable + "1.xml", append);

                serializer.Serialize(writer, inf);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            dataGridView1.Rows.Clear();
         }




        private int l = 0;
        private char ll = 'A';


        private void button2_Click(object sender, EventArgs e)
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
      
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int j = 0;
            int g = 0;
            if (ou == 0)
            {
                for (int i = 0; i < temp1.Count; ++i, ++j, ++g)
                {
                    if (temp2[i] == "int ")
                    {
                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            try
                            {
                                int ppo = Convert.ToInt32(dataGridView1.Rows[k].Cells[i].Value);
                            }


                            catch
                            {
                                if (g == 1)
                                    MessageBox.Show("please enter integer value");

                                dataGridView1.Rows[k].Cells[i].Value = " ";

                            }
                        }
                    }
                    else if (temp2[i] == "double " || temp2[i] == "float ")
                    {

                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            try
                            {
                                double ppo = Convert.ToDouble(dataGridView1.Rows[k].Cells[i].Value.ToString());

                            }


                            catch
                            {
                                if (g == 1)
                                    MessageBox.Show("please enter double value");

                                dataGridView1.Rows[k].Cells[i].Value = " ";

                            }
                        }
                    }
                    else if (temp2[i] == "char ")
                    {
                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            try
                            {
                                char ppo = Convert.ToChar(dataGridView1.Rows[k].Cells[i].Value);
                            }


                            catch
                            {
                                if (g == 1)
                                    MessageBox.Show("please en");


                                dataGridView1.Rows[k].Cells[i].Value = " ";

                            }
                        }

                    }













                    else if (temp3[i] == "True")
                    {

                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            try
                            {
                                if (dataGridView1.Rows[k].Cells[i].Value.ToString() == "")
                                {
                                }
                            }


                            catch
                            {
                                if (dataGridView1.Rows[k].Cells[i].Value == null)
                                    dataGridView1.Rows[k].Cells[i].Value = " ";
                            }
                        }
                    }

                    else if (temp3[i] == "False")
                    {
                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            try
                            {
                                if (dataGridView1.Rows[k].Cells[i].Value.ToString() == "")
                                {
                                }
                            }
                            catch
                            {

                                MessageBox.Show("not allow null", temp1[i]);
                                dataGridView1.Rows[k].Cells[i].Value = "*****";
                            }
                        }
                    }
                    if (temp3[i] == "primarykey")
                    {


                        for (int k = 0; k < dataGridView1.Rows.Count - 1; ++k)
                        {
                            if (dataGridView1.Rows[k].Cells[i].Value == null)
                            {
                                if (temp2[i] == "double " || temp2[i] == "int " || temp2[i] == "float ")
                                {
                                    dataGridView1.Rows[k].Cells[i].ReadOnly = true;

                                    dataGridView1.Rows[k].Cells[i].Value = l.ToString();
                                    ++l;
                                }
                                if (temp2[i] == "char " || temp2[i] == "string ")
                                {
                                    dataGridView1.Rows[k].Cells[i].ReadOnly = true;

                                    dataGridView1.Rows[k].Cells[i].Value = ll.ToString();
                                    ++ll;
                                }


                            }
                        }
                    }




                }
            }
            else
            { }
        }
      
        private int ou = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            information inf=new information();
            XmlSerializer xs=new XmlSerializer(inf.GetType());
            
            FileStream fs=new FileStream(selectedtable + "1.xml",FileMode.Open);
            inf=(information)xs.Deserialize(fs);
            fs.Close();
            int x,y;
            x=y=0;
            dataGridView1.Rows.Add();
            for (int i = 0; i < inf.info.Count; ++i)
            {
                if (inf.info[i] == "new row")
                {
                    if(i!=inf.info.Count)
                    dataGridView1.Rows.Add();
                    ++y;
                    x = 0;
                    continue;
                }
                dataGridView1.Rows[y].Cells[x].Value=inf.info[i];
              
                x++;
            }


                 
            




       

                

        }
    }
}
