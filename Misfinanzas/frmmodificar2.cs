using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Misfinanzas
{
    public partial class frmmodificar2 : Form
    {
        //ESTE PUBLIC STRUNG SIRVE PARA DETECTAR DE QUE FORMULARIO SE ESTA ABRIENDO EL FOMULARIO DE EDICION
        public string FormularioOrigen { get; private set; }
        public frmmodificar2(string formularioOrigen) 
        {
            InitializeComponent();
            FormularioOrigen = formularioOrigen;
        }
        public void llenar_tabla()
        {
            if (FormularioOrigen == "formulario1")
            {
                frmMovimiento2 movimiw = Owner as frmMovimiento2;
            using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
             {
                var datos = from egreso in contex.egresoes
                            join usuario in contex.usuarios
                            on egreso.id_usuarios equals usuario.id_usuario
                            where egreso.fecha == DateTime.Today

                            select new
                            {
                                ID = egreso.id_egreso,
                                Usuario = usuario.usuario1,
                                Fecha = egreso.fecha,
                                Monto = egreso.monto.ToString(),
                                Descripcion = egreso.descricpcion
                            };
                movimiw.dataingresos.DataSource = datos.ToList();
 
               }
            }
            else if (FormularioOrigen == "formulario2")
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
                    var datos = from egreso in contex.egresoes
                                join usuario in contex.usuarios
                                on egreso.id_usuarios equals usuario.id_usuario
                                where egreso.fecha >= convertidoinicio & egreso.fecha <= convertidofin
                                orderby egreso.fecha
                                select new
                                {
                                    ID = egreso.id_egreso,
                                    Usuario = egreso.usuario.usuario1,
                                    Fecha = egreso.fecha,
                                    Monto = egreso.monto.ToString(),
                                    Descripcion = egreso.descricpcion,

                                };
                    movimi.DataEgresos.DataSource = datos.ToList();

                }
            }
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (FormularioOrigen == "formulario1")
            {
                frmMovimiento2 movimi = Owner as frmMovimiento2;
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {
                    DateTime fechaSeleccionada = datatimefech.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();

                    var registro = contex.egresoes.Find(movimi.dataingresos.CurrentRow.Cells[0].Value);

                    registro.fecha = Convert.ToDateTime(fechaCorta);
                    registro.monto = Convert.ToDecimal(txtmonto.Text);
                    registro.descricpcion = txtmotivo.Text;

                    contex.SaveChanges();
                    llenar_tabla();
                    MessageBox.Show("EL REGISTRO FUE MODIFICADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                this.Close();
            }
            if (FormularioOrigen == "formulario2")
            {
                frmCuenta movimi = Owner as frmCuenta;
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {

                    DateTime fechaSeleccionada = datatimefech.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();

                    var registro = contex.egresoes.Find(movimi.DataEgresos.CurrentRow.Cells[0].Value);

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

        private void frmmodificar2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
