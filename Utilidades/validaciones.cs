using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creditos
{
    class validaciones
    {
        //Método para ingresar solo números
        public void soloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                if (Char.IsDigit(e.KeyChar))
                    e.Handled = false;
                else
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = true;
                    else
                        e.Handled = true;
        }
        //Método para ingresar solo leras
        public void soloLetras(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = false;
        }
    }
}
