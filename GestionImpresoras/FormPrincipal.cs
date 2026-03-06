using ClosedXML.Excel;
using GestionImpresoras.DatosImpresoras;
using GestionIP.Clases;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionImpresoras
{
    public partial class FormPrincipal : MaterialForm
    {
        // INSTANCIA DE LA CLASE DE ACCESO A DATOS
        AccesoDatos db = new AccesoDatos();

        // BANDERA PARA CONTROLAR CUANDO SE ESTÁN BORRANDO FILAS Y EVITAR QUE SE EJECUTEN LOS EVENTOS DE VALIDACIÓN DE FILA
        bool isDeleting = false;

        // BANDERA PARA CONTROLAR EL AVISO DE SELECCIÓN DE GRUPO EN LA PESTAÑA DE PEDIDOS, ASÍ SOLO SE MUESTRA UNA VEZ
        bool avisoPedidosMostrado = false;

        // -----------------------------------------------------------------------------------
        // CONSTRUCTOR
        // -----------------------------------------------------------------------------------
        public FormPrincipal()
        {
            InitializeComponent();
            GestorTema.ConfigurarMaterialSkin(this);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; // EVITA QUE SE SOLAPE CON LA BARRA DE TAREAS AL MAXIMIZAR
        }

        //-----------------------------------------------------------------------------------
        // EVENTO LOAD (CARGA EL FORMULARIO)
        //-----------------------------------------------------------------------------------
        private void Form2_Load(object sender, EventArgs e)
        {
            CargarInventario();
            CargarHistorial(); // historial y totales se cargan juntos porque comparten datos

            // Limpiamos los buscadores por si acaso
            txtBuscarInventario.Text = "";

            RellenarcmbGrupo();
            ConfigurarGrids();
        }

        //-----------------------------------------------------------------------------------
        // CONFIGURACIONES INICIALES
        //-----------------------------------------------------------------------------------

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

            // configuraciones generales de estilo para todos los grids
            AplicarEstilosVarios(dgvInventario, dgvPedidoWeb, dgvHistorial, dgvTotales);
        }

        private void AplicarEstilosGrid(DataGridView grid)
        {
            Color azulOscuro = Color.FromArgb(13, 71, 161);
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 230, 230);
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = azulOscuro;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);// FUENTE ENCABEZADOS
            grid.ColumnHeadersHeight = 40;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 12); // FUENTE CELDAS
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.RowHeadersVisible = false;

            if (grid.Columns.Contains("GRUPO"))
            {
                grid.Columns["GRUPO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grid.Columns["GRUPO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void AplicarEstilosVarios(params DataGridView[] grids)
        {
            foreach (var grid in grids)
            {
                AplicarEstilosGrid(grid);
            }
        }

        private void RellenarcmbGrupo()
        {
            // OBTENEMOS LOS GRUPOS DISTINTOS DE LA BASE DE DATOS, EXCLUYENDO LOS NULOS Y VACÍOS, Y LOS ORDENAMOS ALFABÉTICAMENTE

            DataTable dt = db.ObtenerDatos("SELECT DISTINCT GRUPO FROM IMPRESORAS WHERE GRUPO IS NOT NULL AND GRUPO <> '' ORDER BY GRUPO");
            cmbGrupo.Items.Clear();
            cmbGrupo.Items.Add("Sin Grupo");
            foreach (DataRow r in dt.Rows) cmbGrupo.Items.Add(r["GRUPO"].ToString());

            // FORZAMOS A QUE NO HAYA NINGUNA OPCIÓN SELECCIONADA AL INICIO, ASÍ SE MUESTRA EL AVISO DE SELECCIÓN DE GRUPO EN LA PESTAÑA DE PEDIDOS
            cmbGrupo.SelectedIndex = -1;
        }

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
            // APLICAMOS LOS COLORES DE FONDO SEGÚN EL GRUPO, SOLO SI LA COLUMNA ES "GRUPO" Y EL VALOR NO ES NULO
            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "GRUPO" && e.Value != null)
            {
                e.CellStyle.BackColor = ObtenerColorPorGrupo(e.Value.ToString());
            }
        }


        //-----------------------------------------------------------------------------------
        // BOTONES
        //-----------------------------------------------------------------------------------

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // OBTENEMOS EN QUE PESTAÑA ESTAMOS
            int indicePestana = tabControl1.SelectedIndex;


            switch (indicePestana)
            {
                case 0: // INVENTARIO
                    ExportarAExcel(dgvInventario, "InventarioImpresora");
                    break;

                case 1: // PEDIDOS
                    if (dgvPedidoWeb.Rows.Count > 0)
                    {
                        string grupoSeleccionado = cmbGrupo.Text.Trim();
                        string nombreArchivo = grupoSeleccionado.Equals("Sin Grupo", StringComparison.OrdinalIgnoreCase)
                            ? "PedidosGrupoSinGrupo"
                            : "PedidosGrupo" + grupoSeleccionado;

                        ExportarAExcel(dgvPedidoWeb, nombreArchivo);
                    }
                    else
                    {
                        new MaterialSnackBar("La tabla de pedidos está vacía.", "OK", true).Show(this);
                    }
                    break;

                case 2: // HISTORIAL Y TOTALES
                    PreguntarYExportarHistorial();
                    break;

                default:
                    new MaterialSnackBar("No hay tabla para exportar aquí.", "OK", true).Show(this);
                    break;
            }

            // LIMPIAMOS BUSCADORES
            txtBuscarSerie.Text = "";
            txtBuscarInventario.Text = "";
            txtBuscarHistorial.Text = "";
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            // SI NO HAY REGISTROS SALE
            if (dgvPedidoWeb.Rows.Count == 0) return;


            List<DataGridViewRow> filas = dgvPedidoWeb.SelectedRows.Count > 0
                ? dgvPedidoWeb.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvPedidoWeb.Rows.Cast<DataGridViewRow>().Where(re => !re.IsNewRow && re.Cells["NSERIE"].Value != null).ToList();

            if (filas.Count == 0) return;

            string tipo = "";

            // CREAMOS UN  NUEVO FORM MATERIALSKIN2 PARA LA VENTANITA 
            MaterialForm p = new MaterialForm()
            {
                Width = 350,
                Height = 220,
                Text = "Seleccionar Tipo",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Sizable = false
            };

            // APLICAMOS ESTILOS
            GestorTema.ConfigurarMaterialSkin(p);

            // LABEL DEL TITULO CENTRADO
            MaterialLabel lbl = new MaterialLabel() { Left = 25, Top = 85, Width = 300, Text = "¿Qué consumible deseas solicitar?" };

            // BOTONES
            MaterialButton bK = new MaterialButton() { Text = "SOLICITAR KIT", Left = 40, Top = 140, DialogResult = DialogResult.Yes };
            MaterialButton bT = new MaterialButton() { Text = "SOLICITAR TAMBOR", Left = 175, Top = 140, DialogResult = DialogResult.No };

            // AGREGA LOS CONTROLES
            p.Controls.AddRange(new Control[] { lbl, bK, bT });

            // GUARDAMOS LA RESPUESTA SI/NO
            DialogResult r = p.ShowDialog();

            // SI PARA KIT / NO PARA TAMBOR
            if (r == DialogResult.Yes) tipo = "KIT";
            else if (r == DialogResult.No) tipo = "TAMBOR";
            else return;

            // PREGUNTAMOS SI QUEREMOS REGISTRAR X REGISTROS SI EL RESULTADO ES SI SE HACE EL TRY, SI SE ELIGE NO, SE CANCELA
            // ESTA VENTANA SALE DESPUES DE SELECCIONAR EL TIPO DE REPUESTO QUE SE VA A PEDIR
            if (MostrarMaterialMessageBox($"¿Registrar {filas.Count} pedidos de '{tipo}'?", "Confirmar") == DialogResult.Yes)
            {
                try
                {

                    // ELEGIMOS LA TABLA SEGUN EL BOTON PULSADO
                    string tablaDestino = tipo == "KIT" ? "KIT_MANTENIMIENTO" : "TAMBORES";


                    // PONEMOS EN MAYUSCULAS PARA LA COLUMNA DESCRIPCION
                    string nombreConsumible = tipo == "KIT" ? "KIT_MANTENIMIENTO" : "TAMBORES";


                    foreach (DataGridViewRow f in filas)
                    {
                        string sql = $"INSERT INTO {tablaDestino} (MODELO, NSERIE, UBICACION, DESCRIPCION, FECHA) VALUES (@m, @s, @u, @d, GETDATE())";
                        SqlParameter[] param = {
                                                 new SqlParameter("@m", f.Cells["MODELO"].Value?.ToString() ?? ""),
                                                 new SqlParameter("@s", f.Cells["NSERIE"].Value.ToString()),
                                                 new SqlParameter("@u", f.Cells["UBICACION"].Value?.ToString() ?? ""),
                                                 new SqlParameter("@d", nombreConsumible)
                                                };
                        db.EjecutarComando(sql, param);
                    }

                    CargarHistorial();
                    dgvPedidoWeb.DataSource = null;
                    new MaterialSnackBar("Pedidos registrados correctamente.", "OK", true).Show(this);
                }
                catch (Exception ex) { new MaterialSnackBar("Error: " + ex.Message, "OK", true).Show(this); }
            }

            // LIMPIAMOS TEXTBOX
            txtBuscarSerie.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Limpiamos los buscadores por si acaso
            txtBuscarInventario.Text = "";

            // Creamos una instancia de tu nuevo formulario
            using (FormNuevaImpresora frmNuevo = new FormNuevaImpresora())
            {
                // Lo mostramos como una ventana emergente (ShowDialog)
                if (frmNuevo.ShowDialog() == DialogResult.OK)
                {
                    // Si devolvió "OK", leemos la propiedad pública que creamos
                    string serieRegistrada = frmNuevo.SerieGuardada;

                    CargarInventario();
                    new MaterialSnackBar($"Equipo registrado con la serie: {serieRegistrada}", "OK", true).Show(this);
                }
            }
        }

        private void btnCargarHistorial_Click(object sender, EventArgs e) { CargarHistorial(); }

        private void btnCargarInventario_Click(object sender, EventArgs e) { CargarInventario(); }

        //-----------------------------------------------------------------------------------
        // TEXTBOX
        //-----------------------------------------------------------------------------------

        private void txtBuscarSerie_TextChanged(object sender, EventArgs e)
        {
            string serieABuscar = txtBuscarSerie.Text.Trim();

            if (string.IsNullOrEmpty(serieABuscar))
            {
                dgvPedidoWeb.DataSource = null;
                return;
            }

            string sql = "SELECT GRUPO, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE NSERIE LIKE @s";
            SqlParameter[] p = { new SqlParameter("@s", "%" + serieABuscar + "%") };

            DataTable dt = db.ObtenerDatos(sql, p);

            if (dt != null && dt.Rows.Count > 0)
            {
                // 1. Asignamos los datos al grid
                dgvPedidoWeb.DataSource = dt;

                // 2. Volvemos a aplicar los estilos generales y el centrado de la columna GRUPO
                AplicarEstilosGrid(dgvPedidoWeb);

                dgvPedidoWeb.ClearSelection();
                dgvPedidoWeb.CurrentCell = null;
            }
            else
            {
                dgvPedidoWeb.DataSource = null;
            }
        }

        private void txtBuscarInventario_TextChanged(object sender, EventArgs e)
        {
            string serieABuscar = txtBuscarInventario.Text.Trim();

            if (string.IsNullOrEmpty(serieABuscar))
            {
                CargarInventario(); // Si borra el texto, carga todo
                return;
            }

            string sqlInv = "SELECT GRUPO, MODELO, UBICACION, NSERIE, IP, OBSERVACIONES FROM IMPRESORAS WHERE NSERIE LIKE @s ORDER BY (CASE WHEN GRUPO IS NULL THEN 1 ELSE 0 END), GRUPO ASC";
            DataTable dtInv = db.ObtenerDatos(sqlInv, new SqlParameter[] { new SqlParameter("@s", "%" + serieABuscar + "%") });

            if (dtInv != null)
            {
                dgvInventario.DataSource = dtInv;

                AplicarEstilosGrid(dgvInventario);

                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                foreach (DataGridViewColumn col in dgvInventario.Columns)
                {
                    if (col.Name == "OBSERVACIONES") { col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.MinimumWidth = 100; }
                    else col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void txtBuscarHistorial_TextChanged(object sender, EventArgs e)
        {
            string serieABuscar = txtBuscarHistorial.Text.Trim();

            if (string.IsNullOrEmpty(serieABuscar))
            {
                CargarHistorial(); // Recarga las dos tablas completas
                return;
            }

            // 1. Filtramos en la tabla de Historial Completo
            string sqlHist = @"
            SELECT I.GRUPO, H.FECHA, H.NSERIE, H.MODELO, H.UBICACION, H.DESCRIPCION 
            FROM (
                SELECT FECHA, NSERIE, MODELO, UBICACION, DESCRIPCION FROM TAMBORES
                UNION ALL
                SELECT FECHA, NSERIE, MODELO, UBICACION, DESCRIPCION FROM KIT_MANTENIMIENTO
            ) H 
            LEFT JOIN IMPRESORAS I ON H.NSERIE = I.NSERIE 
            WHERE H.NSERIE LIKE @s
            ORDER BY H.FECHA DESC";
            dgvHistorial.DataSource = db.ObtenerDatos(sqlHist, new SqlParameter[] { new SqlParameter("@s", "%" + serieABuscar + "%") });

            // 2. Filtramos en la tabla de Totales CON EL DESGLOSE DE FECHAS
            string sqlTot = @"
            SELECT I.GRUPO, H.NSERIE, H.MODELO, 
                   SUM(CASE WHEN H.TIPO = 'TAMBOR' THEN 1 ELSE 0 END) as [TOTAL TAMBORES],
                   MAX(CASE WHEN H.TIPO = 'TAMBOR' THEN H.FECHA END) as [ÚLTIMO TAMBOR],
                   SUM(CASE WHEN H.TIPO = 'KIT' THEN 1 ELSE 0 END) as [TOTAL KITS],
                   MAX(CASE WHEN H.TIPO = 'KIT' THEN H.FECHA END) as [ÚLTIMO KIT]
            FROM (
                SELECT FECHA, NSERIE, MODELO, 'TAMBOR' as TIPO FROM TAMBORES
                UNION ALL
                SELECT FECHA, NSERIE, MODELO, 'KIT' as TIPO FROM KIT_MANTENIMIENTO
            ) H 
            LEFT JOIN IMPRESORAS I ON H.NSERIE = I.NSERIE 
            WHERE H.NSERIE LIKE @s
            GROUP BY I.GRUPO, H.NSERIE, H.MODELO 
            ORDER BY I.GRUPO ASC, (SUM(CASE WHEN H.TIPO = 'TAMBOR' THEN 1 ELSE 0 END) + SUM(CASE WHEN H.TIPO = 'KIT' THEN 1 ELSE 0 END)) DESC";
            dgvTotales.DataSource = db.ObtenerDatos(sqlTot, new SqlParameter[] { new SqlParameter("@s", "%" + serieABuscar + "%") });
        }

        //-----------------------------------------------------------------------------------
        // COMBOBOX
        //-----------------------------------------------------------------------------------

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // --- NUEVO: Control de seguridad por si se deselecciona todo ---
            if (cmbGrupo.SelectedIndex == -1)
            {
                dgvPedidoWeb.DataSource = null;
                return;
            }

            string sql; SqlParameter[] p = null;

            if (cmbGrupo.Text == "Sin Grupo")
                sql = "SELECT GRUPO, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO IS NULL OR GRUPO = ''";
            else
            {
                sql = "SELECT GRUPO, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO = @g AND MODELO LIKE '%4510%'";
                p = new SqlParameter[] { new SqlParameter("@g", cmbGrupo.Text) };
            }

            // 1. Asignamos los datos (el grid destruye y recrea las columnas aquí)
            dgvPedidoWeb.DataSource = db.ObtenerDatos(sql, p);

            // 2. Volvemos a aplicar los estilos generales y el centrado de la columna GRUPO
            AplicarEstilosGrid(dgvPedidoWeb);

            dgvPedidoWeb.ClearSelection();
            dgvPedidoWeb.CurrentCell = null;
        }


        //-----------------------------------------------------------------------------------
        // EVENTOS
        //-----------------------------------------------------------------------------------

        private void Grids_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridView grid = (DataGridView)sender;
                int seleccionados = grid.SelectedRows.Count;
                if (seleccionados == 0) return;

                isDeleting = true;
                string msg = seleccionados == 1 ? "¿Borrar registro?" : $"¿Borrar {seleccionados} registros?";

                if (MostrarMaterialMessageBox(msg, "Confirmar") == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow fila in grid.SelectedRows)
                        {
                            if (fila.IsNewRow) continue;
                            string nSerie = fila.Cells["NSERIE"].Value?.ToString();

                            if (grid.Name == "dgvInventario")
                            {
                                db.EjecutarComando("DELETE FROM IMPRESORAS WHERE NSERIE = @s", new SqlParameter[] { new SqlParameter("@s", nSerie) });
                            }
                            else if (grid.Name == "dgvHistorial")
                            {
                                DateTime f = Convert.ToDateTime(fila.Cells["FECHA"].Value);
                                string descripcion = fila.Cells["DESCRIPCION"].Value?.ToString().ToUpper() ?? "";

                                // Averiguamos de qué tabla borrar basándonos en la descripción
                                string tablaBorrado = descripcion.Contains("KIT") ? "KIT_MANTENIMIENTO" : "TAMBORES";

                                db.EjecutarComando($"DELETE FROM {tablaBorrado} WHERE NSERIE = @s AND FECHA = @f",
                                    new SqlParameter[] { new SqlParameter("@s", nSerie), new SqlParameter("@f", f) });
                            }
                        }
                        CargarInventario();
                        CargarHistorial();
                    }
                    catch (Exception ex) { new MaterialSnackBar("Error: " + ex.Message, "OK", true).Show(this); }
                }
                isDeleting = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                CargarHistorial();
            }
            // Control de aviso en la pestaña Pedidos ---
            else if (tabControl1.SelectedIndex == 1)
            {
                if (!avisoPedidosMostrado && cmbGrupo.SelectedIndex == -1)
                {
                    new MaterialSnackBar("AVISO: \nSeleccione un grupo para mostrar.", 20000, "OK", true).Show(this);
                    avisoPedidosMostrado = true;
                }
            }
        }

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

        //-----------------------------------------------------------------------------------
        // CARGAS DE GRIDS
        //-----------------------------------------------------------------------------------

        public void CargarInventario()
        {
            string sql = "SELECT GRUPO, MODELO, UBICACION, NSERIE, IP, OBSERVACIONES FROM IMPRESORAS ORDER BY (CASE WHEN GRUPO IS NULL THEN 1 ELSE 0 END), GRUPO ASC";
            DataTable dt = db.ObtenerDatos(sql);

            if (dt != null)
            {
                dgvInventario.DataSource = dt;
                AplicarEstilosGrid(dgvInventario);

                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in dgvInventario.Columns)
                {
                    if (col.Name == "OBSERVACIONES")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        col.MinimumWidth = 100;
                    }
                    else
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
        }

        public void CargarHistorial()
        {
            try
            {
                // Unimos TAMBORES y KIT_MANTENIMIENTO para el historial detallado
                string sqlH = @"
                        SELECT I.GRUPO, H.FECHA, H.NSERIE, H.MODELO, H.UBICACION, H.DESCRIPCION 
                        FROM (
                            SELECT FECHA, NSERIE, MODELO, UBICACION, DESCRIPCION FROM TAMBORES
                            UNION ALL
                            SELECT FECHA, NSERIE, MODELO, UBICACION, DESCRIPCION FROM KIT_MANTENIMIENTO
                        ) H 
                        LEFT JOIN IMPRESORAS I ON H.NSERIE = I.NSERIE 
                        ORDER BY H.FECHA DESC";
                dgvHistorial.DataSource = db.ObtenerDatos(sqlH);

                // SQL MODIFICADO: Separamos fechas y totales
                string sqlT = @"
                        SELECT I.GRUPO, H.NSERIE, H.MODELO, 
                               SUM(CASE WHEN H.TIPO = 'TAMBOR' THEN 1 ELSE 0 END) as [TOTAL TAMBORES],
                               MAX(CASE WHEN H.TIPO = 'TAMBOR' THEN H.FECHA END) as [ÚLTIMO TAMBOR],
                               SUM(CASE WHEN H.TIPO = 'KIT' THEN 1 ELSE 0 END) as [TOTAL KITS],
                               MAX(CASE WHEN H.TIPO = 'KIT' THEN H.FECHA END) as [ÚLTIMO KIT]
                        FROM (
                            SELECT FECHA, NSERIE, MODELO, 'TAMBOR' as TIPO FROM TAMBORES
                            UNION ALL
                            SELECT FECHA, NSERIE, MODELO, 'KIT' as TIPO FROM KIT_MANTENIMIENTO
                        ) H 
                        LEFT JOIN IMPRESORAS I ON H.NSERIE = I.NSERIE 
                        GROUP BY I.GRUPO, H.NSERIE, H.MODELO 
                        ORDER BY I.GRUPO ASC, (SUM(CASE WHEN H.TIPO = 'TAMBOR' THEN 1 ELSE 0 END) + SUM(CASE WHEN H.TIPO = 'KIT' THEN 1 ELSE 0 END)) DESC";
                dgvTotales.DataSource = db.ObtenerDatos(sqlT);

                // Limpiamos los buscadores por si acaso
                txtBuscarHistorial.Text = "";
                txtBuscarInventario.Text = "";
                txtBuscarSerie.Text = "";

                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { }
        }

        //-----------------------------------------------------------------------------------
        // METODOS
        //-----------------------------------------------------------------------------------

        private void PreguntarYExportarHistorial()
        {
            MaterialForm prompt = new MaterialForm()
            {
                Width = 320,
                Height = 240, // Le damos más altura por la cabecera de MaterialSkin
                Text = "Exportar a Excel",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Sizable = false // Evita que estiren la ventana
            };

            // Aplicamos tu gestor de temas para que mantenga el estilo visual de tu app
            GestorTema.ConfigurarMaterialSkin(prompt);

            // Ajustamos el Top a 80 para que empiece debajo de la barra azul
            MaterialLabel lbl = new MaterialLabel() { Left = 60, Top = 80, Width = 300, Text = "¿Qué tabla desea exportar?" };

            // Cambiamos a MaterialButton y los ponemos en mayúsculas (el estándar de Material)
            // Alineamos a la izquierda a unos 70px para que queden centrados a ojo
            MaterialButton btnHist = new MaterialButton() { Text = "HISTORIAL", Left = 70, Top = 120, DialogResult = DialogResult.Yes };
            MaterialButton btnTot = new MaterialButton() { Text = "PEDIDOS TOTALES", Left = 70, Top = 170, DialogResult = DialogResult.No };

            prompt.Controls.AddRange(new Control[] { lbl, btnHist, btnTot });

            DialogResult res = prompt.ShowDialog();

            if (res == DialogResult.Yes)
                ExportarAExcel(dgvHistorial, "InventarioImpresorasHistorico");
            else if (res == DialogResult.No)
                ExportarAExcel(dgvTotales, "InventarioImpresorasTotalesPedidos");
        }

        private void ExportarAExcel(DataGridView grid, string nombreBase)
        {
            if (grid.Rows.Count == 0) { new MaterialSnackBar("No hay datos para exportar.", "OK", true).Show(this); return; }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"{nombreBase}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Datos");

                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            var celda = worksheet.Cell(1, i + 1);
                            celda.Value = grid.Columns[i].HeaderText;
                            celda.Style.Font.Bold = true;
                            celda.Style.Fill.BackgroundColor = XLColor.LightGray;
                            celda.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            if (grid.Rows[i].IsNewRow) continue;

                            for (int j = 0; j < grid.Columns.Count; j++)
                            {
                                var valor = grid.Rows[i].Cells[j].Value?.ToString() ?? "";
                                var celdaExcel = worksheet.Cell(i + 2, j + 1);
                                celdaExcel.Value = valor;

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
                        new MaterialSnackBar("Exportado correctamente. ✔", "OK", true).Show(this);
                    }
                }
                catch (Exception ex) { new MaterialSnackBar("Error: " + ex.Message, "OK", true).Show(this); }
            }
        }

        private DialogResult MostrarMaterialMessageBox(string mensaje, string titulo)
        {
            MaterialForm msgForm = new MaterialForm()
            {
                Width = 400,
                Height = 200,
                Text = titulo,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Sizable = false
            };

            GestorTema.ConfigurarMaterialSkin(msgForm);

            MaterialLabel lbl = new MaterialLabel()
            {
                Left = 20,
                Top = 80,
                Width = 360,
                Text = mensaje
            };

            MaterialButton btnSi = new MaterialButton() { Text = "SÍ", Left = 220, Top = 150, DialogResult = DialogResult.Yes };
            MaterialButton btnNo = new MaterialButton() { Text = "NO", Left = 290, Top = 150, DialogResult = DialogResult.No };

            msgForm.Controls.AddRange(new Control[] { lbl, btnSi, btnNo });

            return msgForm.ShowDialog();
        }

    }
}