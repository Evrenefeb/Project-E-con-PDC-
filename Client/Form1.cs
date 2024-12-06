using Client.Networking.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    public partial class Form1 : Form {

        NetworkClient _networkClient;

        public Form1() {
            InitializeComponent();
            _networkClient = new NetworkClient();

        }

        private void btn_Connect_Click(object sender, EventArgs e) {
            // TODO : Implement Type Checking on tbx_AddressField
            _networkClient.ClientConnect(tbx_AddressField.Text.ToString());
        }

        private void btn_UnmuteFF_Click(object sender, EventArgs e) {
            bool isUnmuted = _networkClient.FlipFlopUnmute();
            if (isUnmuted) {
                btn_UnmuteFF.Text = "Mute";
            }
            else {
                btn_UnmuteFF.Text = "Unmute";
            }
        }
    }
}
