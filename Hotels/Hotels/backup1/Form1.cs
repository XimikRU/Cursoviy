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
using System.Threading;

namespace Hotels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        #region EVENTS
        // Метод-событие - создание нового отеля
        private void menuNewHotel_Click(object sender, EventArgs e)
        {
            // Создаем новую форму создания отеля, 
            // в той форме текущей отель == новый отель.
            NewHotelForm newHotelForm = new NewHotelForm();
            if ( newHotelForm.ShowDialog() == DialogResult.OK )
            {
                // Если форма вернула ОК заполняем инфу об отеле и создаем ячейки-кнопки.
                updateStatusOk("created");
                filInfo(curHotel.Hotel);
                filRooms(curHotel.Hotel);
                try
                {
                    // Пробуем сохранить отель.
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

        // Метод-событие - загрузка отеля.
        private void menuLoadHotel_Click(object sender, EventArgs e)
        {
            try
            {
                // Пробуем загрузить отель.
                curHotel.Hotel = deserializeHotel();
                if (curHotel.Hotel != null)
                { 
                    filInfo(curHotel.Hotel);
                    filRooms(curHotel.Hotel);
                    updateStatusOk("loaded");
                }
                else
                    updateStatusError("load");
            }
            catch (Exception ex)
            {
                updateStatusError("load");
            }
            
        }

        // Метод-событие - сохранение отеля.
        private void menuSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Пробуем сохранить отель.
                if(serializeHotel())
                    updateStatusOk("saved");
            }
            catch (Exception ex)
            {
                updateStatusError("save");
            }
        }

        
        // Обновление и сохранение.
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(curHotel.Hotel != null)
            {
                try {  
                    filRooms(curHotel.Hotel);
                    serializeHotel();
                }catch(Exception ex)
                {
                    updateStatusError(ex.ToString());
                }
            }
        }
        #endregion

        #region FUNCTIONS
        // Функция - обновление успешнго статуса.
        private void updateStatusOk(string s)
        {
            curHotel.Status = s;
            statusText.ForeColor = Color.Green;
            statusText.Text = curHotel.Status;
        }

        // Функция - обновление ошибочного статуса.
        private void updateStatusError(string s)
        {
            curHotel.Status = "Something went wrong. Cant " + s;
            statusText.ForeColor = Color.Red;
            statusText.Text = curHotel.Status;
        }

        // Функция - десериализация экземпляра класса Hotel из файла. (вернет Hotel)
        private Hotel deserializeHotel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return null;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                Hotel hotelDes = (Hotel)bf.Deserialize(fs);
                fs.Close();
                return hotelDes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // Сериализация экземпляра класса текущего Hotel в файл.
        private bool serializeHotel()
        {
            Hotel hotelSer = curHotel.Hotel;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream(hotelSer.HotelName + ".hotel", FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, hotelSer);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Заполнение информации об отеле в название формы.
        private void filInfo(Hotel h)
        {
            this.Text = h.HotelName;
            this.Text += " : " + h.AmountRooms.ToString() + " rooms";
            this.Text += " : " + h.Adress;
            this.Text += " : " + h.Phone;
        }

        // Функция создания ячеек отелей.
        private void filRooms(Hotel h)
        {
            // Запрещаем изменять что-то в табруме с пользоват. стороны
            tabRooms1.Enabled = false;

            // Удаление старых tabpage.
            foreach (TabPage tb in tabRooms1.TabPages)
                tb.Dispose();

            // Координаты старта отрисовки кнопок.
            int leftx = 9, topy = 35, tabindex = 1, i = 0;
            int ost = h.AmountRooms > 48 ? 48 : h.AmountRooms;
            int lst;

            // Создание и добавление нового табпейджа.
            TabPage curPage = new TabPage();
            curPage.Name = "tabPageRooms" + tabindex;
            curPage.Text = "1 - " + ost;
            tabRooms1.Controls.Add(curPage);

            // Динамическое создание ячеек отелей (кнопок)
            for (i = 1; i <= h.AmountRooms; i++)
            {
                // Если координаты новой кнопки выходят за предел высоты табпейджа, тогда перенос вправо.
                if (topy >= tabRooms1.Height - 90)
                {
                    topy = 35;
                    leftx += 80;
                }
                // Если координаты новой кнопки выходят за предел ширины табпейджа,
                if (leftx >= tabRooms1.Width - 50)
                {
                    // Тогда увеличение индекса табпейджа и создание новго табпейджа.
                    tabindex++;
                    leftx = 9;
                    TabPage tabpage = new TabPage();
                    tabpage.Name = "tabPageRooms" + tabindex;
                    lst = h.AmountRooms < i + 48 ? h.AmountRooms : i + 48;
                    tabpage.Text = i.ToString() + " - " + lst;

                    // Делаем новый табпейдж текущим.
                    curPage = tabpage;
                    tabRooms1.Controls.Add(curPage);
                }

                // Создание новой ячейки-кнопки отеля.
                Button button = new Button();
                button.Name = "room" + i.ToString();
                button.Left = leftx;
                button.Top = topy;
                button.Text = i.ToString();
                button.Width = 48;
                button.Height = 48;
                button.FlatStyle = FlatStyle.Flat;
                // Используем лямбда-выражение для создание события - по нажатию кнопки.
                button.Click += (sender, e) =>
                {
                    int curId = Int32.Parse(button.Text);
                    // В зависимости от статуса ячейки вызываем разные формы.
                    switch (h.Rooms[curId].Status)
                    {
                        // Еcли свободна.
                        case roomStatus.Free:
                            FormBooking fb = new FormBooking(curId);
                            if (fb.ShowDialog() == DialogResult.OK)
                            {
                                // Если диалог вернул ОК, тогда загружаем даты бронирования и меняем статус на "забронировано".
                                h.Rooms[curId].BookDateFrom = DateFT.from;
                                h.Rooms[curId].BookDateTo = DateFT.to;
                                h.Rooms[curId].Status = roomStatus.Booked;
                                updateColor(curId, button, h);
                                updateStatusOk("Room was booked!");
                            }
                            else
                            {
                                updateStatusError("book the room!");
                            }
                            break;

                        // Если забронирована.
                        case roomStatus.Booked:
                            FormConfirm fa = new FormConfirm();
                            if (fa.ShowDialog() == DialogResult.OK)
                            {
                                // Если диалог вернул ОК, тогда меняем статус на "занято".
                                h.Rooms[curId].Status = roomStatus.Busy;
                                h.Rooms[curId].BookAprooved = true;
                                updateColor(curId, button, h);
                                updateStatusOk("Room is busy now!");
                            }
                            if (fa.DialogResult == DialogResult.Abort)
                            {
                                // Если диалог вернул Сброс, тогда меняем статус на "свободно" - отмена брони.
                                h.Rooms[curId].Status = roomStatus.Free;
                                updateColor(curId, button, h);
                                updateStatusOk("Room is free now!");
                            }
                            break;

                        // Если занята. 
                        case roomStatus.Busy:
                            FormFreeing ff = new FormFreeing();
                            ff.ShowDialog();
                            if (ff.DialogResult == DialogResult.OK)
                            {
                                // Если диалог вернул ОК, тогда меняем статус на "свободно".
                                h.Rooms[curId].Status = roomStatus.Free;
                                h.Rooms[curId].BookAprooved = false;
                                updateColor(curId, button, h);
                                updateStatusOk("Room is free now!");
                            }
                            break;
                    }
                };

                roomStatus status = h.Rooms[i].Status;
                // Создание подписи о дате бронирования в виде лейбла.
                if (status == roomStatus.Booked || status == roomStatus.Busy)
                {
                    Label label = createLabel(i, h, leftx, topy);
                    curPage.Controls.Add(label);
                    tabRooms1.Update();
                }

                // Смена цвета ячейки.
                updateColor(i, button, h);
                // Смещение вниз.
                topy += 70;
                // Добавление ячейки.
                curPage.Controls.Add(button);
                // Обновление табрумс.
                tabRooms1.Update();

            }
            // После завершения цикла, разрешаем модификации табрумса.
            tabRooms1.Enabled = true;
        }

        // Фукнция обновления цвета ячейки.
        private void updateColor(int i, Button button, Hotel h)
        {
            switch (h.Rooms[i].Status)
            {
                case roomStatus.Free:
                    button.BackColor = Color.WhiteSmoke;
                    break;
                case roomStatus.Booked:
                    button.BackColor = Color.Aqua;
                    break;
                case roomStatus.Busy:
                    button.BackColor = Color.Yellow;
                    break;
            }
        }

        // Функция создания лейбла. (вернет обект типа Label)
        private Label createLabel(int i, Hotel h, int leftx, int topy)
        {
            Label label = new Label();
            Boolean snos = false;
            label.Name = "labelr" + i.ToString();
            // Форматирование (берем только день и месяц)
            label.Text = h.Rooms[i].BookDateFrom.Day.ToString() + "." +
                h.Rooms[i].BookDateFrom.Month.ToString() + " - ";
            label.Text += h.Rooms[i].BookDateTo.Day.ToString() + "." +
                h.Rooms[i].BookDateTo.Month.ToString();
            label.BorderStyle = BorderStyle.Fixed3D;
            label.AutoSize = true;

            // Если нужен 2ой сдвиг для больших дат вида xx.yy - xx.yy
            if ((int)h.Rooms[i].BookDateFrom.Month >= 10 && (int)h.Rooms[i].BookDateFrom.Day >= 10)
            {
                label.Left = leftx - 10;
                snos = true;
            }

            // Одинарный сдвиг для средних дат вида x.yy - x.yy
            if ((int)h.Rooms[i].BookDateFrom.Month >= 10 && (int)h.Rooms[i].BookDateFrom.Day < 10
                || (int)h.Rooms[i].BookDateFrom.Month < 10 && (int)h.Rooms[i].BookDateFrom.Day >= 10)
            {
                label.Left = leftx - 5;
                snos = true;
            }

            // Без сдвига.
            if (!snos)
                label.Left = leftx;

            label.Top = topy + 50;
            return label;
        }
#endregion
    }


    #region CURHOTEL
    // Текущий отель (класс) вне формы, доступен отовсех компонентов namespacа.
    static class curHotel
    {
        public static Hotel Hotel { get; set; }
        public static string Status { get; set; }
        public static Room[] Rooms { get; set; }
    }
    #endregion
}
