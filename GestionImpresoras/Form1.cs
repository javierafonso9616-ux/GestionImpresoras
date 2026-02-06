using GestionImpresoras.DatosImpresoras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel; // Necesario para el Excel

namespace GestionImpresoras
{
    public partial class Form1 : Form
    {
        AccesoDatos db = new AccesoDatos();
        bool isDeleting = false;

        public Form1()
        {
            InitializeComponent();
            ConfigurarGrids();
        }

        private void ConfigurarGrids()
        {
            // INVENTARIO
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.RowValidated += dgvInventario_RowValidated;
            dgvInventario.CellFormatting += AplicarColoresGrupo;
            dgvInventario.KeyDown += Grids_KeyDown;

            // PEDIDO WEB
            dgvPedidoWeb.ReadOnly = true;
            dgvPedidoWeb.AllowUserToAddRows = false;
            dgvPedidoWeb.AllowUserToDeleteRows = false;
            dgvPedidoWeb.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidoWeb.MultiSelect = true;
            dgvPedidoWeb.CellFormatting += AplicarColoresGrupo;
            dgvPedidoWeb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidoWeb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // HISTORIAL
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.CellFormatting += AplicarColoresGrupo;
            dgvHistorial.KeyDown += Grids_KeyDown;

            // TOTALES
            dgvTotales.ReadOnly = true;
            dgvTotales.AllowUserToAddRows = false;
            dgvTotales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotales.MultiSelect = false;
            dgvTotales.CellFormatting += AplicarColoresGrupo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarInventario();
            CargarHistorial();
        }

        // ==========================================
        // --- GESTIÓN DE COLORES (TUS CÓDIGOS HEX) ---
        // ==========================================
        private Color ObtenerColorPorGrupo(string grupo)
        {
            if (string.IsNullOrEmpty(grupo)) return Color.White;

            switch (grupo)
            {
                case "1": return ColorTranslator.FromHtml("#FCE4D6");
                case "2": return ColorTranslator.FromHtml("#EDEDED");
                case "3": return ColorTranslator.FromHtml("#FFF2CC");
                case "4": return ColorTranslator.FromHtml("#D9E1F2");
                case "5": return ColorTranslator.FromHtml("#E2EFDA");
                case "6": return ColorTranslator.FromHtml("#E1D5E7");
                case "7": return ColorTranslator.FromHtml("#FFC7CE");
                case "8": return ColorTranslator.FromHtml("#B7FAF4");
                case "9": return ColorTranslator.FromHtml("#F2DCDB");
                case "10": return ColorTranslator.FromHtml("#FBFFB3");
                default: return Color.White;
            }
        }

        private void AplicarColoresGrupo(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "GRUPO" && e.Value != null)
            {
                e.CellStyle.BackColor = ObtenerColorPorGrupo(e.Value.ToString());
            }
        }

        // ==========================================
        // --- EXPORTACIÓN A EXCEL (PERSONALIZADA) ---
        // ==========================================

        private void btnExcel_Click(object sender, EventArgs e)
        {
            int indicePestana = tabControl1.SelectedIndex;

            switch (indicePestana)
            {
                case 0: // Inventario
                    // Nombre fijo para inventario
                    ExportarAExcel(dgvInventario, "InventarioImpresora");
                    break;

                case 1: // Solicitar (Pedidos)
                    if (dgvPedidoWeb.Rows.Count > 0)
                    {
                        // Lógica para el nombre dinámico del grupo
                        string grupoSeleccionado = cmbGrupo.Text.Trim();
                        string nombreArchivo;

                        if (grupoSeleccionado.Equals("Sin Grupo", StringComparison.OrdinalIgnoreCase))
                        {
                            nombreArchivo = "PedidosGrupoSinGrupo";
                        }
                        else
                        {
                            // "PedidosGrupo" + el número o nombre del grupo
                            nombreArchivo = "PedidosGrupo" + grupoSeleccionado;
                        }

                        ExportarAExcel(dgvPedidoWeb, nombreArchivo);
                    }
                    else
                    {
                        MessageBox.Show("La tabla de pedidos está vacía.");
                    }
                    break;

                case 2: // Historial / Totales
                    PreguntarYExportarHistorial();
                    break;

                default:
                    MessageBox.Show("No hay tabla para exportar aquí.");
                    break;
            }
        }

