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

            // --- PEDIDO WEB ---
            dgvPedidoWeb.ReadOnly = true;                // Nadie puede escribir en las celdas
            dgvPedidoWeb.AllowUserToAddRows = false;     // Quita la fila vacía del final
            dgvPedidoWeb.AllowUserToDeleteRows = false;  // Evita borrados accidentales aquí
            dgvPedidoWeb.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona la fila entera al hacer clic
            dgvPedidoWeb.MultiSelect = true;             // Permite elegir varios con Ctrl o Shift
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
            
            dgvTotales.ReadOnly = true;                 // Nadie puede alterar los cálculos
            dgvTotales.AllowUserToAddRows = false;      
            dgvTotales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotales.MultiSelect = false;             // Normalmente aquí solo quieres ver una máquina a la vez
            dgvTotales.CellFormatting += AplicarColoresGrupo; // Para que el color del grupo también se vea aquí
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
            }
        }

        // ==========================================
        // --- COLORES PASTEL ---
        // ==========================================

        private void AplicarColoresGrupo(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "GRUPO" && e.Value != null)
            {
                string val = e.Value.ToString();
                switch (val)
                {
                    case "1": e.CellStyle.BackColor = Color.LightBlue; break;
                    case "2": e.CellStyle.BackColor = Color.LightGreen; break;
                    case "3": e.CellStyle.BackColor = Color.LightCoral; break;
                    case "4": e.CellStyle.BackColor = Color.LemonChiffon; break;
                    case "5": e.CellStyle.BackColor = Color.Lavender; break;
                    case "6": e.CellStyle.BackColor = Color.PeachPuff; break;
                    case "7": e.CellStyle.BackColor = Color.MistyRose; break;
                    case "8": e.CellStyle.BackColor = Color.PaleTurquoise; break;
                    case "9": e.CellStyle.BackColor = Color.Thistle; break;
                    case "10": e.CellStyle.BackColor = Color.LightGray; break;
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
            if (dt != null) { dgvInventario.DataSource = dt; dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; }
        }
        
                public void CargarHistorial()
                {
                    try
                    {
                        string sqlH = @"SELECT I.GRUPO, T.FECHA, T.NSERIE, T.MODELO, T.UBICACION, T.DESCRIPCION 
                                        FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE ORDER BY T.FECHA DESC";
                        dgvHistorial.DataSource = db.ObtenerDatos(sqlH);

                        string sqlT = @"SELECT I.GRUPO, T.NSERIE, T.MODELO, COUNT(*) as [Total Pedidos], MAX(T.FECHA) as [Último] 
                                        FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE 
                                        GROUP BY I.GRUPO, T.NSERIE, T.MODELO ORDER BY I.GRUPO ASC, [Total Pedidos] DESC";
                        dgvTotales.DataSource = db.ObtenerDatos(sqlT);

                        dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    catch { }
                }
        
        
        

        // ==========================================
        // --- EVENTOS PESTAÑAS Y SOLICITUD ---
        // ==========================================

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) CargarHistorial();
        }

        private void dgvInventario_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventario.Rows[e.RowIndex].IsNewRow) return;
            var fila = dgvInventario.Rows[e.RowIndex];
            string nSerie = fila.Cells["NSERIE"].Value?.ToString();
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

            // --- ESTO QUITA LA SELECCIÓN AUTOMÁTICA ---
            dgvPedidoWeb.ClearSelection();
            dgvPedidoWeb.CurrentCell = null;
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidoWeb.Rows.Count == 0) return;

            // 1. Identificar filas a procesar
            List<DataGridViewRow> filasAProcesar = dgvPedidoWeb.SelectedRows.Count > 0
                ? dgvPedidoWeb.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvPedidoWeb.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow && r.Cells["NSERIE"].Value != null).ToList();

            string tipoConsumible = "";

            // 2. Lógica para "Sin Grupo" con botones personalizados
            if (cmbGrupo.Text.Trim().Equals("Sin Grupo", StringComparison.OrdinalIgnoreCase))
            {
                // Creamos una ventana de diálogo personalizada rápida
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
                    dgvPedidoWeb.DataSource = null;
                    MessageBox.Show("Registros guardados con éxito.");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnCargarHistorial_Click(object sender, EventArgs e) 
        { 
            CargarHistorial(); 
        }
    }
}