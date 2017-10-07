using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public partial class FormBooking : Form
    {
        public FormBooking(int curId)
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DateFT.from = dateTimePickerFrom.Value;
            DateFT.to = dateTimePickerTo.Value;
            this.Close();
        }
    }

    static public class DateFT
    {
        public static DateTime from { get; set; }
        public static DateTime to { get; set; }
    }
}
