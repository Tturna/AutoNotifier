using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoNotifier
{
    public partial class AddEventForm : Form
    {
        public MainForm mainForm;

        public AddEventForm()
        {
            InitializeComponent();
        }

        private void bt_apply_Click(object sender, EventArgs e)
        {
            mainForm.AddEventAndRestart(lb_header.Text, lb_bottom.Text, clb_eventHours.CheckedItems);
            Hide();
        }
    }
}
