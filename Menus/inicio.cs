using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Creditos
{
    public partial class inicio : Form
    {
        utilidades uti = new utilidades();
        inicioSesion ise = new inicioSesion();
        public inicio()
        {
            InitializeComponent();
            uti.bloquear1(true,campoLogin,campoId,campoNombre,campoApellido,campoNivel,campoCondicion);
        }
    }
}
