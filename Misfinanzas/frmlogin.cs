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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            using(Administracion_FinancieraEntities1 context= new Administracion_FinancieraEntities1())
            {
                
                usuario users=context.usuarios.FirstOrDefault(r => r.usuario1==txtusuario.Text 
                && r.contrasena==txtcontrasena.Text);
                //En esta linea de codigo estoy recorriendo la tabla usuarios y estoy buscando si hay algun registro que sea
                // igual a llo ingresado en txtusuario y txtcontraseña esto se hace con firstOrDefault
                if (users != null)
                {
                    //si la variable user es diferente de NULL es decir que en la Base de datos hay un registro con
                    //esas caracteristicas

                    frmmenu menu = new frmmenu();
                    menu.toltxtusuario.Text = txtusuario.Text;
                    menu.Show();
                    this.Hide();
                }
                else if(txtusuario.Text.Trim().Length<=0 && txtcontrasena.Text.Trim().Length<=0)
                {
                    MessageBox.Show("TIENE QUE LLENAR LOS CAMPOS SOLICITADOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            this.Text = "Inicio de Sesion";
        }
    }
}
