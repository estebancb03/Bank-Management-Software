namespace Creditos
{
    partial class anularTransaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(anularTransaccion));
            this.campoFecha = new System.Windows.Forms.TextBox();
            this.campoTipo = new System.Windows.Forms.TextBox();
            this.campoNumCuenta = new System.Windows.Forms.TextBox();
            this.comboBoxNumTransaccion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.campoDetalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.campoResponsable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campoMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.campoCondicion = new System.Windows.Forms.TextBox();
            this.campoLimite = new System.Windows.Forms.TextBox();
            this.campoSaldoViejo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // campoFecha
            // 
            this.campoFecha.Location = new System.Drawing.Point(209, 277);
            this.campoFecha.Margin = new System.Windows.Forms.Padding(2);
            this.campoFecha.Name = "campoFecha";
            this.campoFecha.Size = new System.Drawing.Size(219, 20);
            this.campoFecha.TabIndex = 191;
            // 
            // campoTipo
            // 
            this.campoTipo.Location = new System.Drawing.Point(209, 149);
            this.campoTipo.Margin = new System.Windows.Forms.Padding(2);
            this.campoTipo.Name = "campoTipo";
            this.campoTipo.Size = new System.Drawing.Size(219, 20);
            this.campoTipo.TabIndex = 190;
            // 
            // campoNumCuenta
            // 
            this.campoNumCuenta.Location = new System.Drawing.Point(209, 117);
            this.campoNumCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.campoNumCuenta.Name = "campoNumCuenta";
            this.campoNumCuenta.Size = new System.Drawing.Size(219, 20);
            this.campoNumCuenta.TabIndex = 189;
            // 
            // comboBoxNumTransaccion
            // 
            this.comboBoxNumTransaccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxNumTransaccion.FormattingEnabled = true;
            this.comboBoxNumTransaccion.Location = new System.Drawing.Point(209, 83);
            this.comboBoxNumTransaccion.Name = "comboBoxNumTransaccion";
            this.comboBoxNumTransaccion.Size = new System.Drawing.Size(219, 21);
            this.comboBoxNumTransaccion.TabIndex = 188;
            this.comboBoxNumTransaccion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNumTransaccion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 187;
            this.label2.Text = "Número de transacción";
            // 
            // campoDetalle
            // 
            this.campoDetalle.Location = new System.Drawing.Point(209, 245);
            this.campoDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.campoDetalle.Name = "campoDetalle";
            this.campoDetalle.Size = new System.Drawing.Size(219, 20);
            this.campoDetalle.TabIndex = 186;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 185;
            this.label9.Text = "Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(54, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 184;
            this.label7.Text = "Detalle";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.btnAnular);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Location = new System.Drawing.Point(462, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 213);
            this.panel1.TabIndex = 183;
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.Location = new System.Drawing.Point(0, 0);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAnular.Size = new System.Drawing.Size(336, 70);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
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
            this.btnRegresar.Location = new System.Drawing.Point(0, 140);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(336, 73);
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
            this.btnLimpiar.Location = new System.Drawing.Point(0, 69);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(336, 70);
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
            this.label6.Location = new System.Drawing.Point(54, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 182;
            this.label6.Text = "Monto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 181;
            this.label8.Text = "Responsable";
            // 
            // campoResponsable
            // 
            this.campoResponsable.Location = new System.Drawing.Point(209, 213);
            this.campoResponsable.Margin = new System.Windows.Forms.Padding(2);
            this.campoResponsable.Name = "campoResponsable";
            this.campoResponsable.Size = new System.Drawing.Size(219, 20);
            this.campoResponsable.TabIndex = 180;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 179;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 178;
            this.label3.Text = "Numero de cuenta";
            // 
            // campoMonto
            // 
            this.campoMonto.Location = new System.Drawing.Point(209, 181);
            this.campoMonto.Margin = new System.Windows.Forms.Padding(2);
            this.campoMonto.Name = "campoMonto";
            this.campoMonto.Size = new System.Drawing.Size(219, 20);
            this.campoMonto.TabIndex = 177;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 176;
            this.label1.Text = "Anular transacción";
            // 
            // campoCondicion
            // 
            this.campoCondicion.Location = new System.Drawing.Point(417, 42);
            this.campoCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.campoCondicion.Name = "campoCondicion";
            this.campoCondicion.Size = new System.Drawing.Size(72, 20);
            this.campoCondicion.TabIndex = 192;
            // 
            // campoLimite
            // 
            this.campoLimite.Location = new System.Drawing.Point(607, 42);
            this.campoLimite.Margin = new System.Windows.Forms.Padding(2);
            this.campoLimite.Name = "campoLimite";
            this.campoLimite.Size = new System.Drawing.Size(72, 20);
            this.campoLimite.TabIndex = 193;
            // 
            // campoSaldoViejo
            // 
            this.campoSaldoViejo.Location = new System.Drawing.Point(515, 42);
            this.campoSaldoViejo.Margin = new System.Windows.Forms.Padding(2);
            this.campoSaldoViejo.Name = "campoSaldoViejo";
            this.campoSaldoViejo.Size = new System.Drawing.Size(72, 20);
            this.campoSaldoViejo.TabIndex = 194;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(417, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 20);
            this.panel2.TabIndex = 195;
            // 
            // anularTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.campoSaldoViejo);
            this.Controls.Add(this.campoLimite);
            this.Controls.Add(this.campoCondicion);
            this.Controls.Add(this.campoFecha);
            this.Controls.Add(this.campoTipo);
            this.Controls.Add(this.campoNumCuenta);
            this.Controls.Add(this.comboBoxNumTransaccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoDetalle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.campoResponsable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campoMonto);
            this.Controls.Add(this.label1);
            this.Name = "anularTransaccion";
            this.Text = "anularTransaccion";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox campoFecha;
        private System.Windows.Forms.TextBox campoTipo;
        private System.Windows.Forms.TextBox campoNumCuenta;
        private System.Windows.Forms.ComboBox comboBoxNumTransaccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campoDetalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox campoResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campoMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoCondicion;
        private System.Windows.Forms.TextBox campoLimite;
        private System.Windows.Forms.TextBox campoSaldoViejo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAnular;
    }
}