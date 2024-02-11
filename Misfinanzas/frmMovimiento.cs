using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Misfinanzas
{
    public partial class frmMovimiento : Form
    {

        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<int> lista = new List<int>();
            lista.AddRange(new int[] {8,44,46,48,49,50,51,52,53,54,55,56,57}); 
            //Se crea una lista con el valor de los numero de 0 al 9 siguiendo la tabla del codigo accsi
                
            int variable =e.KeyChar;
            //variable que almacena el valor de la tecla seleccionada y se le asigna el nombre de "variable"
                if (lista.Contains(variable)==false)
                {
                    MessageBox.Show("SOLO SE ACEPTAN NUMERO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Handled = true;
                    return;
                }; 
            //Este if me indica se la list llamada lista contiene la variable "variable"
        }
    private void frmMovimiento_Load(object sender, EventArgs e)
        {
            datapickfecha.Value = DateTime.Today;
            
            llenar_tabla();
            
        }

        public void llenar_tabla()
        {
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
                    dataingresos.DataSource = datos.ToList();
                }
            }

     //Este metodo me da un select utilizando un join entre la tabal ingreso y la tabla usuario y lo ingreso en la
     //tabla datoingresos

        private void txtmonto_Validating(object sender, CancelEventArgs e)
        {
            if (txtmonto.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(txtmonto, "Este campo no puede estar vacio");
                e.Cancel = true;
            }
        }

        private void txtmotivo_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtmotivo, "");
        }

        private void txtmotivo_Validating(object sender, CancelEventArgs e)
        {
            if (txtmotivo.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(txtmotivo, "Este campo no puede estar vacio");
                e.Cancel = true;
            }
        }

        private void txtmonto_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtmonto, "");
        }
        //Valideiting y validate de los controles 
        private void frmMovimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = false;
        }
        //El evento fomrclosig se activa cuando se preciona la X de la parte superior del formuloario
        // Lo que ago es que error provaider los elimino y cancalo el error
        private void btnregistar_Click(object sender, EventArgs e)
        {

            if (txtmonto.Text.Length > 0 && txtmotivo.Text.Length > 0)
            {

                using(Administracion_FinancieraEntities1 contex =new Administracion_FinancieraEntities1())
                {

                    DateTime fechaSeleccionada = datapickfecha.Value;
                    string fechaCorta = fechaSeleccionada.ToShortDateString();
                   

                    usuario user = new usuario();
                    ingreso ingresoporfrm = new ingreso()
                    {
                        id_usuarios =1,
                        monto = Convert.ToDecimal(txtmonto.Text),
                        fecha =Convert.ToDateTime(fechaCorta),
                        descricpcion = txtmotivo.Text
                    };

                    contex.ingresoes.Add(ingresoporfrm);
                    contex.SaveChanges();
                    MessageBox.Show("Registro Exitoso","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtmonto.Text = "";
                    txtmotivo.Text = "";
                    llenar_tabla();
                }
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dataingresos.SelectedRows.Count > 0)
            {
                frmmodificar modificacion = new frmmodificar("soyfrm1");
                AddOwnedForm(modificacion);
                modificacion.Text = "Modificar";
                modificacion.datatimefech.Value =Convert.ToDateTime(dataingresos.CurrentRow.Cells[2].Value);
                modificacion.txtmonto.Text = dataingresos.CurrentRow.Cells[3].Value.ToString();
                modificacion.txtmotivo.Text = dataingresos.CurrentRow.Cells[4].Value.ToString();
                modificacion.ShowDialog();
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
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
                            ingreso ingr = contex.ingresoes.FirstOrDefault(r => r.id_ingreso == ga);

                            if (ingr != null)
                            {
                                contex.ingresoes.Remove(ingr);
                                contex.SaveChanges();
                                llenar_tabla();
                            }

                     }

                 }
             }
         }
    }
}
