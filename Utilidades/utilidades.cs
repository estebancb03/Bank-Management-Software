using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creditos
{
    class utilidades
    {
        //Métodos de bloqueo
        public void bloquear1(Boolean estado,System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3,System.Windows.Forms.TextBox campo4,System.Windows.Forms.TextBox campo5,
        System.Windows.Forms.TextBox campo6)
        {
            if (estado == true)
            {
                campo1.Enabled = false;
                campo2.Enabled = false;
                campo3.Enabled = false;
                campo4.Enabled = false;
                campo5.Enabled = false;
                campo6.Enabled = false;
            }
            else
            {
                campo1.Enabled = true;
                campo2.Enabled = true;
                campo3.Enabled = true;
                campo4.Enabled = true;
                campo5.Enabled = true;
                campo6.Enabled = true;
            }
        }
        public void bloquear2(Boolean estado, System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5)
        {
            if (estado == true)
            {
                campo1.Enabled = false;
                campo2.Enabled = false;
                campo3.Enabled = false;
                campo4.Enabled = false;
                campo5.Enabled = false;
            }
            else
            {
                campo1.Enabled = true;
                campo2.Enabled = true;
                campo3.Enabled = true;
                campo4.Enabled = true;
                campo5.Enabled = true;
            }
        }
        public void bloquear3(Boolean estado, System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5, 
        System.Windows.Forms.TextBox campo6, System.Windows.Forms.TextBox campo7)
        {
            if (estado == true)
            {
                campo1.Enabled = false;
                campo2.Enabled = false;
                campo3.Enabled = false;
                campo4.Enabled = false;
                campo5.Enabled = false;
                campo6.Enabled = false;
                campo7.Enabled = false;
            }
            else
            {
                campo1.Enabled = true;
                campo2.Enabled = true;
                campo3.Enabled = true;
                campo4.Enabled = true;
                campo5.Enabled = true;
                campo6.Enabled = true;
                campo7.Enabled = true;
            }
        }
        public void bloquear4(Boolean estado, System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.ComboBox campo5,
        System.Windows.Forms.ComboBox campo6, System.Windows.Forms.TextBox campo7)
        {
            if (estado == true)
            {
                campo1.Enabled = false;
                campo2.Enabled = false;
                campo3.Enabled = false;
                campo4.Enabled = false;
                campo5.Enabled = false;
                campo6.Enabled = false;
                campo7.Enabled = false;
            }
            else
            {
                campo1.Enabled = true;
                campo2.Enabled = true;
                campo3.Enabled = true;
                campo4.Enabled = true;
                campo5.Enabled = true;
                campo6.Enabled = true;
                campo7.Enabled = true;
            }
        }
        public void bloquearMenu(Boolean estado, System.Windows.Forms.ToolStripMenuItem campo1, System.Windows.Forms.ToolStripMenuItem campo2,
        System.Windows.Forms.ToolStripMenuItem campo3, System.Windows.Forms.ToolStripMenuItem campo4, System.Windows.Forms.ToolStripMenuItem campo5,
        System.Windows.Forms.ToolStripMenuItem campo6, System.Windows.Forms.ToolStripMenuItem campo7, System.Windows.Forms.ToolStripMenuItem campo8,
        System.Windows.Forms.ToolStripMenuItem campo9, System.Windows.Forms.ToolStripMenuItem campo10, System.Windows.Forms.ToolStripMenuItem campo11,
        System.Windows.Forms.ToolStripMenuItem campo12, System.Windows.Forms.ToolStripMenuItem campo13, System.Windows.Forms.ToolStripMenuItem campo14,
        System.Windows.Forms.ToolStripMenuItem campo15, System.Windows.Forms.ToolStripMenuItem campo16, System.Windows.Forms.ToolStripMenuItem campo17,
        System.Windows.Forms.ToolStripMenuItem campo18, System.Windows.Forms.ToolStripMenuItem campo19, System.Windows.Forms.ToolStripMenuItem campo20,
        System.Windows.Forms.ToolStripMenuItem campo21, System.Windows.Forms.ToolStripMenuItem campo22, System.Windows.Forms.ToolStripMenuItem campo23,
        System.Windows.Forms.ToolStripMenuItem campo24, System.Windows.Forms.ToolStripMenuItem campo25, System.Windows.Forms.ToolStripMenuItem campo26,
        System.Windows.Forms.ToolStripMenuItem campo27, System.Windows.Forms.ToolStripMenuItem campo28, System.Windows.Forms.ToolStripMenuItem campo29,
        System.Windows.Forms.ToolStripMenuItem campo30, System.Windows.Forms.ToolStripMenuItem campo31, System.Windows.Forms.ToolStripMenuItem campo32,
        System.Windows.Forms.ToolStripMenuItem campo33, System.Windows.Forms.ToolStripMenuItem campo34, System.Windows.Forms.ToolStripMenuItem campo35,
        System.Windows.Forms.ToolStripMenuItem campo36)
        {
            if (estado == true)
            {
                campo1.Enabled = false;
                campo2.Enabled = false;
                campo3.Enabled = false;
                campo4.Enabled = false;
                campo5.Enabled = false;
                campo6.Enabled = false;
                campo7.Enabled = false;
                campo8.Enabled = false;
                campo9.Enabled = false;
                campo10.Enabled = false;
                campo11.Enabled = false;
                campo12.Enabled = false;
                campo13.Enabled = false;
                campo14.Enabled = false;
                campo15.Enabled = false;
                campo16.Enabled = false;
                campo17.Enabled = false;
                campo18.Enabled = false;
                campo19.Enabled = false;
                campo20.Enabled = false;
                campo21.Enabled = false;
                campo22.Enabled = false;
                campo23.Enabled = false;
                campo24.Enabled = false;
                campo25.Enabled = false;
                campo26.Enabled = false;
                campo27.Enabled = false;
                campo28.Enabled = false;
                campo29.Enabled = false;
                campo30.Enabled = false;
                campo31.Enabled = false;
                campo32.Enabled = false;
                campo33.Enabled = false;
                campo34.Enabled = false;
                campo35.Enabled = false;
                campo36.Enabled = false;
            }
            else
            {
                campo1.Enabled = true;
                campo2.Enabled = true;
                campo3.Enabled = true;
                campo4.Enabled = true;
                campo5.Enabled = true;
                campo6.Enabled = true;
                campo7.Enabled = true;
                campo8.Enabled = true;
                campo9.Enabled = true;
                campo10.Enabled = true;
                campo11.Enabled = true;
                campo12.Enabled = true;
                campo13.Enabled = true;
                campo14.Enabled = true;
                campo15.Enabled = true;
                campo16.Enabled = true;
                campo17.Enabled = true;
                campo18.Enabled = true;
                campo19.Enabled = true;
                campo20.Enabled = true;
                campo21.Enabled = true;
                campo22.Enabled = true;
                campo23.Enabled = true;
                campo24.Enabled = true;
                campo25.Enabled = true;
                campo26.Enabled = true;
                campo27.Enabled = true;
                campo28.Enabled = true;
                campo29.Enabled = true;
                campo30.Enabled = true;
                campo31.Enabled = true;
                campo32.Enabled = true;
                campo33.Enabled = true;
                campo34.Enabled = true;
                campo35.Enabled = true;
                campo36.Enabled = true;
            }
        }
        //Métodos de limpiar
        public void limpiar1(System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5,
        System.Windows.Forms.DateTimePicker campo6)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo1.Focus();
        }
        public void limpiar2(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5,
        System.Windows.Forms.TextBox campo6)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo1.Focus();
        }
        public void limpiar3(System.Windows.Forms.TextBox campo1, System.Windows.Forms.ComboBox campo2,
        System.Windows.Forms.ComboBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5,
        System.Windows.Forms.DateTimePicker campo6)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo1.Focus();
        }
        public void limpiar4(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5,
        System.Windows.Forms.TextBox campo6, System.Windows.Forms.TextBox campo7)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo7.Text = "";
            campo1.Focus();
        }
        public void limpiar5(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.ComboBox campo2)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo1.Focus();
        }
        public void limpiar6(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo1.Focus();
        }
        public void limpiar7(System.Windows.Forms.TextBox campo1, System.Windows.Forms.ComboBox campo2,
        System.Windows.Forms.TextBox campo3, System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5, 
        System.Windows.Forms.DateTimePicker campo6)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo1.Focus();
        }
        public void limpiar8(System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo1.Focus();
        }
        public void limpiar9(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3,
        System.Windows.Forms.DateTimePicker campo4, System.Windows.Forms.TextBox campo5, System.Windows.Forms.TextBox campo6, 
        System.Windows.Forms.TextBox campo7, System.Windows.Forms.TextBox campo8)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo7.Text = "";
            campo8.Text = "";
            campo1.Focus();
        }
        public void limpiar10(System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3,
        System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5, System.Windows.Forms.ComboBox campo6,
        System.Windows.Forms.ComboBox campo7, System.Windows.Forms.DateTimePicker campo8)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo7.Text = "";
            campo8.Text = "";
            campo1.Focus();
        }
        public void limpiar11(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3,
        System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5, System.Windows.Forms.TextBox campo6,
        System.Windows.Forms.TextBox campo7, System.Windows.Forms.TextBox campo8)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo7.Text = "";
            campo8.Text = "";
            campo1.Focus();
        }
        public void limpiar12(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3,
        System.Windows.Forms.TextBox campo4, System.Windows.Forms.TextBox campo5, System.Windows.Forms.ComboBox campo6,
        System.Windows.Forms.ComboBox campo7, System.Windows.Forms.TextBox campo8)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo5.Text = "";
            campo6.Text = "";
            campo7.Text = "";
            campo8.Text = "";
            campo1.Focus();
        }
        public void limpiar13(System.Windows.Forms.TextBox campo1, System.Windows.Forms.TextBox campo2)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo1.Focus();
        }
        public void limpiar14(System.Windows.Forms.TextBox campo1, System.Windows.Forms.ComboBox campo2, System.Windows.Forms.ComboBox campo3,
        System.Windows.Forms.ComboBox campo4)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo1.Focus();
        }
        public void limpiar15(System.Windows.Forms.ComboBox campo1, System.Windows.Forms.TextBox campo2, System.Windows.Forms.TextBox campo3,
        System.Windows.Forms.ComboBox campo4)
        {
            campo1.Text = "";
            campo2.Text = "";
            campo3.Text = "";
            campo4.Text = "";
            campo1.Focus();
        }
    }
}
