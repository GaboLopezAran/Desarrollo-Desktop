using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Misfinanzas
{
    public partial class frmmodificar : Form
    {
        //ESTE PUBLIC STRUNG SIRVE PARA DETECTAR DE QUE FORMULARIO SE ESTA ABRIENDO EL FOMULARIO DE EDICION
        public string FormularioOrigen { get; private set; }
        public frmmodificar(string formularioOrigen)
        {
            InitializeComponent();
            FormularioOrigen = formularioOrigen;
        }

        public void llenar_tabla()
        {
            if (FormularioOrigen == "soyfrm1")
            {
                frmMovimiento movimiw = Owner as frmMovimiento;
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {
                    var datos = from ingreso in contex.ingresoes
                                join usuario in contex.usuarios
                                on ingreso.id_usuarios equals usuario.id_usuario
                                where ingreso.fecha == DateTime.Today

                                select new
                                {
                                    ID = ingreso.id_ingreso,
                                    Usuario = usuario.usuario1,
                                    Fecha = ingreso.fecha,
                                    Monto = ingreso.monto.ToString(),
                                    Descripcion = ingreso.descricpcion
                                };
                    movimiw.dataingresos.DataSource = datos.ToList();

                }
            }

            else if (FormularioOrigen == "soyfrm2")
            {
                frmCuenta movimi = Owner as frmCuenta;
                DateTime iniciodate = movimi.datainicio.Value;
                string fechaCortaini = iniciodate.ToShortDateString();
                DateTime convertidoinicio = Convert.ToDateTime(fechaCortaini);

                DateTime findate = movimi.datafin.Value;
                string fechaCortafin = findate.ToShortDateString();
                DateTime convertidofin = Convert.ToDateTime(fechaCortafin);



                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {
                    var datos = from ingreso in contex.ingresoes
                                join usuario in contex.usuarios
                                on ingreso.id_usuarios equals usuario.id_usuario
                                where ingreso.fecha >= convertidoinicio & ingreso.fecha <= convertidofin
                                orderby ingreso.fecha

                                select new
                                {
                                    ID = ingreso.id_ingreso,
                                    Usuario = ingreso.usuario.usuario1,
                                    Fecha = ingreso.fecha,
                                    Monto = ingreso.monto.ToString(),
                                    Descripcion = ingreso.descricpcion,

                                };
                   movimi.dataingresos.DataSource = datos.ToList();

                }
               
            }
            
        }

        //ESTE METODO HACE QUE SE LLENE LA INFORTMACION DE DEL FORMULARIO DE EDICION HACIA EL FOMULARIO
        //EN EL CUAL SE ENCUENTRA LA TABLA

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (FormularioOrigen == "soyfrm1")
            {
                frmMovimiento movimi = Owner as frmMovimiento;
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {
                    DateTime fechaSeleccionada = datatimefech.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();

                    var registro = contex.ingresoes.Find(movimi.dataingresos.CurrentRow.Cells[0].Value);

                    registro.fecha = Convert.ToDateTime(fechaCorta);
                    registro.monto = Convert.ToDecimal(txtmonto.Text);
                    registro.descricpcion = txtmotivo.Text;

                    contex.SaveChanges();
                    llenar_tabla();
                    MessageBox.Show("EL REGISTRO FUE MODIFICADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                this.Close();
            }

            else if(FormularioOrigen == "soyfrm2")
            {
                frmCuenta movimi = Owner as frmCuenta;
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {

                    DateTime fechaSeleccionada = datatimefech.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();

                    var registro = contex.ingresoes.Find(movimi.dataingresos.CurrentRow.Cells[0].Value);

                    registro.fecha = Convert.ToDateTime(fechaCorta);
                    registro.monto = Convert.ToDecimal(txtmonto.Text);
                    registro.descricpcion = txtmotivo.Text;

                    contex.SaveChanges();
                    llenar_tabla();
                    MessageBox.Show("EL REGISTRO FUE MODIFICADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                this.Close();

            }
           
        }

        private void frmmodificar_Load(object sender, EventArgs e)
        {

        }
    }
}

