using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                    MessageBox.Show("Este programa requiere la instalación de Python 3, ya que tiene usted Python 2 instalado, y varias dependecias.\n" +
                        "Para descargar Python 3 vaya a su página " +
                        "oficial o siga este enlace. https://www.python.org/downloads/", "Error en la instalación de Python", MessageBoxButtons.OK);
                    Application.Exit();
                }
                //es python 3
                else
                {
                    //console.Read() / console.ReadLine()
                    ProcessStartInfo ejecutarPip = new ProcessStartInfo(); //creamos un nuevo proceso a parte para la ejecucion de conchi en python
                    ejecutarPip.FileName = "pip.bat";
                    Process.Start(ejecutarPip);
                }
            }
            else
            {
                MessageBox.Show("Este programa requiere la instalación de Python 3 y varias dependecias.\nPara descargar Python 3 vaya a su " +
                    "página oficial o siga este enlace. " +
                    "https://www.python.org/downloads/", "Error en la instalación de Python", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
    }
}
