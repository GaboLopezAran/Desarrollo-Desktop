namespace Misfinanzas
{
    partial class frmMovimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datapickfecha = new System.Windows.Forms.DateTimePicker();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.btnregistar = new System.Windows.Forms.Button();
            this.dataingresos = new System.Windows.Forms.DataGridView();
            this.lbltitulomovimiento = new System.Windows.Forms.Label();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.txtmotivo = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataingresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(73, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(73, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(73, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto:";
            // 
            // datapickfecha
            // 
            this.datapickfecha.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datapickfecha.Location = new System.Drawing.Point(282, 56);
            this.datapickfecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.datapickfecha.Name = "datapickfecha";
            this.datapickfecha.Size = new System.Drawing.Size(241, 23);
            this.datapickfecha.TabIndex = 3;
            this.datapickfecha.Value = new System.DateTime(2023, 4, 29, 0, 0, 0, 0);
            // 
            // txtmonto
            // 
            this.txtmonto.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmonto.Location = new System.Drawing.Point(282, 99);
            this.txtmonto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(162, 25);
            this.txtmonto.TabIndex = 4;
            this.txtmonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmonto_KeyPress);
            this.txtmonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtmonto_Validating);
            this.txtmonto.Validated += new System.EventHandler(this.txtmonto_Validated);
            // 
            // btnregistar
            // 
            this.btnregistar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistar.Location = new System.Drawing.Point(470, 227);
            this.btnregistar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnregistar.Name = "btnregistar";
            this.btnregistar.Size = new System.Drawing.Size(92, 28);
            this.btnregistar.TabIndex = 6;
            this.btnregistar.Text = "Registrar";
            this.btnregistar.UseVisualStyleBackColor = true;
            this.btnregistar.Click += new System.EventHandler(this.btnregistar_Click);
            // 
            // dataingresos
            // 
            this.dataingresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataingresos.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataingresos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataingresos.Location = new System.Drawing.Point(28, 261);
            this.dataingresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataingresos.Name = "dataingresos";
            this.dataingresos.Size = new System.Drawing.Size(534, 150);
            this.dataingresos.TabIndex = 7;
            // 
            // lbltitulomovimiento
            // 
            this.lbltitulomovimiento.AutoSize = true;
            this.lbltitulomovimiento.Font = new System.Drawing.Font("Rockwell", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulomovimiento.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbltitulomovimiento.Location = new System.Drawing.Point(123, 9);
            this.lbltitulomovimiento.Name = "lbltitulomovimiento";
            this.lbltitulomovimiento.Size = new System.Drawing.Size(376, 33);
            this.lbltitulomovimiento.TabIndex = 8;
            this.lbltitulomovimiento.Text = "Mantenimiento de  Ingreso";
            // 
            // btnmodificar
            // 
            this.btnmodificar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodificar.Location = new System.Drawing.Point(381, 417);
            this.btnmodificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(90, 28);
            this.btnmodificar.TabIndex = 9;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = true;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.Location = new System.Drawing.Point(477, 417);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(85, 28);
            this.btneliminar.TabIndex = 10;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // txtmotivo
            // 
            this.txtmotivo.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmotivo.Location = new System.Drawing.Point(282, 139);
            this.txtmotivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmotivo.Multiline = true;
            this.txtmotivo.Name = "txtmotivo";
            this.txtmotivo.Size = new System.Drawing.Size(241, 71);
            this.txtmotivo.TabIndex = 11;
            this.txtmotivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtmotivo_Validating);
            this.txtmotivo.Validated += new System.EventHandler(this.txtmotivo_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(603, 457);
            this.Controls.Add(this.txtmotivo);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.lbltitulomovimiento);
            this.Controls.Add(this.dataingresos);
            this.Controls.Add(this.btnregistar);
            this.Controls.Add(this.txtmonto);
            this.Controls.Add(this.datapickfecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMovimiento";
            this.Text = "frmMovimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMovimiento_FormClosing);
            this.Load += new System.EventHandler(this.frmMovimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataingresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datapickfecha;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.Button btnregistar;
        public System.Windows.Forms.DataGridView dataingresos;
        public System.Windows.Forms.Label lbltitulomovimiento;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.TextBox txtmotivo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}