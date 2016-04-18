using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testGraph
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            Datos d = Datos.Instance;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void tVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TV frmObj = new TV();
            frmObj.MdiParent = this;
            frmObj.Show();
        }

        private void tSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TS frmObj = new TS();
            frmObj.MdiParent = this;
            frmObj.Show();
        }
    }
}
