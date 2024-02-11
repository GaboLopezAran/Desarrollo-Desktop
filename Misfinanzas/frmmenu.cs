using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Misfinanzas
{
    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
           
            this.Text = "Menu";
            toltxtfecha.Text = DateTime.Now.ToShortDateString();
            //La linea de arriba me da la fecha actual 
            string time = DateTime.Now.ToString("h:mm tt");
            toltxthora.Text = time;
            //Las dos lineas de arriba, una me da la hora y la hora, y en la otra asigno la hora en una variable
            
        }

        private void registarIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimiento movimiento = new frmMovimiento();
            movimiento.MdiParent = this;
            movimiento.Text = "Agregar Ingreso";
            movimiento.Show();
        }

        private void registrarEgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimiento2 movimiento2 = new frmMovimiento2();
            movimiento2.MdiParent = this;
            movimiento2.Text = "Agregar Egreso";
            movimiento2.Show();

        }

        private void verCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmCuenta cuenta = new frmCuenta();
            cuenta.MdiParent = this;
            cuenta.Text = "Ver Cuenta";
            cuenta.Show();
            
           
        }
    }
}
