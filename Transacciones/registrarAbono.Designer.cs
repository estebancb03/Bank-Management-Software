namespace Creditos
{
    partial class registrarTransaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registrarTransaccion));
            this.label2 = new System.Windows.Forms.Label();
            this.campoDetalle = new System.Windows.Forms.TextBox();
            this.comboBoxNumCuenta = new System.Windows.Forms.ComboBox();
            this.campoFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.campoNumTransaccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.campoNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.campoMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.campoSaldoViejo = new System.Windows.Forms.TextBox();
            this.campoLimite = new System.Windows.Forms.TextBox();
            this.campoPruebaNumero = new System.Windows.Forms.TextBox();
            this.campoCondicion = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 154;
            this.label2.Text = "Número de transacción";
            // 
            // campoDetalle
            // 
            this.campoDetalle.Location = new System.Drawing.Point(220, 209);
            this.campoDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.campoDetalle.Name = "campoDetalle";
            this.campoDetalle.Size = new System.Drawing.Size(219, 20);
            this.campoDetalle.TabIndex = 153;
            // 
            // comboBoxNumCuenta
            // 
            this.comboBoxNumCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxNumCuenta.FormattingEnabled = true;
            this.comboBoxNumCuenta.Location = new System.Drawing.Point(220, 82);
            this.comboBoxNumCuenta.Name = "comboBoxNumCuenta";
            this.comboBoxNumCuenta.Size = new System.Drawing.Size(219, 21);
            this.comboBoxNumCuenta.TabIndex = 152;
            this.comboBoxNumCuenta.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNumCuenta_SelectedIndexChanged);
            // 
            // campoFecha
            // 
            this.campoFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.campoFecha.Location = new System.Drawing.Point(220, 240);
            this.campoFecha.Name = "campoFecha";
            this.campoFecha.Size = new System.Drawing.Size(219, 26);
            this.campoFecha.TabIndex = 151;
            this.campoFecha.ValueChanged += new System.EventHandler(this.CampoFecha_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 150;
            this.label9.Text = "Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 149;
            this.label7.Text = "Detalle";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.btn);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Location = new System.Drawing.Point(462, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 182);
            this.panel1.TabIndex = 148;
            // 
            // btn
            // 
            this.btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn.FlatAppearance.BorderSize = 0;
            this.btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(336, 60);
            this.btn.TabIndex = 4;
            this.btn.Text = "Registrar";
            this.btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnRegresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresar.Image")));
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegresar.Location = new System.Drawing.Point(0, 120);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(336, 60);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.Location = new System.Drawing.Point(0, 60);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(336, 60);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 147;
            this.label6.Text = "Monto";
            // 
            // campoNumTransaccion
            // 
            this.campoNumTransaccion.Location = new System.Drawing.Point(220, 116);
            this.campoNumTransaccion.Margin = new System.Windows.Forms.Padding(2);
            this.campoNumTransaccion.Name = "campoNumTransaccion";
            this.campoNumTransaccion.Size = new System.Drawing.Size(219, 20);
            this.campoNumTransaccion.TabIndex = 146;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 145;
            this.label8.Text = "Responsable";
            // 
            // campoNombre
            // 
            this.campoNombre.Location = new System.Drawing.Point(220, 178);
            this.campoNombre.Margin = new System.Windows.Forms.Padding(2);
            this.campoNombre.Name = "campoNombre";
            this.campoNombre.Size = new System.Drawing.Size(219, 20);
            this.campoNombre.TabIndex = 144;
            this.campoNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CampoNombre_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Número de cuenta";
            // 
            // campoMonto
            // 
            this.campoMonto.Location = new System.Drawing.Point(220, 147);
            this.campoMonto.Margin = new System.Windows.Forms.Padding(2);
            this.campoMonto.Name = "campoMonto";
            this.campoMonto.Size = new System.Drawing.Size(219, 20);
            this.campoMonto.TabIndex = 141;
            this.campoMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CampoMonto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 140;
            this.label1.Text = "Registrar abono";
            // 
            // campoSaldoViejo
            // 
            this.campoSaldoViejo.Location = new System.Drawing.Point(427, 42);
            this.campoSaldoViejo.Margin = new System.Windows.Forms.Padding(2);
            this.campoSaldoViejo.Name = "campoSaldoViejo";
            this.campoSaldoViejo.Size = new System.Drawing.Size(119, 20);
            this.campoSaldoViejo.TabIndex = 156;
            // 
            // campoLimite
            // 
            this.campoLimite.Location = new System.Drawing.Point(557, 42);
            this.campoLimite.Margin = new System.Windows.Forms.Padding(2);
            this.campoLimite.Name = "campoLimite";
            this.campoLimite.Size = new System.Drawing.Size(119, 20);
            this.campoLimite.TabIndex = 157;
            // 
            // campoPruebaNumero
            // 
            this.campoPruebaNumero.Location = new System.Drawing.Point(301, 42);
            this.campoPruebaNumero.Margin = new System.Windows.Forms.Padding(2);
            this.campoPruebaNumero.Name = "campoPruebaNumero";
            this.campoPruebaNumero.Size = new System.Drawing.Size(113, 20);
            this.campoPruebaNumero.TabIndex = 158;
            // 
            // campoCondicion
            // 
            this.campoCondicion.Location = new System.Drawing.Point(427, 11);
            this.campoCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.campoCondicion.Name = "campoCondicion";
            this.campoCondicion.Size = new System.Drawing.Size(119, 20);
            this.campoCondicion.TabIndex = 192;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(287, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 51);
            this.panel2.TabIndex = 193;
            // 
            // registrarTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.campoCondicion);
            this.Controls.Add(this.campoPruebaNumero);
            this.Controls.Add(this.campoLimite);
            this.Controls.Add(this.campoSaldoViejo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoDetalle);
            this.Controls.Add(this.comboBoxNumCuenta);
            this.Controls.Add(this.campoFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.campoNumTransaccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.campoNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campoMonto);
            this.Controls.Add(this.label1);
            this.Name = "registrarTransaccion";
            this.Text = "registrarTransaccion";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campoDetalle;
        private System.Windows.Forms.ComboBox comboBoxNumCuenta;
        private System.Windows.Forms.DateTimePicker campoFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox campoNumTransaccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox campoNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campoMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoSaldoViejo;
        private System.Windows.Forms.TextBox campoLimite;
        private System.Windows.Forms.TextBox campoPruebaNumero;
        private System.Windows.Forms.TextBox campoCondicion;
        private System.Windows.Forms.Panel panel2;
    }
}