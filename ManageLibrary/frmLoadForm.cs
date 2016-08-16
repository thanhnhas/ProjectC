using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLibrary
{
    public partial class frmLoadForm : Form
    {
        public frmLoadForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // mỗi lần tăng 1 đơn vị
            progressBar1.Increment(4);
            // progressbar được lắp đầy
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
