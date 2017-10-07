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
            // Обнуляем текущую базу.
            CurBase.Base = null;
        }

        // Создание новой базы
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int amount;
            if(Int32.TryParse(toolStripAmount.Text, out amount))
            { 
                string name = toolStripNewName.Text;
                // Если кол-во клиентов в допустимом диапозоне и имя не пустое, тогда создаем.
                if ( name != "" && amount > 0 && amount < 1000 )
                { 
                    // Конструктор базы
                    CurBase.Base = new Base(name, amount);
                    // Загружаем таблицу
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

        // По нажатию на кнопку add
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int index;
            // Запоминаем последний индекс в базе
            index = CurBase.Base.LastIndex;
            // Создаем нового клиента
            Client nC = new Client();
            // Присваиваем ему id
            nC.ID = index;
            nC.Name = textBoxName.Text;
            if(nC.Name == "" || nC.Name == " ")
            {
                error("Empty name");
                return;
            } 
            // Проверка на наличие клиента с таким же именем в базе
            foreach(string s in CurBase.Base.UsedNames)
            {
                if (s == nC.Name)
                {
                    error("Same client!");
                    return;
                }
            }
            // Считывание информации из полей в клиента.
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

            // Если индекс не больше макс. кол-ва клиентов тогда продолжаем
            if (index < CurBase.Base.AmountClients)
            { 
                // Добавляем в текущую базу нового клиента
                CurBase.Base.Clients[index] = nC;
                // Имя добавляем в уже использованое
                CurBase.Base.UsedNames[index] = nC.Name;
                // Увеличиваем новый индекс на 1
                CurBase.Base.LastIndex++;
                loadTable();
                success("New client added and indexed");
            }
            else
                error("No empty slots for new clients / wrong indexing");
        }

        // По нажатию обновляем таблицу
        private void loadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        // Построчной добавление найденого по поису клиента
        private void loadFound(int id)
        {    
            Client cl = new Client();
            cl = CurBase.Base.Clients[id];
            // Добавляем в таблицу   
            ListViewItem newItem = listView1.Items.Add(cl.ID.ToString());
            newItem.SubItems.Add(cl.Name);
            newItem.SubItems.Add(cl.Sex.ToString());
            newItem.SubItems.Add(cl.Age.ToString());
            newItem.SubItems.Add(cl.Growth.ToString());
            newItem.SubItems.Add(cl.Weight.ToString());
            newItem.SubItems.Add(cl.Contact);
            listView1.Update();  
        }

        // Загрузка таблицы (обновление)
        private void loadTable()
        {
            try { 
            listView1.Items.Clear();
            int amount = CurBase.Base.AmountClients;
            int lastIndex = CurBase.Base.LastIndex;
            int i = 1;
            // Построчно доавляем из базы клиентов
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

        // Сохранение базы в файл (сериализация)
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        // Сохранение базы в файл (сериализация)
        private void saveToFile()
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

        // Загрузка файла (десериализация)
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Показываем окно выбора файла
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
                try
                {
                    // Заново индексируем имена использованные
                    indexingNames();
                    success("Loaded and indexed");
                }
                catch (Exception ex)
                {
                    error("Cant index base on loading");
                }

            }
            catch (Exception ex)
            {
                error("Cant load base!");
            }
        }

        // Поиск female
        private void buttonFindFemale_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            // Считываем из полей
            string name = textBoxFindName.Text;
            int age = (int)numericFindAge.Value;
            int growth = (int)numericFindGrowth.Value;
            int weight = (int)numericFindWeight.Value;
            // Проходим по всей базе
            for (int index = 1; index < CurBase.Base.LastIndex; index++)
            {
                // если пол = женский
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

        // Поиск male
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

        // Обновление таблицы
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        // Возврат дефолтных значений полей 
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxContact.Text = "";
            numericAge.Value = 0;
            numericGrowth.Value = 0;
            numericWieght.Value = 0;
            textBoxInfo.Text = "";
            radioFemale.Checked = false;
            radioMale.Checked = false;
        }

        // На закрытие окна , предлогаем сохранить базу если она есть
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormSaving fs = new FormSaving();
            if (CurBase.Base != null)
                if(fs.ShowDialog() == DialogResult.OK)
                    saveToFile();
        }

        // Возврат дефолтных значений полей 
        private void buttonFindClear_Click(object sender, EventArgs e)
        {
            textBoxFindName.Text = "";
            numericFindAge.Value = 0;
            numericFindGrowth.Value = 0;
            numericFindWeight.Value = 0;
        }

        // Индексирование использованных имен
        private void indexingNames()
        {
            for(int i = 1; i < CurBase.Base.LastIndex; i++)
            {
                CurBase.Base.UsedNames[i] = CurBase.Base.Clients[i].Name;
            }
        }

        private void toolStripSplitButtonRefresh_ButtonClick(object sender, EventArgs e)
        {
            success("");
        }
    }

    // Текущая база
    static class CurBase
    {
        public static Base Base { get; set; }
    }
}
