namespace Creditos
{
    partial class consultarCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consultarCuentas));
            this.label2 = new System.Windows.Forms.Label();
            this.campoMonto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.campoLimite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campoSaldo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNumCuenta = new System.Windows.Forms.ComboBox();
            this.campoId = new System.Windows.Forms.TextBox();
            this.campoCondicion = new System.Windows.Forms.TextBox();
            this.campoFecha = new System.Windows.Forms.TextBox();
            this.campoSaldoPrueba = new System.Windows.Forms.TextBox();
            this.campoLimitePrueba = new System.Windows.Forms.TextBox();
            this.campoDisponiblePrueba = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 154;
            this.label2.Text = "Número de cuenta";
            // 
            // campoMonto
            // 
            this.campoMonto.Location = new System.Drawing.Point(181, 244);
            this.campoMonto.Margin = new System.Windows.Forms.Padding(2);
            this.campoMonto.Name = "campoMonto";
            this.campoMonto.Size = new System.Drawing.Size(237, 20);
            this.campoMonto.TabIndex = 153;
            this.campoMonto.TextChanged += new System.EventHandler(this.CampoMonto_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 150;
            this.label9.Text = "Apertura";
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 149;
            this.label7.Text = "Monto disponible";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Location = new System.Drawing.Point(453, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 213);
            this.panel1.TabIndex = 148;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.Location = new System.Drawing.Point(0, 0);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnConsultar.Size = new System.Drawing.Size(345, 70);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
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
            this.btnRegresar.Size = new System.Drawing.Size(345, 73);
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
            this.btnLimpiar.Size = new System.Drawing.Size(345, 70);
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
            this.label6.Location = new System.Drawing.Point(55, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 147;
            this.label6.Text = "Saldo a pagar";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 145;
            this.label8.Text = "Límite de crédito";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // campoLimite
            // 
            this.campoLimite.Location = new System.Drawing.Point(181, 212);
            this.campoLimite.Margin = new System.Windows.Forms.Padding(2);
            this.campoLimite.Name = "campoLimite";
            this.campoLimite.Size = new System.Drawing.Size(237, 20);
            this.campoLimite.TabIndex = 144;
            this.campoLimite.TextChanged += new System.EventHandler(this.CampoLimite_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 143;
            this.label4.Text = "Condición";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Identificación";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // campoSaldo
            // 
            this.campoSaldo.Location = new System.Drawing.Point(181, 180);
            this.campoSaldo.Margin = new System.Windows.Forms.Padding(2);
            this.campoSaldo.Name = "campoSaldo";
            this.campoSaldo.Size = new System.Drawing.Size(237, 20);
            this.campoSaldo.TabIndex = 141;
            this.campoSaldo.TextChanged += new System.EventHandler(this.CampoSaldo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 140;
            this.label1.Text = "Consultar cuenta";
            // 
            // comboBoxNumCuenta
            // 
            this.comboBoxNumCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxNumCuenta.FormattingEnabled = true;
            this.comboBoxNumCuenta.Location = new System.Drawing.Point(181, 83);
            this.comboBoxNumCuenta.Name = "comboBoxNumCuenta";
            this.comboBoxNumCuenta.Size = new System.Drawing.Size(237, 21);
            this.comboBoxNumCuenta.TabIndex = 156;
            // 
            // campoId
            // 
            this.campoId.Location = new System.Drawing.Point(181, 116);
            this.campoId.Margin = new System.Windows.Forms.Padding(2);
            this.campoId.Name = "campoId";
            this.campoId.Size = new System.Drawing.Size(237, 20);
            this.campoId.TabIndex = 157;
            this.campoId.TextChanged += new System.EventHandler(this.CampoId_TextChanged);
            // 
            // campoCondicion
            // 
            this.campoCondicion.Location = new System.Drawing.Point(181, 148);
            this.campoCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.campoCondicion.Name = "campoCondicion";
            this.campoCondicion.Size = new System.Drawing.Size(237, 20);
            this.campoCondicion.TabIndex = 158;
            this.campoCondicion.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // campoFecha
            // 
            this.campoFecha.Location = new System.Drawing.Point(181, 276);
            this.campoFecha.Margin = new System.Windows.Forms.Padding(2);
            this.campoFecha.Name = "campoFecha";
            this.campoFecha.Size = new System.Drawing.Size(237, 20);
            this.campoFecha.TabIndex = 159;
            this.campoFecha.TextChanged += new System.EventHandler(this.TextBox1_TextChanged_1);
            // 
            // campoSaldoPrueba
            // 
            this.campoSaldoPrueba.Location = new System.Drawing.Point(417, 42);
            this.campoSaldoPrueba.Margin = new System.Windows.Forms.Padding(2);
            this.campoSaldoPrueba.Name = "campoSaldoPrueba";
            this.campoSaldoPrueba.Size = new System.Drawing.Size(79, 20);
            this.campoSaldoPrueba.TabIndex = 160;
            // 
            // campoLimitePrueba
            // 
            this.campoLimitePrueba.Location = new System.Drawing.Point(500, 42);
            this.campoLimitePrueba.Margin = new System.Windows.Forms.Padding(2);
            this.campoLimitePrueba.Name = "campoLimitePrueba";
            this.campoLimitePrueba.Size = new System.Drawing.Size(96, 20);
            this.campoLimitePrueba.TabIndex = 161;
            // 
            // campoDisponiblePrueba
            // 
            this.campoDisponiblePrueba.Location = new System.Drawing.Point(600, 42);
            this.campoDisponiblePrueba.Margin = new System.Windows.Forms.Padding(2);
            this.campoDisponiblePrueba.Name = "campoDisponiblePrueba";
            this.campoDisponiblePrueba.Size = new System.Drawing.Size(79, 20);
            this.campoDisponiblePrueba.TabIndex = 162;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(417, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 25);
            this.panel2.TabIndex = 180;
            // 
            // consultarCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 517);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.campoDisponiblePrueba);
            this.Controls.Add(this.campoLimitePrueba);
            this.Controls.Add(this.campoSaldoPrueba);
            this.Controls.Add(this.campoFecha);
            this.Controls.Add(this.campoCondicion);
            this.Controls.Add(this.campoId);
            this.Controls.Add(this.comboBoxNumCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoMonto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.campoLimite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campoSaldo);
            this.Controls.Add(this.label1);
            this.Name = "consultarCuentas";
            this.Text = "consultarCuentas";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campoMonto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox campoLimite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campoSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox comboBoxNumCuenta;
        private System.Windows.Forms.TextBox campoId;
        private System.Windows.Forms.TextBox campoCondicion;
        private System.Windows.Forms.TextBox campoFecha;
        private System.Windows.Forms.TextBox campoSaldoPrueba;
        private System.Windows.Forms.TextBox campoLimitePrueba;
        private System.Windows.Forms.TextBox campoDisponiblePrueba;
        private System.Windows.Forms.Panel panel2;
    }
}