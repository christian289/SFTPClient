using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace SFTPClient
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            BtnHide.Click += BtnHide_Click;
        }

        public void SetValue(int Total, int Current)
        {
            PgBTotal.Value = Total;
            PgBCurrent.Value = Current;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            Hide();
            PgBTotal.Value = 0;
            PgBCurrent.Value = 0;
        }
    }
}
