using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace WindowsFormsApplication12
{
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
            for (int i = 0; i < Form1.ssi.Count; ++i)
                comboBox1.Items.Add(Form1.ssi[i]);

            
                
  


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private List<string> temp=new List<string>();
        private string seleceddata = "";
         private List<string> temp2 = new List<string>();
        private List<string> temp3 = new List<string>();
        private List<string> temp1 = new List<string>();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleceddata = comboBox1.SelectedItem.ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load(seleceddata + ".xml");
            XmlNodeList list = doc.GetElementsByTagName("table");
            FileStream relation = new FileStream("re.txt", FileMode.Append);
            StreamWriter str = new StreamWriter(relation);
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




                    l = list[i].ChildNodes;
                    for (int j = 0; j < (int.Parse(l[1].InnerText)); ++j)
                    {
                        if (list[i].Attributes[1].Value != "")
                        {
                            temp.Add(list[i].Attributes[1].Value);
                            str.WriteLine(list[i].Attributes[1].Value);
                        }

                        if (list[i].Attributes[0].Value != "")
                        {
                            temp.Add(list[i].Attributes[0].Value);
                            str.WriteLine(list[i].Attributes[0].Value);

                        }
                        temp1.Add(l[p].InnerText);
                        str.WriteLine(l[p].InnerText);
                        temp2.Add(l[k].InnerText);
                        str.WriteLine(l[k].InnerText);
                        temp3.Add(l[o].InnerText);
                        str.WriteLine(l[o].InnerText);




                        p = p + 4;
                        k = k + 4;
                        o = o + 4;
                    }
                    p = 0;
                    k = 0;
                    o = 0;
                   

                }



                catch
                {
                }

            }
            relation.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
