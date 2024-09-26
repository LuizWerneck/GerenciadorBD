using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gerenciadorBanco
{
    public partial class Form1 : Form
    {
        
        bool sidebarExpand;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start(); // Inicia o Timer


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
        }

        bool mouseClicked;
        Point clickedAt;

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseClicked = true;
            clickedAt = e.Location;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        public void btnLimpar_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            FormLimpaBanco frmLimpa = new FormLimpaBanco();
            frmLimpa.TopLevel = false;
            frmLimpa.Dock = DockStyle.Fill;
            
            pnlPrincipal.Controls.Add(frmLimpa);
            frmLimpa.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIncosistencia_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            FormInconsistencia frmInco = new FormInconsistencia();
            frmInco.TopLevel = false;
            frmInco.Dock = DockStyle.Fill;

            pnlPrincipal.Controls.Add(frmInco);
            frmInco.Show();

        }
    }

}
