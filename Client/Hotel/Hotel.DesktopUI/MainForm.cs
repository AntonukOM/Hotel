using System;
using System.Windows.Forms;
using Hotel.Service.DTOs;

namespace Hotel.DesktopUI
{
    public partial class MainForm : Form
    {
        private HotelServiceClient _service = new HotelServiceClient();

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cbxHotel.DataSource = _service.GetHotels();
            SetRoom(_service);
            lbxClients.DataSource = _service.GetClients();
        }
        private void cbxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRoom(_service);
        }
        private void SetRoom(HotelServiceClient service)
        {
            string hotelName = cbxHotel.SelectedValue.ToString();
            int hotelId = service.GetHotelId(hotelName);
            cbxRoom.DataSource = service.GetRooms(hotelId);
            lblClientInfo.Text = hotelId.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            var client = new ClientDTO
            {
                FirstName = tbxFirstName.Text,
                LastName = tbxLastName.Text,
                Email = tbxEmail.Text,
                Phone = tbxPhone.Text
            };
            _service.InsertClient(client);
            int clientId = _service.GetClientId(client.Email);
            int hotelId = _service.GetHotelId(cbxHotel.SelectedValue.ToString());
            MessageBox.Show(hotelId.ToString());
            string roomName = cbxRoom.SelectedValue.ToString();
            bool approved = cbxStatus.Checked;
            var room = new RoomDTO
            {
                ClientId = clientId,
                HotelId = hotelId,
                Name = roomName,
                Approved = approved
            };
            _service.InsertRoom(room);
            lbxClients.DataSource = _service.GetClients();
            ResetInfo();
        }

        private void ResetInfo()
        {
            tbxFirstName.Text = null;
            tbxLastName.Text = null;
            tbxEmail.Text = null;
            tbxPhone.Text = null;
            cbxStatus.Checked = false;
        }
    }
}
