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

        public void SetValue(double Total, double Current)
        {
            PgBTotal.BeginInvoke(new MethodInvoker(delegate () { PgBTotal.Value = (int)(Total * 100); }));
            PgBCurrent.BeginInvoke(new MethodInvoker(delegate () { PgBCurrent.Value = (int)(Current * 100); }));
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            Hide(); 
            PgBTotal.BeginInvoke(new MethodInvoker(delegate () { PgBTotal.Value = 0; }));
            PgBCurrent.BeginInvoke(new MethodInvoker(delegate () { PgBCurrent.Value = 0; }));
        }
    }
}
