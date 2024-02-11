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
    public partial class frmMovimiento2 : Form
    {
        public frmMovimiento2()
        {
            InitializeComponent();
        }

        private void frmMovimiento2_Load(object sender, EventArgs e)
        {
            datapickfecha.Value = DateTime.Today;
            llenar_tabla();
        }

        public void llenar_tabla()
        {
            using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
            {
                var datos = from egreso in contex.egresoes
                            join usuario in contex.usuarios
                            on egreso.id_usuarios equals usuario.id_usuario
                            where egreso.fecha == DateTime.Today
                            select new
                            {
                                ID = egreso.id_egreso,
                                Usuario = egreso.usuario.usuario1,
                                Fecha = egreso.fecha,
                                Monto = egreso.monto.ToString(),
                                Descripcion = egreso.descricpcion
                            };
                dataingresos.DataSource = datos.ToList();
            }
        }

        private void btnregistar_Click_1(object sender, EventArgs e)
        {
            if (txtmonto.Text.Length > 0 && txtmotivo.Text.Length > 0)
            {
                using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                {

                    DateTime fechaSeleccionada = datapickfecha.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();


                    usuario user = new usuario();
                    egreso egresoporfrm = new egreso()
                    {
                        id_usuarios = 1,
                        monto = Convert.ToDecimal(txtmonto.Text),
                        fecha = Convert.ToDateTime(fechaCorta),
                        descricpcion = txtmotivo.Text
                    };

                    contex.egresoes.Add(egresoporfrm);
                    contex.SaveChanges();
                    MessageBox.Show("Registro Exitoso", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmonto.Text = "";
                    txtmotivo.Text = "";
                    llenar_tabla();
                }
            }
        }

        private void btnmodificar_Click_1(object sender, EventArgs e)
        {
            if (dataingresos.SelectedRows.Count > 0)
            {
                frmmodificar2 modificacion = new frmmodificar2("formulario1");
                AddOwnedForm(modificacion);
                modificacion.Text = "Modificar";
                modificacion.datatimefech.Value = Convert.ToDateTime(dataingresos.CurrentRow.Cells[2].Value);
                modificacion.txtmonto.Text = dataingresos.CurrentRow.Cells[3].Value.ToString();
                modificacion.txtmotivo.Text = dataingresos.CurrentRow.Cells[4].Value.ToString();
                modificacion.ShowDialog();
            }

        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (dataingresos.SelectedRows.Count > 0)
            {
                DialogResult = MessageBox.Show("ESTAS SEGURO QUE QUIERES ELIMINAR EL REGISTRO", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                    {
                        var filaSeleccionada = dataingresos.CurrentRow;
                        int ga = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        egreso ingr = contex.egresoes.FirstOrDefault(r => r.id_egreso == ga);

                        if (ingr != null)
                        {
                            contex.egresoes.Remove(ingr);
                            contex.SaveChanges();
                            llenar_tabla();
                        }

                    }

                }
            }
        }

        private void txtmonto_Validating(object sender, CancelEventArgs e)
        {
            if (txtmonto.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(txtmonto, "Este campo no puede estar vacio");
                e.Cancel = true;
            }
        }

        private void txtmonto_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtmonto, "");
        }

        private void txtmotivo_Validating(object sender, CancelEventArgs e)
        {
            if (txtmotivo.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(txtmotivo, "Este campo no puede estar vacio");
                e.Cancel = true;
            }
        }

        private void txtmotivo_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtmotivo, "");
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<int> lista = new List<int>();
            lista.AddRange(new int[] {44,46, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57,8 });
            //Se crea una lista con el valor de los numero de 0 al 9 siguiendo la tabla del codigo accsi

            int variable = e.KeyChar;
            //variable que almacena el valor de la tecla seleccionada y se le asigna el nombre de "variable"
            if (lista.Contains(variable) == false)
            {
                MessageBox.Show("SOLO SE ACEPTAN NUMERO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                return;
            };
        }
    }
}
