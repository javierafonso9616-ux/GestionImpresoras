using GestionImpresoras.DatosImpresoras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionImpresoras
{
    public partial class Form1 : Form
    {
        AccesoDatos db = new AccesoDatos();

        // Variable de control para evitar que el evento RowValidated guarde mientras borramos
        bool isDeleting = false;

        public Form1()
        {
            InitializeComponent();
            ConfigurarGrids();

        }

        private void ConfigurarGrids()
        {
            // --- INVENTARIO ---
            dgvInventario.AllowUserToDeleteRows = false; // Importante: gestionamos nosotros el borrado
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.RowValidated += dgvInventario_RowValidated;
            dgvInventario.CellFormatting += AplicarColoresGrupo;
            dgvInventario.KeyDown += Grids_KeyDown; // Conectar tecla Suprimir

            // --- PEDIDO WEB (SOLICITAR) ---
            dgvPedidoWeb.ReadOnly = true;                // Nadie puede escribir en las celdas
            dgvPedidoWeb.AllowUserToAddRows = false;     // Quita la fila vacía del final
            dgvPedidoWeb.AllowUserToDeleteRows = false;  // Evita borrados accidentales aquí
            dgvPedidoWeb.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona fila entera
            dgvPedidoWeb.MultiSelect = true;             // Permite elegir varios
            dgvPedidoWeb.CellFormatting += AplicarColoresGrupo;
            dgvPedidoWeb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidoWeb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // --- HISTORIAL ---
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.CellFormatting += AplicarColoresGrupo;
            dgvHistorial.KeyDown += Grids_KeyDown; // Conectar tecla Suprimir

            // --- TOTALES ---
            dgvTotales.ReadOnly = true;                  // Nadie puede alterar los cálculos
            dgvTotales.AllowUserToAddRows = false;
            dgvTotales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotales.MultiSelect = false;              // Solo una máquina a la vez
            dgvTotales.CellFormatting += AplicarColoresGrupo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarInventario();
            CargarHistorial();
        }

        // ==========================================
        // --- LÓGICA DE BORRADO MULTIPLE (TECLA SUPR) ---
        // ==========================================

        private void Grids_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridView grid = (DataGridView)sender;
                int seleccionados = grid.SelectedRows.Count;

                if (seleccionados == 0) return;

                // 1. ACTIVAMOS EL SEMÁFORO: "Estamos borrando, no guardes nada"
                isDeleting = true;

                string mensaje = (seleccionados == 1)
                    ? "¿Estás seguro de que quieres eliminar este registro?"
                    : $"¿Estás seguro de que quieres eliminar estos {seleccionados} registros a la vez?";

                if (MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow fila in grid.SelectedRows)
                        {
                            if (fila.IsNewRow) continue;
                            string nSerie = fila.Cells["NSERIE"].Value?.ToString();

                            if (grid.Name == "dgvInventario")
                            {
                                db.EjecutarComando("DELETE FROM IMPRESORAS WHERE NSERIE = @ser", new SqlParameter[] { new SqlParameter("@ser", nSerie) });
                            }
                            else if (grid.Name == "dgvHistorial")
                            {
                                DateTime fecha = Convert.ToDateTime(fila.Cells["FECHA"].Value);
                                db.EjecutarComando("DELETE FROM TAMBORES WHERE NSERIE = @ser AND FECHA = @fec",
                                    new SqlParameter[] { new SqlParameter("@ser", nSerie), new SqlParameter("@fec", fecha) });
                            }
                        }

                        // Refrescamos los datos después de borrar todo
                        CargarInventario();
                        CargarHistorial();
                        MessageBox.Show("Registros eliminados correctamente.");
                    }
                    catch (Exception ex) { MessageBox.Show("Error al borrar: " + ex.Message); }
                }

                // 2. APAGAMOS EL SEMÁFORO: "Ya puedes volver a guardar cambios"
                isDeleting = false;
            }
        }

        // ==========================================
        // --- COLORES PASTEL ---
        // ==========================================

        private void AplicarColoresGrupo(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            // Verificamos que la columna exista y sea "GRUPO"
            if (grid.Columns[e.ColumnIndex].Name == "GRUPO" && e.Value != null)
            {
                string val = e.Value.ToString();
                switch (val)
                {
                    case "1": e.CellStyle.BackColor = ColorTranslator.FromHtml("#FCE4D6"); break; // Naranja (Énfasis 2)
                    case "2": e.CellStyle.BackColor = ColorTranslator.FromHtml("#EDEDED"); break; // Gris (Énfasis 3)
                    case "3": e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFF2CC"); break; // Oro (Énfasis 4)
                    case "4": e.CellStyle.BackColor = ColorTranslator.FromHtml("#D9E1F2"); break; // Azul (Énfasis 1)

                    // --- GRUPO 2: NUEVOS CON CONTRASTE REAL ---
                    case "5": e.CellStyle.BackColor = ColorTranslator.FromHtml("#E2EFDA"); break; // Verde (Énfasis 6) - Base Amarilla/Verde
                    case "6": e.CellStyle.BackColor = ColorTranslator.FromHtml("#E1D5E7"); break; // Lila/Púrpura - Base Roja/Azul
                    case "7": e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFC7CE"); break; // Rosa/Rojo (Alerta) - Base Roja
                    case "8": e.CellStyle.BackColor = ColorTranslator.FromHtml("#B7FAF4"); break; // Turquesa/Cian - Base Verde/Azul (Más vibrante)
                    case "9": e.CellStyle.BackColor = ColorTranslator.FromHtml("#F2DCDB"); break; // Marrón pálido / Salmón - Base Tierra
                    case "10": e.CellStyle.BackColor = ColorTranslator.FromHtml("#FBFFB3"); break; // Amarillo Canario - Base Amarilla pura
                }
            }
        }

        // ==========================================
        // --- CARGA DE DATOS ---
        // ==========================================

        public void CargarInventario()
        {
            string sql = @"SELECT GRUPO, MODELO, UBICACION, NSERIE, IP, N_MAQUINA, OBSERVACIONES 
                           FROM IMPRESORAS ORDER BY (CASE WHEN GRUPO IS NULL THEN 1 ELSE 0 END), GRUPO ASC, N_MAQUINA ASC";
            DataTable dt = db.ObtenerDatos(sql);
            if (dt != null)
            {
                dgvInventario.DataSource = dt;
                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void CargarHistorial()
        {
            try
            {
                // 1. Carga la tabla de HISTORIAL (Listado completo cronológico)
                // Usamos LEFT JOIN para traer el GRUPO desde la tabla de IMPRESORAS
                string sqlH = @"SELECT I.GRUPO, T.FECHA, T.NSERIE, T.MODELO, T.UBICACION, T.DESCRIPCION 
                        FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE 
                        ORDER BY T.FECHA DESC";
                dgvHistorial.DataSource = db.ObtenerDatos(sqlH);

                // 2. Carga la tabla de TOTALES (Estadísticas agrupadas)
                // Agrupa por máquina para contar pedidos y sacar la última fecha
                string sqlT = @"SELECT I.GRUPO, T.NSERIE, T.MODELO, COUNT(*) as [Total Pedidos], MAX(T.FECHA) as [Último] 
                        FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE 
                        GROUP BY I.GRUPO, T.NSERIE, T.MODELO 
                        ORDER BY I.GRUPO ASC, [Total Pedidos] DESC";
                dgvTotales.DataSource = db.ObtenerDatos(sqlT);

                // 3. Ajuste visual para que ocupen todo el ancho
                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //Mostrar error si falla la carga
                 MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        // ==========================================
        // --- EVENTOS PESTAÑAS Y EDICIÓN ---
        // ==========================================

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si vamos a la pestaña Historial/Totales (índice 2), recargamos
            if (tabControl1.SelectedIndex == 2) CargarHistorial();
        }

        private void dgvInventario_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // SI ESTAMOS EN MODO BORRADO, SALIMOS INMEDIATAMENTE
            if (isDeleting) return;

            if (dgvInventario.Rows[e.RowIndex].IsNewRow) return;

            var fila = dgvInventario.Rows[e.RowIndex];
            string nSerie = fila.Cells["NSERIE"].Value?.ToString();

            // Si no hay serie, no podemos guardar/identificar
            if (string.IsNullOrEmpty(nSerie)) return;

            string sql = @"IF EXISTS (SELECT 1 FROM IMPRESORAS WHERE NSERIE = @ser)
                           UPDATE IMPRESORAS SET N_MAQUINA=@n, UBICACION=@ubi, MODELO=@mod, IP=@ip, OBSERVACIONES=@obs, GRUPO=@grp WHERE NSERIE=@ser
                           ELSE
                           INSERT INTO IMPRESORAS (N_MAQUINA, UBICACION, MODELO, NSERIE, IP, OBSERVACIONES, GRUPO) 
                           VALUES (@n, @ubi, @mod, @ser, @ip, @obs, @grp)";

            SqlParameter[] p = {
                new SqlParameter("@n", fila.Cells["N_MAQUINA"].Value ?? 0),
                new SqlParameter("@ubi", fila.Cells["UBICACION"].Value ?? ""),
                new SqlParameter("@mod", fila.Cells["MODELO"].Value ?? ""),
                new SqlParameter("@ser", nSerie),
                new SqlParameter("@ip", fila.Cells["IP"].Value ?? ""),
                new SqlParameter("@obs", fila.Cells["OBSERVACIONES"].Value ?? (object)DBNull.Value),
                new SqlParameter("@grp", fila.Cells["GRUPO"].Value ?? (object)DBNull.Value)
            };
            db.EjecutarComando(sql, p);
        }

        // ==========================================
        // --- PESTAÑA SOLICITAR (PEDIDOS) ---
        // ==========================================

        private void btnMostrarGrupo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbGrupo.Text))
            {
                MessageBox.Show("Por favor, selecciona un grupo o 'Sin Grupo'");
                return;
            }

            string sql;
            SqlParameter[] p = null;

            if (cmbGrupo.Text == "Sin Grupo")
            {
                sql = "SELECT GRUPO, N_MAQUINA, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE (GRUPO IS NULL OR GRUPO = '') ";
            }
            else
            {
                sql = "SELECT GRUPO, N_MAQUINA, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO = @g AND MODELO LIKE '%4510%'";
                p = new SqlParameter[] { new SqlParameter("@g", cmbGrupo.Text) };
            }

            // Carga de datos
            dgvPedidoWeb.DataSource = db.ObtenerDatos(sql, p);

            // QUITAMOS LA SELECCIÓN AUTOMÁTICA
            dgvPedidoWeb.ClearSelection();
            dgvPedidoWeb.CurrentCell = null;
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidoWeb.Rows.Count == 0) return;

            // 1. Identificar filas a procesar
            // Si hay filas seleccionadas manualmente, usamos esas. Si no, usamos TODAS las visibles.
            List<DataGridViewRow> filasAProcesar = dgvPedidoWeb.SelectedRows.Count > 0
                ? dgvPedidoWeb.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvPedidoWeb.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow && r.Cells["NSERIE"].Value != null).ToList();

            string tipoConsumible = "";

            // 2. Lógica para "Sin Grupo" con botones personalizados
            if (cmbGrupo.Text.Trim().Equals("Sin Grupo", StringComparison.OrdinalIgnoreCase))
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Seleccionar Consumible",
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                Label textLabel = new Label() { Left = 20, Top = 20, Width = 250, Text = "Selecciona el tipo de pedido:" };
                Button btnKit = new Button() { Text = "KIT", Left = 40, Width = 80, Top = 60, DialogResult = DialogResult.Yes };
                Button btnTambor = new Button() { Text = "TAMBOR", Left = 160, Width = 80, Top = 60, DialogResult = DialogResult.No };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(btnKit);
                prompt.Controls.Add(btnTambor);
                prompt.AcceptButton = btnKit;

                DialogResult res = prompt.ShowDialog();

                if (res == DialogResult.Yes) tipoConsumible = "KIT";
                else if (res == DialogResult.No) tipoConsumible = "TAMBOR";
                else return; // Si cierra la ventana sin elegir
            }
            else
            {
                tipoConsumible = "TAMBOR";
            }

            // 3. Confirmación Final
            string modo = dgvPedidoWeb.SelectedRows.Count > 0 ? "seleccionadas" : "de la lista completa";
            if (MessageBox.Show($"¿Registrar {filasAProcesar.Count} máquinas {modo} como '{tipoConsumible}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow fila in filasAProcesar)
                    {
                        string nserie = fila.Cells["NSERIE"].Value?.ToString();
                        if (string.IsNullOrEmpty(nserie)) continue;

                        string sql = "INSERT INTO TAMBORES (MODELO, NSERIE, UBICACION, DESCRIPCION, FECHA) VALUES (@mod, @ser, @ubi, @desc, GETDATE())";
                        SqlParameter[] p = {
                            new SqlParameter("@mod", fila.Cells["MODELO"].Value?.ToString() ?? ""),
                            new SqlParameter("@ser", nserie),
                            new SqlParameter("@ubi", fila.Cells["UBICACION"].Value?.ToString() ?? ""),
                            new SqlParameter("@desc", tipoConsumible)
                        };
                        db.EjecutarComando(sql, p);
                    }

                    CargarHistorial();
                    dgvPedidoWeb.DataSource = null; // Limpiamos el grid para confirmar visualmente
                    MessageBox.Show("Registros guardados con éxito.");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // ==========================================
        // --- BOTONES EXTRAS ---
        // ==========================================

        private void btnCargarHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string nuevaImpresora = MostrarPromptNuevo();

            // Si nuevaImpresora no es null, significa que se guardó bien
            if (nuevaImpresora != null)
            {
                CargarInventario(); // Recarga la tabla para ver la nueva fila
                MessageBox.Show($"La impresora {nuevaImpresora} se ha registrado correctamente.");
            }
        }

        // ==========================================
        // --- FORMULARIO DE NUEVA IMPRESORA ---
        // ==========================================

        private string MostrarPromptNuevo()
        {
            // 1. CARGA PREVIA DE IPs PARA COMPROBACIÓN RÁPIDA
            List<string> ipsOcupadas = new List<string>();
            DataTable dtIps = db.ObtenerDatos("SELECT IP FROM IMPRESORAS WHERE IP IS NOT NULL");
            foreach (DataRow row in dtIps.Rows)
            {
                ipsOcupadas.Add(row["IP"].ToString().Trim().ToUpper());
            }

            // 2. CONFIGURACIÓN DE LA VENTANA
            Form prompt = new Form()
            {
                Width = 500,
                Height = 600,
                Text = "Alta de Nueva Impresora",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // --- CONTROLES ---
            Label lblNum = new Label() { Left = 20, Top = 20, Text = "Nº Máquina (0-255):", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            NumericUpDown txtNum = new NumericUpDown() { Left = 20, Top = 40, Width = 380, Maximum = 255, TextAlign = HorizontalAlignment.Right };

            Label lblUbi = new Label() { Left = 20, Top = 80, Text = "Ubicación:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtUbi = new TextBox() { Left = 20, Top = 100, Width = 380, MaxLength = 50, CharacterCasing = CharacterCasing.Upper };

            Label lblMod = new Label() { Left = 20, Top = 140, Text = "Modelo:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtMod = new TextBox() { Left = 20, Top = 160, Width = 380, MaxLength = 50, CharacterCasing = CharacterCasing.Upper };

            Label lblSer = new Label() { Left = 20, Top = 200, Text = "Nº Serie (Obligatorio):", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtSer = new TextBox() { Left = 20, Top = 220, Width = 380, MaxLength = 30, CharacterCasing = CharacterCasing.Upper };

            Label lblIp = new Label() { Left = 20, Top = 260, Text = "Dirección IP:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtIp = new TextBox() { Left = 20, Top = 280, Width = 250, MaxLength = 15 };

            // Etiqueta de aviso visual
            Label lblAvisoIp = new Label() { Left = 280, Top = 282, Width = 200, Text = "", Font = new Font("Segoe UI", 8, FontStyle.Bold) };

            Label lblObs = new Label() { Left = 20, Top = 320, Text = "Observaciones (Opcional):", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtObs = new TextBox() { Left = 20, Top = 340, Width = 380, MaxLength = 40, CharacterCasing = CharacterCasing.Upper };

            Label lblGrp = new Label() { Left = 20, Top = 380, Text = "Grupo (0 = Sin Grupo):", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            NumericUpDown txtGrp = new NumericUpDown() { Left = 20, Top = 400, Width = 380, Minimum = 0, Maximum = 100, TextAlign = HorizontalAlignment.Right };

            Button btnGuardar = new Button() { Text = "Guardar", Left = 200, Width = 90, Top = 480, BackColor = Color.LightGreen, Height = 35 };
            Button btnCancel = new Button() { Text = "Cancelar", Left = 310, Width = 90, Top = 480, DialogResult = DialogResult.Cancel, Height = 35 };

            prompt.Controls.AddRange(new Control[] { lblNum, txtNum, lblUbi, txtUbi, lblMod, txtMod, lblSer, txtSer, lblIp, txtIp, lblAvisoIp, lblObs, txtObs, lblGrp, txtGrp, btnGuardar, btnCancel });
            prompt.AcceptButton = btnGuardar;
            prompt.CancelButton = btnCancel;

            // --- VALIDACIÓN VISUAL EN TIEMPO REAL ---
            txtIp.TextChanged += (sender, e) =>
            {
                string ipActual = txtIp.Text.Trim();
                System.Net.IPAddress tempIp;

                if (string.IsNullOrEmpty(ipActual))
                {
                    lblAvisoIp.Text = "";
                    txtIp.BackColor = Color.White;
                }
                else if (!System.Net.IPAddress.TryParse(ipActual, out tempIp) || ipActual.Split('.').Length != 4)
                {
                    // Si NO es formato IP válido (ej: "10.204." o texto)
                    lblAvisoIp.Text = "⚠️ IP INCORRECTA";
                    lblAvisoIp.ForeColor = Color.OrangeRed;
                    txtIp.BackColor = Color.OldLace;
                }
                else if (ipsOcupadas.Contains(ipActual.ToUpper()))
                {
                    // Si formato bien, pero YA EXISTE
                    lblAvisoIp.Text = "❌ OCUPADA";
                    lblAvisoIp.ForeColor = Color.Red;
                    txtIp.BackColor = Color.MistyRose;
                }
                else
                {
                    // Todo OK
                    lblAvisoIp.Text = "✔ DISPONIBLE";
                    lblAvisoIp.ForeColor = Color.Green;
                    txtIp.BackColor = Color.Honeydew;
                }
            };

            // --- BOTÓN GUARDAR ---
            btnGuardar.Click += (sender, e) =>
            {
                string nserie = txtSer.Text.Trim().ToUpper();
                string ubicacion = txtUbi.Text.Trim().ToUpper();
                string modelo = txtMod.Text.Trim().ToUpper();
                string ip = txtIp.Text.Trim().ToUpper();
                string obs = txtObs.Text.Trim().ToUpper();

                // 1. Validar vacíos obligatorios
                if (string.IsNullOrEmpty(nserie) || string.IsNullOrEmpty(ubicacion) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("Faltan datos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Validar FORMATO de IP
                System.Net.IPAddress validarIp;
                if (!System.Net.IPAddress.TryParse(ip, out validarIp) || ip.Split('.').Length != 4)
                {
                    MessageBox.Show($"El valor '{ip}' no es una dirección IP válida (Ej: 192.168.1.10).", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIp.Focus();
                    return;
                }

                // 3. Validar Duplicados de IP
                if (ipsOcupadas.Contains(ip))
                {
                    MessageBox.Show($"La IP {ip} ya está en uso. Revisa el indicador rojo.", "IP Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Validar Duplicado de SERIE en BD (por seguridad final)
                DataTable dtSer = db.ObtenerDatos("SELECT IP FROM IMPRESORAS WHERE NSERIE = @s", new SqlParameter[] { new SqlParameter("@s", nserie) });
                if (dtSer.Rows.Count > 0)
                {
                    MessageBox.Show($"El número de serie {nserie} ya existe.", "Serie Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 5. Guardar
                string sqlInsert = @"INSERT INTO IMPRESORAS (N_MAQUINA, UBICACION, MODELO, NSERIE, IP, OBSERVACIONES, GRUPO) VALUES (@n, @u, @m, @s, @i, @o, @g)";
                SqlParameter[] p = {
                    new SqlParameter("@n", (byte)txtNum.Value),
                    new SqlParameter("@u", ubicacion),
                    new SqlParameter("@m", modelo),
                    new SqlParameter("@s", nserie),
                    new SqlParameter("@i", ip),
                    new SqlParameter("@o", string.IsNullOrEmpty(obs) ? (object)DBNull.Value : obs),
                    new SqlParameter("@g", txtGrp.Value == 0 ? (object)DBNull.Value : (int)txtGrp.Value)
                };

                try
                {
                    db.EjecutarComando(sqlInsert, p);
                    prompt.DialogResult = DialogResult.OK; // Cerrar ventana si todo salió bien
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            };

            if (prompt.ShowDialog() == DialogResult.OK) return txtSer.Text.ToUpper();
            return null;
        }
    }
}