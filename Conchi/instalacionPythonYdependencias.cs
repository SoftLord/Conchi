using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conchi
{
    public partial class instalacionPythonYdependencias : Form
    {
        public instalacionPythonYdependencias()
        {
            InitializeComponent();
        }

        private void ComprobarArchivos()
        {
            //comprobamos si tiene python 3 instalado
            if (Directory.Exists(@"C:\Users\alvar\AppData\Roaming\Python"))
            {
                //comprobamos que no sea Python 2
                if (Directory.Exists(@"C:\Users\alvar\AppData\Roaming\Python\Python27"))
                {

                }
                //es python 3
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
