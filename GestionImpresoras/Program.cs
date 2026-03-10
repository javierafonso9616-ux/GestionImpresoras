using System;
using System.Threading;
using System.Windows.Forms;

namespace GestionImpresoras
{
    internal static class Program
    {
        // 1. Creamos un "cerrojo" único para nuestra aplicación
        static Mutex mutex = new Mutex(true, "{Un-Nombre-Unico-Para-GestionImpresoras-2024}");

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. Comprobamos si el cerrojo ya está echado (si la app ya está abierta)
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // 2. CONFIGURACIÓN: Forzar idioma y formato de fechas a Español
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                // 3. SEGURIDAD: Atrapamos errores globales no controlados
                Application.ThreadException += new ThreadExceptionEventHandler(Aplicacion_ErrorInesperado);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Sistema_ErrorFatal);

                // Tu código original
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormPrincipal()); // Asegúrate de que este es el nombre de tu form de inicio

                // Soltamos el cerrojo al cerrar la app
                mutex.ReleaseMutex();
            }
            else
            {
                // Si ya estaba abierta, mostramos un mensaje y no hacemos nada más
                MessageBox.Show("El programa ya se está ejecutando.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // --- MANEJADORES DE ERRORES GLOBALES ---
        // ==========================================
        static void Aplicacion_ErrorInesperado(object sender, ThreadExceptionEventArgs e)
        {
            // Esto salta si hay un error en la interfaz que se te olvidó controlar
            MessageBox.Show("Ups, ha ocurrido un error inesperado:\n\n" + e.Exception.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void Sistema_ErrorFatal(object sender, UnhandledExceptionEventArgs e)
        {
            // Esto salta si hay un error gravísimo a nivel de sistema
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show("Error fatal en el sistema. La aplicación se cerrará.\n\n" + ex.Message,
                            "Fallo Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}