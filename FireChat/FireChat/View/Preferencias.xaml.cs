using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Preferencias : ContentPage
	{
        public static readonly string 
            VIBRACION = "vibracion", 
            SONIDO = "sonido", 
            NOTIFICACIONES_EMERGENTES = "notificacionesEmergentes", 
            NOTIFICACINOES_PANTALLA_INICIO = "notificacionesPantInicio";
        private SwitchCell switchVibracion, switchSonido, switchNotificacionesEmergentes, switchNotificacionesPantInicio;


        public Preferencias ()
		{
			InitializeComponent ();
            switchVibracion = XswitchVibracion;
            switchSonido = XswitchSonido;
            switchNotificacionesEmergentes = XswitchNotEmergentes;
            switchNotificacionesPantInicio = XswitchNotPantaInicio;
            Inicializar();
		}

        private void Inicializar()
        {
            

            if (Application.Current.Properties.ContainsKey(VIBRACION))
            {
                Application.Current.Properties.TryGetValue(VIBRACION, out Object valor);
                Boolean estaActivado = (Boolean)valor;
                switchVibracion.On = estaActivado;
            }
            else
            {
                Application.Current.Properties.Add(VIBRACION, switchVibracion.On);
            }

            if (Application.Current.Properties.ContainsKey(SONIDO))
            {
                Application.Current.Properties.TryGetValue(SONIDO, out Object valor);
                Boolean estaActivado = (Boolean)valor;
                switchSonido.On = estaActivado;
            }
            else
            {
                Application.Current.Properties.Add(SONIDO, switchSonido.On);
            }

            if (Application.Current.Properties.ContainsKey(NOTIFICACIONES_EMERGENTES))
            {
                Application.Current.Properties.TryGetValue(NOTIFICACIONES_EMERGENTES, out Object valor);
                Boolean estaActivado = (Boolean)valor;
                switchNotificacionesEmergentes.On = estaActivado;
            }
            else
            {
                Application.Current.Properties.Add(NOTIFICACIONES_EMERGENTES, switchNotificacionesEmergentes.On);
            }

            if (Application.Current.Properties.ContainsKey(NOTIFICACINOES_PANTALLA_INICIO))
            {
                Application.Current.Properties.TryGetValue(NOTIFICACINOES_PANTALLA_INICIO, out Object valor);
                Boolean estaActivado = (Boolean)valor;
                switchNotificacionesPantInicio.On = estaActivado;
            }
            else
            {
                Application.Current.Properties.Add(NOTIFICACINOES_PANTALLA_INICIO, switchNotificacionesPantInicio.On);
            }
        }

        private void switchVibracionChanged(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties[VIBRACION] = switchVibracion.On;
        }

        private void switchSonidoChanged(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties[SONIDO] = switchSonido.On;
        }

        private void switchNotificacionesEmergentesChanged(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties[NOTIFICACIONES_EMERGENTES] = switchNotificacionesEmergentes.On;
        }

        private void switchNotificacionesPantInicioChanged(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties[NOTIFICACINOES_PANTALLA_INICIO] = switchNotificacionesPantInicio.On;
        }
    }
}