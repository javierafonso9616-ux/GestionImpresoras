using GestionImpresoras.DatosImpresoras; // Asegúrate de tener este using para AccesoDatos
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GestionImpresoras
{
    public partial class FormNuevaImpresora : MaterialForm
    {
        // INSTANCIA DE LA CLASE DE ACCESO A DATOS Y LISTA PARA ALMACENAR LAS IPS OCUPADAS
        AccesoDatos db = new AccesoDatos();
        List<string> ips = new List<string>();

        public string SerieGuardada { get; private set; } // Variable pública para almacenar el número de serie guardado y
                                                          // que el formulario principal pueda acceder a ella

        // -----------------------------------------------------------------------------------
        // CONSTRUCTOR
        // -----------------------------------------------------------------------------------
        public FormNuevaImpresora()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------
        // EVENTO LOAD (CARGA EL FORMULARIO)
        //-----------------------------------------------------------------------------------
        private void FormNuevaImpresora_Load(object sender, EventArgs e)
        {

            // CARGAMOS LAS IPS OCUPADAS EN LA LISTA
            DataTable dtIps = db.ObtenerDatos("SELECT IP FROM IMPRESORAS WHERE IP IS NOT NULL");

            // LIMPIAMOS LOS DATOS QUITANDO ESPACIOS Y CONVERTIMOS A MAYÚSCULAS PARA EVITAR PROBLEMAS DE COMPARACIÓN
            foreach (DataRow r in dtIps.Rows)
            {
                ips.Add(r["IP"].ToString().Trim().ToUpper());
            }

            // lIMPIAMOS EL LABEL DE AVISO DE IP(POR DEFENTO EN EL DISEÑADOR HAY UN TEXTO PARA PODER AJUSTARLO EN EL FORM)
            lblAvisoIP.Text = "";
            // FOCO EN EL CAMPO UBICACION
            txtUbicacion.Select();
        }

        //-----------------------------------------------------------------------------------
        // TXT IP: Validación en tiempo real de formato y disponibilidad
        //-----------------------------------------------------------------------------------
        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                lblAvisoIP.Text = "";
            }
            else if (!System.Net.IPAddress.TryParse(ip, out _) || ip.Split('.').Length != 4)
            {
                lblAvisoIP.Text = "⚠️ FORMATO INCORRECTO";
                lblAvisoIP.ForeColor = Color.OrangeRed;
            }
            else if (ips.Contains(ip.ToUpper()))
            {
                lblAvisoIP.Text = "❌ OCUPADA";
                lblAvisoIP.ForeColor = Color.Red;
            }
            else
            {
                lblAvisoIP.Text = "✔ DISPONIBLE";
                lblAvisoIP.ForeColor = Color.Green;
            }
        }

        //-----------------------------------------------------------------------------------
        // BOTONES: Guardar y Cancelar
        //-----------------------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string se = txtNSerie.Text.Trim().ToUpper();
            string ub = txtUbicacion.Text.Trim().ToUpper();
            string mo = txtModelo.Text.Trim().ToUpper();
            string ip = txtIP.Text.Trim().ToUpper();

            // 1. Validaciones básicas
            if (string.IsNullOrEmpty(se) || string.IsNullOrEmpty(ub) || string.IsNullOrEmpty(mo) || string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Faltan datos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validación de IP
            if (ips.Contains(ip))
            {
                MessageBox.Show("Esa IP ya está ocupada por otra impresora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Net.IPAddress.TryParse(ip, out _) || ip.Split('.').Length != 4)
            {
                MessageBox.Show("El formato de la IP es incorrecto (Ejemplo válido: 192.168.1.100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Validación de Número de Serie (que no exista ya)
            string sqlComprobarSerie = "SELECT IP FROM IMPRESORAS WHERE NSERIE=@s";
            if (db.ObtenerDatos(sqlComprobarSerie, new SqlParameter[] { new SqlParameter("@s", se) }).Rows.Count > 0)
            {
                MessageBox.Show("Ya existe una impresora con ese Número de Serie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Intentamos convertir el Grupo a número (si han puesto algo)
            int? numeroGrupo = null;
            if (!string.IsNullOrEmpty(txtGrupo.Text))
            {
                if (int.TryParse(txtGrupo.Text.Trim(), out int tempGrupo))
                {
                    numeroGrupo = tempGrupo;
                }
                else
                {
                    MessageBox.Show("El grupo debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 5. Guardar en base de datos
            string sql = "INSERT INTO IMPRESORAS (UBICACION, MODELO, NSERIE, IP, OBSERVACIONES, GRUPO) VALUES (@u, @m, @s, @i, @o, @g)";

            SqlParameter[] pa = {
                new SqlParameter("@u", ub),
                new SqlParameter("@m", mo),
                new SqlParameter("@s", se),
                new SqlParameter("@i", ip),
                new SqlParameter("@o", string.IsNullOrEmpty(txtObservaciones.Text) ? (object)DBNull.Value : txtObservaciones.Text.ToUpper()),
                new SqlParameter("@g", numeroGrupo.HasValue ? (object)numeroGrupo.Value : (object)DBNull.Value)
            };

            try
            {
                db.EjecutarComando(sql, pa);

                // Si todo ha ido bien, guardamos el número de serie en la variable pública
                this.SerieGuardada = se;

                // Y le decimos al formulario principal que todo ha sido un éxito ("OK")
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}