        private void PreguntarYExportarHistorial()
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 180,
                Text = "Exportar a Excel",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label() { Left = 20, Top = 20, Width = 300, Text = "¿Qué tabla desea exportar?" };
            Button btnHist = new Button() { Text = "Historial Completo", Left = 30, Top = 50, Width = 280, DialogResult = DialogResult.Yes, BackColor = Color.AliceBlue };
            Button btnTot = new Button() { Text = "Resumen de Totales", Left = 30, Top = 90, Width = 280, DialogResult = DialogResult.No, BackColor = Color.AliceBlue };

            prompt.Controls.AddRange(new Control[] { lbl, btnHist, btnTot });

            DialogResult res = prompt.ShowDialog();

            // Dependiendo de la elección, exportamos el DataGridView correspondiente con un nombre adecuado.
            if (res == DialogResult.Yes)
                ExportarAExcel(dgvHistorial, "InventarioImpresorasHistorico");
            else if (res == DialogResult.No)
                ExportarAExcel(dgvTotales, "InventarioImpresorasTotalesPedidos");
        }

        // ESTE MÉTODO SE ENCARGA DE EXPORTAR CUALQUIER DataGridView A EXCEL CON FORMATO PERSONALIZADO
        private void ExportarAExcel(DataGridView grid, string nombreBase)
        {
            if (grid.Rows.Count == 0) { MessageBox.Show("No hay datos."); return; }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";

            // Construimos el nombre: NombreBase + "_" + FechaHoraSegundos
            sfd.FileName = $"{nombreBase}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Datos");

                        // 1. Cabeceras
                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            var celda = worksheet.Cell(1, i + 1);
                            celda.Value = grid.Columns[i].HeaderText;
                            celda.Style.Font.Bold = true;
                            celda.Style.Fill.BackgroundColor = XLColor.LightGray;
                            celda.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // 2. Datos y COLORES
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            if (grid.Rows[i].IsNewRow) continue;

                            for (int j = 0; j < grid.Columns.Count; j++)
                            {
                                var valor = grid.Rows[i].Cells[j].Value?.ToString() ?? "";
                                var celdaExcel = worksheet.Cell(i + 2, j + 1);
                                celdaExcel.Value = valor;

                                // --- COLORES ---
                                if (grid.Columns[j].Name == "GRUPO")
                                {
                                    Color c = ObtenerColorPorGrupo(valor);
                                    if (c != Color.White)
                                    {
                                        celdaExcel.Style.Fill.BackgroundColor = XLColor.FromColor(c);
                                    }
                                }
                            }
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Exportado correctamente. ✔");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }


        // ==========================================
        // --- BORRADO (SUPR) ---
        // ==========================================
        private void Grids_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridView grid = (DataGridView)sender;
                int seleccionados = grid.SelectedRows.Count;
                if (seleccionados == 0) return;

                isDeleting = true; // Bloqueamos guardado
                string msg = seleccionados == 1 ? "¿Borrar registro?" : $"¿Borrar {seleccionados} registros?";

                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow fila in grid.SelectedRows)
                        {
                            if (fila.IsNewRow) continue;
                            string nSerie = fila.Cells["NSERIE"].Value?.ToString();

                            if (grid.Name == "dgvInventario")
                                db.EjecutarComando("DELETE FROM IMPRESORAS WHERE NSERIE = @s", new SqlParameter[] { new SqlParameter("@s", nSerie) });
                            else if (grid.Name == "dgvHistorial")
                            {
                                DateTime f = Convert.ToDateTime(fila.Cells["FECHA"].Value);
                                db.EjecutarComando("DELETE FROM TAMBORES WHERE NSERIE = @s AND FECHA = @f", new SqlParameter[] { new SqlParameter("@s", nSerie), new SqlParameter("@f", f) });
                            }
                        }
                        CargarInventario();
                        CargarHistorial();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
                isDeleting = false; // Desbloqueamos
            }
        }

        // ==========================================
        // --- CARGA DE DATOS ---
        // ==========================================
        public void CargarInventario()
        {
            string sql = "SELECT GRUPO, MODELO, UBICACION, NSERIE, IP, OBSERVACIONES FROM IMPRESORAS ORDER BY (CASE WHEN GRUPO IS NULL THEN 1 ELSE 0 END), GRUPO ASC";
            DataTable dt = db.ObtenerDatos(sql);

            if (dt != null)
            {
                dgvInventario.DataSource = dt;

               

                // 1. Desactivamos el ajuste automático global para tener control manual
                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // 2. Configuramos columna por columna
                foreach (DataGridViewColumn col in dgvInventario.Columns)
                {
                    if (col.Name == "OBSERVACIONES")
                    {
                        // Esta columna ocupará todo el espacio libre restante
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        // Opcional: Establecer un ancho mínimo para que no desaparezca si la pantalla es pequeña
                        col.MinimumWidth = 100;
                    }
                    else
                    {
                        // El resto se ajustan exactamente al tamaño de su texto (incluyendo la cabecera)
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
        }

        // ESTE MÉTODO CARGA LOS DATOS DE LOS TÁMBORES PEDIDOS Y LOS AGRUPA POR IMPRESORA
        // PARA MOSTRAR UN HISTORIAL DETALLADO Y UN RESUMEN DE PEDIDOS POR MODELO.
        public void CargarHistorial()
        {
            try
            {
                string sqlH = "SELECT I.GRUPO, T.FECHA, T.NSERIE, T.MODELO, T.UBICACION, T.DESCRIPCION FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE ORDER BY T.FECHA DESC";
                dgvHistorial.DataSource = db.ObtenerDatos(sqlH);

                string sqlT = "SELECT I.GRUPO, T.NSERIE, T.MODELO, COUNT(*) as [Total Pedidos], MAX(T.FECHA) as [Último] FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE GROUP BY I.GRUPO, T.NSERIE, T.MODELO ORDER BY I.GRUPO ASC, [Total Pedidos] DESC";
                dgvTotales.DataSource = db.ObtenerDatos(sqlT);

                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { }
        }

        // ==========================================
        // --- EVENTOS PESTAÑAS Y EDICIÓN ---
        // ==========================================
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) CargarHistorial();
        }

        // ESTE MÉTODO SE EJECUTA CUANDO SE TERMINA DE EDITAR UNA FILA EN EL INVENTARIO,
        // Y SE ENCARGA DE INSERTAR O ACTUALIZAR EN LA BASE DE DATOS SEGÚN CORRESPONDA.
        private void dgvInventario_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (isDeleting || dgvInventario.Rows[e.RowIndex].IsNewRow) return;

            var fila = dgvInventario.Rows[e.RowIndex];
            string nSerie = fila.Cells["NSERIE"].Value?.ToString();
            if (string.IsNullOrEmpty(nSerie)) return;

            string sql = @"IF EXISTS (SELECT 1 FROM IMPRESORAS WHERE NSERIE = @s)
                           UPDATE IMPRESORAS SET UBICACION=@u, MODELO=@m, IP=@i, OBSERVACIONES=@o, GRUPO=@g WHERE NSERIE=@s
                           ELSE
                           INSERT INTO IMPRESORAS (UBICACION, MODELO, NSERIE, IP, OBSERVACIONES, GRUPO) VALUES (@u, @m, @s, @i, @o, @g)";

            SqlParameter[] p = {
                new SqlParameter("@u", fila.Cells["UBICACION"].Value ?? ""),
                new SqlParameter("@m", fila.Cells["MODELO"].Value ?? ""),
                new SqlParameter("@s", nSerie),
                new SqlParameter("@i", fila.Cells["IP"].Value ?? ""),
                new SqlParameter("@o", fila.Cells["OBSERVACIONES"].Value ?? (object)DBNull.Value),
                new SqlParameter("@g", fila.Cells["GRUPO"].Value ?? (object)DBNull.Value)
            };
            db.EjecutarComando(sql, p);
        }

        // ==========================================
        // --- PESTAÑA SOLICITAR ---
        // ==========================================
        private void btnMostrarGrupo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbGrupo.Text)) { MessageBox.Show("Seleccione un grupo para mostrar."); return; }
            string sql; SqlParameter[] p = null;

            if (cmbGrupo.Text == "Sin Grupo") sql = "SELECT GRUPO, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO IS NULL OR GRUPO = ''";
            else { sql = "SELECT GRUPO, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO = @g AND MODELO LIKE '%4510%'"; p = new SqlParameter[] { new SqlParameter("@g", cmbGrupo.Text) }; }

            dgvPedidoWeb.DataSource = db.ObtenerDatos(sql, p);
            dgvPedidoWeb.ClearSelection(); dgvPedidoWeb.CurrentCell = null;
        }

        // ESTE MÉTODO REGISTRA LOS PEDIDOS SELECCIONADOS EN LA BASE DE DATOS,
        // PIDIENDO CONFIRMACIÓN Y EL TIPO (KIT O TAMBOR) SI NO HAY GRUPO ASIGNADO.
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidoWeb.Rows.Count == 0) return;

            // 1. Detectamos qué filas procesar (las seleccionadas o todas las visibles)
            List<DataGridViewRow> filas = dgvPedidoWeb.SelectedRows.Count > 0
                ? dgvPedidoWeb.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvPedidoWeb.Rows.Cast<DataGridViewRow>().Where(re => !re.IsNewRow && re.Cells["NSERIE"].Value != null).ToList();

            if (filas.Count == 0) return;

            // 2. SIEMPRE preguntamos si es KIT o TAMBOR 
            string tipo = "";

            Form p = new Form()
            {
                Width = 300,
                Height = 160,
                Text = "Seleccionar Tipo",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label() { Left = 20, Top = 15, Width = 250, Text = "¿Qué consumible deseas solicitar?" };
            Button bK = new Button() { Text = "KIT", Left = 40, Top = 50, Width = 90, Height = 35, DialogResult = DialogResult.Yes, BackColor = Color.LightYellow };
            Button bT = new Button() { Text = "TAMBOR", Left = 150, Top = 50, Width = 90, Height = 35, DialogResult = DialogResult.No, BackColor = Color.LightCyan };

            p.Controls.AddRange(new Control[] { lbl, bK, bT });

            DialogResult r = p.ShowDialog();

            if (r == DialogResult.Yes) tipo = "KIT";
            else if (r == DialogResult.No) tipo = "TAMBOR";
            else return; // Si cierra la ventana sin elegir, cancelamos todo

            // 3. Confirmación final y Guardado
            if (MessageBox.Show($"¿Registrar {filas.Count} pedidos de '{tipo}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow f in filas)
                    {
                        string sql = "INSERT INTO TAMBORES (MODELO, NSERIE, UBICACION, DESCRIPCION, FECHA) VALUES (@m, @s, @u, @d, GETDATE())";
                        SqlParameter[] param = {
                    new SqlParameter("@m", f.Cells["MODELO"].Value?.ToString() ?? ""),
                    new SqlParameter("@s", f.Cells["NSERIE"].Value.ToString()),
                    new SqlParameter("@u", f.Cells["UBICACION"].Value?.ToString() ?? ""),
                    new SqlParameter("@d", tipo)
                };
                        db.EjecutarComando(sql, param);
                    }

                    CargarHistorial();
                    dgvPedidoWeb.DataSource = null; // Limpiamos para indicar que se ha procesado
                    MessageBox.Show("Pedidos registrados correctamente.");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }



        private void btnCargarHistorial_Click(object sender, EventArgs e) { CargarHistorial(); } // Botón para recargar el historial manualmente

        // ==========================================
        // --- NUEVA IMPRESORA (VENTANA EMERGENTE) ---
        // ==========================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string n = MostrarPromptNuevo();
            if (n != null) { CargarInventario(); MessageBox.Show($"Registrado: {n}"); }
        }

        // ESTE MÉTODO CREA UNA VENTANA EMERGENTE PARA INGRESAR LOS DATOS DE UNA NUEVA
        // IMPRESORA, CON VALIDACIONES EN TIEMPO REAL PARA LA IP Y VERIFICACIÓN DE SERIE EXISTENTE.
        // SI TODO ES CORRECTO, INSERTA EN LA BASE DE DATOS Y DEVUELVE EL NÚMERO DE SERIE REGISTRADO.
        private string MostrarPromptNuevo()
        {
            List<string> ips = new List<string>();
            foreach (DataRow r in db.ObtenerDatos("SELECT IP FROM IMPRESORAS WHERE IP IS NOT NULL").Rows) ips.Add(r["IP"].ToString().Trim().ToUpper());

            Form p = new Form() { Width = 500, Height = 520, Text = "Nueva Impresora", StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false };

            Label lUb = new Label() { Left = 20, Top = 20, Text = "Ubicación:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox tUb = new TextBox() { Left = 20, Top = 40, Width = 380, MaxLength = 50, CharacterCasing = CharacterCasing.Upper };
            Label lMo = new Label() { Left = 20, Top = 80, Text = "Modelo:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox tMo = new TextBox() { Left = 20, Top = 100, Width = 380, MaxLength = 50, CharacterCasing = CharacterCasing.Upper };
            Label lSe = new Label() { Left = 20, Top = 140, Text = "Serie (Obligatorio):", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox tSe = new TextBox() { Left = 20, Top = 160, Width = 380, MaxLength = 30, CharacterCasing = CharacterCasing.Upper };
            Label lIp = new Label() { Left = 20, Top = 200, Text = "IP:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox tIp = new TextBox() { Left = 20, Top = 220, Width = 250, MaxLength = 15 };
            Label lAv = new Label() { Left = 280, Top = 222, Width = 200, Font = new Font("Segoe UI", 8, FontStyle.Bold) };
            Label lOb = new Label() { Left = 20, Top = 260, Text = "Observaciones:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox tOb = new TextBox() { Left = 20, Top = 280, Width = 380, MaxLength = 40, CharacterCasing = CharacterCasing.Upper };
            Label lGr = new Label() { Left = 20, Top = 320, Text = "Grupo:", Width = 380, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            NumericUpDown nGr = new NumericUpDown() { Left = 20, Top = 340, Width = 380, Maximum = 100 };

            Button bG = new Button() { Text = "Guardar", Left = 200, Top = 400, BackColor = Color.LightGreen, DialogResult = DialogResult.None };
            Button bC = new Button() { Text = "Cancelar", Left = 310, Top = 400, DialogResult = DialogResult.Cancel };

            p.Controls.AddRange(new Control[] { lUb, tUb, lMo, tMo, lSe, tSe, lIp, tIp, lAv, lOb, tOb, lGr, nGr, bG, bC });
            p.AcceptButton = bG; p.CancelButton = bC;

            tIp.TextChanged += (s, e) =>
            {
                string i = tIp.Text.Trim();
                if (string.IsNullOrEmpty(i)) { lAv.Text = ""; tIp.BackColor = Color.White; }
                else if (!System.Net.IPAddress.TryParse(i, out _) || i.Split('.').Length != 4) { lAv.Text = "⚠️ IP INCORRECTA"; lAv.ForeColor = Color.OrangeRed; tIp.BackColor = Color.OldLace; }
                else if (ips.Contains(i.ToUpper())) { lAv.Text = "❌ OCUPADA"; lAv.ForeColor = Color.Red; tIp.BackColor = Color.MistyRose; }
                else { lAv.Text = "✔ DISPONIBLE"; lAv.ForeColor = Color.Green; tIp.BackColor = Color.Honeydew; }
            };

            bG.Click += (s, e) =>
            {
                string se = tSe.Text.Trim().ToUpper(), ub = tUb.Text.Trim().ToUpper(), mo = tMo.Text.Trim().ToUpper(), ip = tIp.Text.Trim().ToUpper();
                if (string.IsNullOrEmpty(se) || string.IsNullOrEmpty(ub) || string.IsNullOrEmpty(mo) || string.IsNullOrEmpty(ip)) { MessageBox.Show("Faltan datos."); return; }
                if (ips.Contains(ip)) { MessageBox.Show("IP Ocupada."); return; }
                if (!System.Net.IPAddress.TryParse(ip, out _) || ip.Split('.').Length != 4) { MessageBox.Show("IP Incorrecta."); return; }
                if (db.ObtenerDatos("SELECT IP FROM IMPRESORAS WHERE NSERIE=@s", new SqlParameter[] { new SqlParameter("@s", se) }).Rows.Count > 0) { MessageBox.Show("Serie existe."); return; }

                string sql = "INSERT INTO IMPRESORAS (UBICACION, MODELO, NSERIE, IP, OBSERVACIONES, GRUPO) VALUES (@u, @m, @s, @i, @o, @g)";
                SqlParameter[] pa = {
                    new SqlParameter("@u", ub), new SqlParameter("@m", mo), new SqlParameter("@s", se), new SqlParameter("@i", ip),
                    new SqlParameter("@o", string.IsNullOrEmpty(tOb.Text) ? (object)DBNull.Value : tOb.Text.ToUpper()),
                    new SqlParameter("@g", nGr.Value == 0 ? (object)DBNull.Value : (int)nGr.Value)
                };
                try { db.EjecutarComando(sql, pa); p.DialogResult = DialogResult.OK; } catch (Exception ex) { MessageBox.Show(ex.Message); }
            };

            if (p.ShowDialog() == DialogResult.OK) return tSe.Text.ToUpper();
            return null;
        }
    }
}