using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agency
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Создание новой базы
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int amount;
            if(Int32.TryParse(toolStripAmount.Text, out amount))
            { 
                string name = toolStripNewName.Text;
                if ( name != "" && amount > 0 && amount < 1000 )
                { 
                    CurBase.Base = new Base(name, amount);
                    loadTable();
                    success("New base created");
                }
                else
                {
                    error("Cant create new base");
                }
            }
            else
            {
                error("Cant create new base");
            }
        }

        // Если прошло все без ошибок
        public void success(string s)
        {
            toolStripStatusLabel1.Text = s;
            toolStripStatusLabel1.ForeColor = Color.Green;
        }

        // Если прошло с ошибкой
        public void error(string s)
        {
            toolStripStatusLabel1.Text = s;
            toolStripStatusLabel1.ForeColor = Color.Red;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int index;
            index = CurBase.Base.LastIndex;
            Client nC = new Client();
            nC.ID = index;
            nC.Name = textBoxName.Text;
            nC.Age = (int)numericAge.Value;
            nC.Growth = (int)numericGrowth.Value;
            nC.Weight = (int)numericWieght.Value;
            nC.Contact = textBoxContact.Text;
            nC.Info = textBoxInfo.Text;
            #region if (Male)
            if (radioMale.Checked)
                nC.Sex = Sex.Male;
            else if (radioFemale.Checked)
                nC.Sex = Sex.Female;
            else
                nC.Sex = Sex.Unkn;
            #endregion

            if (index < CurBase.Base.AmountClients)
            { 
                CurBase.Base.Clients[index] = nC;
                CurBase.Base.LastIndex++;
                loadTable();
                success("New client added and indexed");
            }
            else
                error("No empty slots for new clients / wrong indexing");

            
        }

        private void loadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadFound(int id)
        {    
                Client cl = new Client();
                cl = CurBase.Base.Clients[id];
                ListViewItem newItem = listView1.Items.Add(cl.ID.ToString());
                newItem.SubItems.Add(cl.Name);
                newItem.SubItems.Add(cl.Sex.ToString());
                newItem.SubItems.Add(cl.Age.ToString());
                newItem.SubItems.Add(cl.Growth.ToString());
                newItem.SubItems.Add(cl.Weight.ToString());
                newItem.SubItems.Add(cl.Contact);
                listView1.Update();  
        }

        private void loadTable()
        {
            try { 
            listView1.Items.Clear();
            int amount = CurBase.Base.AmountClients;
            int lastIndex = CurBase.Base.LastIndex;
            int i = 1;
            for (i = 1; i < lastIndex; i++)
            {
                Client cl = new Client();
                cl = CurBase.Base.Clients[i];
                ListViewItem newItem = listView1.Items.Add(cl.ID.ToString());
                newItem.SubItems.Add(cl.Name);
                newItem.SubItems.Add(cl.Sex.ToString());
                newItem.SubItems.Add(cl.Age.ToString());
                newItem.SubItems.Add(cl.Growth.ToString());
                newItem.SubItems.Add(cl.Weight.ToString());
                newItem.SubItems.Add(cl.Contact);
            }
            }
            catch (Exception ex)
            {
                error(ex.ToString());
            }
        }

        /*
        private void indexing()
        {
            try { 
            int amount = CurBase.Base.AmountClients;
            int lastIndex = CurBase.Base.LastIndex;
            int i, lastMaleIndex = 0, lastFemaleIndex = 0;
            for (i = 1; i < lastIndex; i++)
            {
                if(CurBase.Base.Clients[i].Sex == Sex.Female)
                {
                    CurBase.Base.IndexFemale[lastFemaleIndex] = i;
                    lastFemaleIndex++;
                }
                if(CurBase.Base.Clients[i].Sex == Sex.Male)
                {
                    CurBase.Base.IndexFemale[lastMaleIndex] = i;
                    lastMaleIndex++;
                }
            }
            }catch (Exception ex)
            {
                error(ex.ToString());
            }
        }
        */

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Base newBase = CurBase.Base;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream(newBase.Name + ".agn", FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, newBase);
                fs.Close();
                success("Saved!");
            }
            catch (Exception ex)
            {
                error("Cant save base!");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                Base loadBase = (Base)bf.Deserialize(fs);
                fs.Close();
                CurBase.Base = loadBase;
                loadTable();
                success("Loaded");
            }
            catch (Exception ex)
            {
                error("Cant load base!");
            }
        }

        private void buttonFindFemale_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string name = textBoxFindName.Text;
            int age = (int)numericFindAge.Value;
            int growth = (int)numericFindGrowth.Value;
            int weight = (int)numericFindWeight.Value;
            for (int index = 1; index < CurBase.Base.LastIndex; index++)
            {
                    if (CurBase.Base.Clients[index].Sex == Sex.Female)
                {  
                    Client c = CurBase.Base.Clients[index];

                    if (c.Name.Equals(name))
                    {
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Age == age)
                    { 
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Growth == growth)
                    {
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Weight == weight)
                    {
                        loadFound(c.ID);
                        continue;
                    }
                }
            }
        }

        private void buttonFindMale_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string name = textBoxFindName.Text;
            int age = (int)numericFindAge.Value;
            int growth = (int)numericFindGrowth.Value;
            int weight = (int)numericFindWeight.Value;
            for (int index = 1; index < CurBase.Base.LastIndex; index++)
            {
                if (CurBase.Base.Clients[index].Sex == Sex.Male)
                {
                    Client c = CurBase.Base.Clients[index];

                    if (c.Name.Equals(name))
                    {
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Age == age)
                    {
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Growth == growth)
                    {
                        loadFound(c.ID);
                        continue;
                    }

                    if (c.Weight == weight)
                    {
                        loadFound(c.ID);
                        continue;
                    }
                }
            }
        }
    }

    static class CurBase
    {
        public static Base Base { get; set; }
    }
}
