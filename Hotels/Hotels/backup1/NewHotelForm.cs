using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Hotels
{
    public partial class NewHotelForm : Form
    {
        public NewHotelForm()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            Hotel hotel = new Hotel();
            hotel.HotelName = textBoxName.Text;
            hotel.AmountRooms = (int)boxAmount.Value;
            hotel.Adress = textBoxAdress.Text;
            hotel.Phone = textBoxPhone.Text;

            int forArrays = hotel.AmountRooms + 1;

            hotel.Rooms = new Room[forArrays];

            for(int i = 1; i < forArrays; i++)
            {
                hotel.Rooms[i] = new Room();
                hotel.Rooms[i].Number = i;
                hotel.Rooms[i].Status = roomStatus.Free;
                hotel.Rooms[i].BookAprooved = false;
                //hotel.Rooms[i].BookDate = DateTime.Now;
            }
            curHotel.Hotel = hotel;
            this.Close();
        }
    }
}
