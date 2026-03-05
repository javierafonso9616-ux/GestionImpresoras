using GestionImpresoras.DatosImpresoras;
using GestionIP.Clases;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace GestionImpresoras
{
    public partial class Form2 : MaterialForm
    {
        // Instancia de la clase AccesoDatos para interactuar con la base de datos
        AccesoDatos db = new AccesoDatos();
        bool isDeleting = false;
        public Form2()
        {
            InitializeComponent();
            GestorTema.ConfigurarMaterialSkin(this);
            this.WindowState = FormWindowState.Maximized;
        }









    }
}
