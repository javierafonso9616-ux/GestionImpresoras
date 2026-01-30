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
            // Inventario
            dgvInventario.AllowUserToDeleteRows = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.RowValidated += dgvInventario_RowValidated;
            dgvInventario.UserDeletingRow += dgvInventario_UserDeletingRow;

            // Bloquear edición en Historial y Totales
            dgvHistorial.ReadOnly = true;
            dgvTotales.ReadOnly = true;

            // Suscribir evento de COLORES para todos los grids
            dgvInventario.CellFormatting += AplicarColoresGrupo;
            dgvPedidoWeb.CellFormatting += AplicarColoresGrupo;
            dgvHistorial.CellFormatting += AplicarColoresGrupo;
            dgvTotales.CellFormatting += AplicarColoresGrupo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarInventario();
            CargarHistorial();
        }

        // Detectar cuando entras a la pestaña de Historial (asumiendo índice 2)
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) CargarHistorial();
        }

        // --- COLORES PASTEL PARA LOS GRUPOS ---
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
        // --- PESTAÑA 1: INVENTARIO ---
        // ==========================================

        public void CargarInventario()
        {
            string sql = @"SELECT GRUPO, MODELO, UBICACION, NSERIE, IP, N_MAQUINA, OBSERVACIONES 
                           FROM IMPRESORAS 
                           ORDER BY (CASE WHEN GRUPO IS NULL THEN 1 ELSE 0 END), GRUPO ASC, N_MAQUINA ASC";

            DataTable dt = db.ObtenerDatos(sql);
            if (dt != null)
            {
                dgvInventario.DataSource = dt;
                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
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

        private void dgvInventario_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string nSerie = e.Row.Cells["NSERIE"].Value?.ToString();
            if (MessageBox.Show($"¿Eliminar {nSerie}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                db.EjecutarComando("DELETE FROM IMPRESORAS WHERE NSERIE = @ser", new SqlParameter[] { new SqlParameter("@ser", nSerie) });
            else e.Cancel = true;
        }

        // ==========================================
        // --- PESTAÑA 2: SOLICITAR ---
        // ==========================================

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
            if (MessageBox.Show("¿Registrar estas máquinas en el histórico?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                MessageBox.Show("Historial actualizado.");
            }
        }

        // ==========================================
        // --- PESTAÑA 3: HISTORIAL Y TOTALES ---
        // ==========================================

        public void CargarHistorial()
        {
            try
            {
                // Historial Detallado con JOIN para traer el GRUPO
                string sqlH = @"SELECT I.GRUPO, T.FECHA, T.NSERIE, T.MODELO, T.UBICACION, T.DESCRIPCION 
                                FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE 
                                ORDER BY T.FECHA DESC";
                dgvHistorial.DataSource = db.ObtenerDatos(sqlH);

                // Totales por Máquina con JOIN para traer el GRUPO
                string sqlT = @"SELECT I.GRUPO, T.NSERIE, T.MODELO, COUNT(*) as [Total Pedidos], MAX(T.FECHA) as [Último] 
                                FROM TAMBORES T LEFT JOIN IMPRESORAS I ON T.NSERIE = I.NSERIE 
                                GROUP BY I.GRUPO, T.NSERIE, T.MODELO 
                                ORDER BY [Total Pedidos] DESC";
                dgvTotales.DataSource = db.ObtenerDatos(sqlT);

                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btnCargarHistorial_Click(object sender, EventArgs e) { CargarHistorial(); }
    }
}