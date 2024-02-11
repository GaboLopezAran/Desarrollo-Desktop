using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;



namespace Misfinanzas
{
    public partial class frmCuenta : Form
    {
        public frmCuenta()
        {
            InitializeComponent();
        }

        private void frmCuenta_Load(object sender, EventArgs e)
        {
            this.Text = "Resumen de cuenta";
          

        }
        public void llenar_tabla_egresoso()
        {

            DateTime iniciodate = datainicio.Value;
            string fechaCortaini = iniciodate.ToShortDateString();
            DateTime convertidoinicio = Convert.ToDateTime(fechaCortaini);

            DateTime findate = datafin.Value;
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
                DataEgresos.DataSource = datos.ToList();   
            }
        }

        public void llenar_tabla_ingresos()
        {
            DateTime iniciodate = datainicio.Value;
            string fechaCortaini = iniciodate.ToShortDateString();
            DateTime convertidoinicio = Convert.ToDateTime(fechaCortaini);

            DateTime findate = datafin.Value;
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
                dataingresos.DataSource = datos.ToList();
            }
        }


        private void btnbuscarxfiltro_Click(object sender, EventArgs e)
        {

            DateTime iniciodate = datainicio.Value;
            string fechaCortaini = iniciodate.ToShortDateString();
            DateTime convertidoinicio = Convert.ToDateTime(fechaCortaini);

            DateTime findate = datafin.Value;
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
                DataEgresos.DataSource = datos.ToList();
                llenar_tabla_egresoso();

            }
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
                dataingresos.DataSource = datos.ToList();
                llenar_tabla_ingresos();
            }

        }

        private void btntotales_Click(object sender, EventArgs e)
        {
            frmTotales ftotales = new frmTotales();
            AddOwnedForm(ftotales);

            decimal sumaingresos = 0;
            decimal sumaegresos = 0;

            foreach (DataGridViewRow row in dataingresos.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    sumaingresos += Convert.ToDecimal(row.Cells[3].Value.ToString(), CultureInfo.InvariantCulture);
                }
            }

            foreach (DataGridViewRow row in DataEgresos.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    sumaegresos += Convert.ToDecimal(row.Cells[3].Value.ToString(), CultureInfo.InvariantCulture);
                }
            }

            ftotales.txtingresost.Text = sumaingresos.ToString();
            ftotales.txtegresost.Text = sumaegresos.ToString();
            decimal totaleer = sumaingresos - sumaegresos;
            ftotales.txttotales.Text = totaleer.ToString();
            ftotales.ShowDialog();

        }

        private void btneditarc_Click(object sender, EventArgs e)
        {
            using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
            {
                if (dataingresos.SelectedRows.Count>0)
               {
                    frmmodificar modificacion = new frmmodificar("soyfrm2");
                    AddOwnedForm(modificacion);
                    modificacion.Text = "Modificar";
                    modificacion.datatimefech.Value = Convert.ToDateTime(dataingresos.CurrentRow.Cells[2].Value);
                    modificacion.txtmonto.Text = dataingresos.CurrentRow.Cells[3].Value.ToString();
                    modificacion.txtmotivo.Text = dataingresos.CurrentRow.Cells[4].Value.ToString();
                    modificacion.ShowDialog();
                }

                if (DataEgresos.SelectedRows.Count > 0)
                {
                    frmmodificar2 modificacion = new frmmodificar2("formulario2");
                    AddOwnedForm(modificacion);
                    modificacion.Text = "Modificar";
                    modificacion.datatimefech.Value = Convert.ToDateTime(DataEgresos.CurrentRow.Cells[2].Value);
                    modificacion.txtmonto.Text = DataEgresos.CurrentRow.Cells[3].Value.ToString();
                    modificacion.txtmotivo.Text = DataEgresos.CurrentRow.Cells[4].Value.ToString();
                    modificacion.ShowDialog();
                }
            };
        }

        private void dataingresos_SelectionChanged(object sender, EventArgs e)
        {
            DataEgresos.ClearSelection();
        }

        private void DataEgresos_SelectionChanged(object sender, EventArgs e)
        {
            dataingresos.ClearSelection();
        }
        public void llenar_tabla_egreso()
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
                DataEgresos.DataSource = datos.ToList();
            }
        }
        public void llenar_tabla_ingreso()
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

        private void btneliminarc_Click(object sender, EventArgs e)
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
                            llenar_tabla_ingreso();
                        }

                    }

                }
            }
            if (DataEgresos.SelectedRows.Count > 0)
            {
                DialogResult = MessageBox.Show("ESTAS SEGURO QUE QUIERES ELIMINAR EL REGISTRO", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    using (Administracion_FinancieraEntities1 contex = new Administracion_FinancieraEntities1())
                    {
                        var filaSeleccionada = DataEgresos.CurrentRow;
                        int ga = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        egreso egres = contex.egresoes.FirstOrDefault(r => r.id_egreso == ga);

                        if (egres != null)
                        {
                            contex.egresoes.Remove(egres);
                            contex.SaveChanges();
                            llenar_tabla_egreso();
                        }
                    }
                }
            }
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el contenido del formulario
            Bitmap formContent = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(formContent, new Rectangle(0, 0, this.Width, this.Height));

            // Dibujar el contenido en la página de impresión
            e.Graphics.DrawImage(formContent, 0, 0);
        }

       
    }
}
