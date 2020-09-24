using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Conchi
{
    public partial class Conchi : Form
    {
        public Conchi()
        {
            InitializeComponent();
        }

        //definimos las rutas de los videos y sonidos
        String rutaAnimacion = @"logos\animacion.mp4";
        String rutaSonido = @"logos\sonido.wav";

        private void Conchi_Load(object sender, EventArgs e)
        {
            iniciarYpausarVideo(rutaAnimacion, true); //iniciamos el video al iniciar la aplicacion
        }

        private Boolean hecho = false;

        private void btnReproducir_Click(object sender, EventArgs e) //este es el metodo que se ejecutará cuando hagamos click sobre el boton de hablar
        {
            if (!hecho)
            {
                iniciarYpausarVideo(rutaAnimacion); //lo despausamos y al cabo de 2300 ms lo reanudamos

                hecho = true;

                iniciarConchi();
            }

            else
            {
                repSonido(rutaSonido); //solo reproducimos el sonido

                iniciarConchi(); //iniciamos la parte logica de conchi, que está escrita en python
            }
        }

        private void iniciarConchi()
        {
            ProcessStartInfo ejecutarConchi = new ProcessStartInfo(); //creamos un nuevo proceso a parte para la ejecucion de conchi en python
            //ejecutarConchi.UseShellExecute = false;
            //ejecutarConchi.CreateNoWindow = true;
            ejecutarConchi.WindowStyle = ProcessWindowStyle.Hidden; //hacemos que la aparencia de la ventana sea escondida para que
            ejecutarConchi.FileName = "start.bat";                  //no se vea la venta de la consola de comandos
            Process.Start(ejecutarConchi);
        }

        private void repSonido(String rutaAudio) //reproducimos el sonido o efecto de que esta escuchando
        {
            SoundPlayer simpleSound = new SoundPlayer(rutaAudio);
            simpleSound.Play();
        }

        private void iniciarVideo() => reproductor.Ctlcontrols.play();
        //inicio de la animacion

        private void pausarVideo() //esperamos 2300 ms que es el tiempo exacto calculado
            //                       y lo pausamos
        {
            Thread.Sleep(2300);
            reproductor.Ctlcontrols.pause();
        }

        public void iniciarYpausarVideo(String ruta, Boolean resetRuta = false)
        {
            if (resetRuta) //si queremos cambiar la ruta
            {
                reproductor.URL = ruta;
            }

            //e iniciamos y pausamos
            var iniciar = Task.Factory.StartNew(iniciarVideo);
            var pausar = Task.Factory.StartNew(pausarVideo);
        }
    }
}
