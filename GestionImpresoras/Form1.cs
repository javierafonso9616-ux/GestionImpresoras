using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GestionImpresoras.DatosImpresoras;

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

            // --- HISTORIAL ---
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.CellFormatting += AplicarColoresGrupo;
            dgvHistorial.KeyDown += Grids_KeyDown; // Conectar tecla Suprimir

            // --- TOTALES ---
            dgvTotales.ReadOnly = true;
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
            if (string.IsNullOrEmpty(cmbGrupo.Text)) return;
            string sql = "SELECT GRUPO, N_MAQUINA, UBICACION, MODELO, NSERIE FROM IMPRESORAS WHERE GRUPO = @g AND MODELO LIKE '%4510%'";
            dgvPedidoWeb.DataSource = db.ObtenerDatos(sql, new SqlParameter[] { new SqlParameter("@g", cmbGrupo.Text) });
            dgvPedidoWeb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidoWeb.Rows.Count == 0) return;
            if (MessageBox.Show("¿Registrar pedido?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow fila in dgvPedidoWeb.Rows)
                {
                    if (fila.Cells["NSERIE"].Value == null) continue;
                    string sql = "INSERT INTO TAMBORES (MODELO, NSERIE, UBICACION, DESCRIPCION, FECHA) VALUES (@mod, @ser, @ubi, @desc, GETDATE())";
                    SqlParameter[] p = {
                        new SqlParameter("@mod", fila.Cells["MODELO"].Value.ToString()),
                        new SqlParameter("@ser", fila.Cells["NSERIE"].Value.ToString()),
                        new SqlParameter("@ubi", fila.Cells["UBICACION"].Value.ToString()),
                        new SqlParameter("@desc", "Pedido bloque Grupo " + cmbGrupo.Text)
                    };
                    db.EjecutarComando(sql, p);
                }
                dgvPedidoWeb.DataSource = null;
                CargarHistorial();
                MessageBox.Show("Pedido registrado.");
            }
        }

        private void btnCargarHistorial_Click(object sender, EventArgs e) { CargarHistorial(); }
    }
}