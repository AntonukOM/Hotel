using System;
using System.Linq;
using System.Windows.Forms;

namespace Hotel.DesktopUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var service = new HotelServiceClient();
            cbxHotel.DataSource = service.GetHotels();
            cbxHotel.SelectedItem = service.GetHotels().FirstOrDefault();
        }
    }
}
