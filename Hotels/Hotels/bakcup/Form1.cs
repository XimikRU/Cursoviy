using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hotels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }
    
        // Создание
        private void menuNewHotel_Click(object sender, EventArgs e)
        {
            NewHotelForm newHotelForm = new NewHotelForm();
            if ( newHotelForm.ShowDialog() == DialogResult.OK )
            {
                updateStatusOk("created");
                filInfo(curHotel.Hotel);
                filRooms(curHotel.Hotel);
                try
                {
                    serializeHotel();
                    updateStatusOk("saved");
                }
                catch (Exception ex)
                {
                    updateStatusError("save");
                }
            }
            else
            {
                updateStatusError("create");
            }
        }

        // Загрузка 
        private void menuLoadHotel_Click(object sender, EventArgs e)
        {
            try
            {
                curHotel.Hotel = deserializeHotel();
                filInfo(curHotel.Hotel);
                filRooms(curHotel.Hotel);
                updateStatusOk("loaded");
            }
            catch (Exception ex)
            {
                updateStatusError("load");
            }
        }

        // Сохранение
        private void menuSave_Click(object sender, EventArgs e)
        {
            try
            {
                serializeHotel();
                updateStatusOk("saved");
            }
            catch (Exception ex)
            {
                updateStatusError("save");
            }
        }

        // Обновление статуса "ОК"
        private void updateStatusOk(string s)
        {
            curHotel.Status = "Hotel " + curHotel.Hotel.HotelName + " " + s + ".";
            statusText.ForeColor = Color.Green;
            statusText.Text = curHotel.Status;
        }

        // Обновление статуса "ошибка"
        private void updateStatusError(string s)
        {
            curHotel.Status = "Something went wrong. Cant " + s + " hotel!";
            statusText.ForeColor = Color.Red;
            statusText.Text = curHotel.Status;
        }

        // Десериализация
        private Hotel deserializeHotel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            Hotel hotelDes = (Hotel)bf.Deserialize(fs);
            fs.Close();

            return hotelDes;
        }

        // Сериализация
        private bool serializeHotel()
        {
            Hotel hotelSer = curHotel.Hotel;

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(hotelSer.HotelName + ".hotel", FileMode.Create, FileAccess.Write);
            formatter.Serialize(fs, hotelSer);
            fs.Close();

            return true;
        }

        // Заполнение инфы об отеле
        private void filInfo(Hotel h)
        {
            this.Text = h.HotelName;
            this.Text += ":" + h.AmountRooms.ToString();
            this.Text += ":" + h.Adress;
            this.Text += ":" + h.Phone;
        }

        // Заполнение ячеек отелей
        private void filRooms(Hotel h)
        {
            
            // Удаление старых tabpage
            foreach(TabPage tb in tabRooms1.TabPages)
                tb.Dispose();

            int leftx = 9, topy = 35, tabindex = 1, i = 0;
            int ost = h.AmountRooms > 48 ? 48 : h.AmountRooms;
            int lst;

            // Создание нового табпейджа
            TabPage curPage = new TabPage();
            curPage.Name = "tabPageRooms" + tabindex;
            curPage.Text = "1 - " + ost;
            tabRooms1.Controls.Add(curPage);

            // Динамическое создание ячеек отелей (кнопок)
            for (i = 1; i <= h.AmountRooms; i++)
            {
                if ( topy >= 391 ) 
                {
                    topy = 35;
                    leftx += 50;
                }
                if ( leftx >= 371 )
                {
                    tabindex++;
                    leftx = 9;
                    TabPage tabpage = new TabPage();
                    tabpage.Name = "tabPageRooms" + tabindex;
                    lst = h.AmountRooms < i + 48 ? h.AmountRooms : i + 48;
                    tabpage.Text = i.ToString() + " - " + lst;
                    curPage = tabpage;
                    tabRooms1.Controls.Add(curPage);         
                } 
                Button button = new Button();
                button.Name = "room" + i.ToString();
                button.Left = leftx;
                button.Top = topy;
                button.Text = i.ToString();
                button.Width = 48;
                button.Height = 48;
                button.FlatStyle = FlatStyle.Flat;
                button.Click += (sender, e) => 
                {
                    int curId = Int32.Parse(button.Text);
                    
                    if (h.Rooms[curId].Status == roomStatus.Busy)
                    { 
                        h.Rooms[curId].Status -= 2;
                    }
                    else
                    { 
                        h.Rooms[curId].Status += 1;
                    }

                    updateColor(curId, button, h);
                };

                Label label = new Label();
                label.Name = "labelr" + i.ToString();
                label.Text = h.Rooms[i].BookDate.ToString();
                
                // Смена цвета 
                updateColor(i, button, h);
                topy += 50;

                label.Left = leftx;
                label.Top = topy;
                curPage.Controls.Add(label);

                topy += 10;
                curPage.Controls.Add(button);
            }
        }

        // Обновление цвета ячейки
        private void updateColor(int i, Button button, Hotel h)
        {
            switch (h.Rooms[i].Status) 
            {
                case roomStatus.Free:
                    button.BackColor = Color.WhiteSmoke;
                    break;
                case roomStatus.Reserved:
                    button.BackColor = Color.Aqua;
                    break;
                case roomStatus.Busy:
                    button.BackColor = Color.Yellow;
                    break;
            }
        }
    }

    // Текущий отель
    static class curHotel
    {
        public static Hotel Hotel { get; set; }
        public static string Status { get; set; }
        public static Room[] Rooms { get; set; }
    }

}
