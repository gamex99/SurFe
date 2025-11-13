using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SurFeFront
{
    public partial class ArchivosSistema : Form
    {
        public ArchivosSistema()
        {
            InitializeComponent();
            CargarFacturas("");

            dataGridView1.ReadOnly = true;
        }
        /*
        private void CargarFacturas()
        {
            // 1. Define tu Connection String (Cadena de Conexión)
            // ¡DEBES CAMBIAR ESTO!
            // Usa "Server=." o "Server=localhost" si SQL Server está en tu misma PC.
            // Si usas SQL Express, podría ser "Server=.\\SQLEXPRESS".
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            // 2. Define tu consulta (la que proporcionaste)
            string query = @"
               SELECT f.[id_factura]
                  ,c.[razon_social] AS NombreCliente
                  ,tf.[descripcion] AS TipoDocumento  -- <-- CAMBIO: Traemos la descripción
                  ,f.[fecha]
                  ,f.[total]
                  ,f.[location]
              FROM [dbo].[factura] f
              INNER JOIN [dbo].[cliente] c ON f.[id_cliente] = c.[id_cliente]
              -- V- CAMBIO: Añadimos el nuevo JOIN para tipo_factura
              INNER JOIN [dbo].[tipo_factura] tf ON f.[tipo_documento] = tf.[id]";

            // 3. Usa un DataTable para guardar los datos temporalmente
            DataTable dt = new DataTable();

            try
            {
                // 4. Usa bloques 'using' para asegurar que las conexiones se cierren
                // automáticamente, incluso si hay un error.
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // 5. El SqlDataAdapter es el puente entre la BD y el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // 6. El método Fill() abre la conexión, ejecuta la consulta,
                            // llena el DataTable y cierra la conexión.
                            da.Fill(dt);
                        }
                    }
                }

                // 7. ¡Asigna el DataTable como la fuente de datos del DataGridView!
                dataGridView1.DataSource = dt;

                // (Opcional) Mejorar los nombres de las columnas
                AjustarColumnasDataGridView();
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que pueda ocurrir
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// (Opcional) Método para hacer que los encabezados de las columnas se vean mejor.
        /// </summary>
        /// 




        */




        // 1. El método ahora acepta un parámetro 'terminoBusqueda'
        private void CargarFacturas(string terminoBusqueda)
        {
            // 1. Define tu Connection String (Cadena de Conexión)
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // 2. Define tu consulta (Query)
            // ¡AÑADIMOS LA CLÁUSULA 'WHERE' AL FINAL!
            /*string query = @"
        SELECT f.[id_factura]
          ,c.[razon_social] AS NombreCliente
          ,tf.[descripcion] AS TipoDocumento
          ,f.[fecha]
          ,f.[total]
          ,f.[location]
        FROM [dbo].[factura] f
        INNER JOIN [dbo].[cliente] c ON f.[id_cliente] = c.[id_cliente]
        INNER JOIN [dbo].[tipo_factura] tf ON f.[tipo_documento] = tf.[id]
        -- 3. FILTRO 'WHERE' AÑADIDO:
        -- Comparamos la razón social O el número de factura.
        -- Usamos CAST() para convertir el id_factura (que es número) a texto
        -- y poder usar LIKE en ambos campos.
        WHERE c.[razon_social] LIKE @busqueda OR CAST(f.[id_factura] AS VARCHAR(50)) LIKE @busqueda";*/
            /*string query = @"-- 1. Definimos una ""tabla virtual"" (CTE) para unificar los 3 tipos de documentos
;WITH DocumentosCombinados AS (
    SELECT 
        id_factura AS id_documento, 
        id_cliente, 
        tipo_documento, 
        fecha, 
        total, 
        location
    FROM [dbo].[factura]
    
    UNION ALL
    
    SELECT 
        id_notaDeCredito AS id_documento, 
        id_cliente, 
        tipo_documento, 
        fecha, 
        total, 
        location
    FROM [dbo].[notaDeCredito]
    
    UNION ALL
    
    SELECT 
        id_presupuesto AS id_documento, 
        id_cliente, 
        tipo_documento, 
        fecha, 
        total, 
        location
    FROM [dbo].[presupuesto]
)
-- 2. Ahora consultamos esa ""tabla virtual"" y aplicamos los JOINS y el FILTRO
SELECT 
    d.[id_documento] AS id_factura,  -- <<< ¡AQUÍ ESTÁ LA CORRECCIÓN!
    c.[razon_social] AS NombreCliente,
    tf.[descripcion] AS TipoDocumento,
    d.[fecha],
    d.[total],
    d.[location]
FROM DocumentosCombinados d
INNER JOIN [dbo].[cliente] c ON d.[id_cliente] = c.[id_cliente]
INNER JOIN [dbo].[tipo_factura] tf ON d.[tipo_documento] = tf.[id]
-- 3. FILTRO 'WHERE' aplicado una sola vez a todos los resultados
WHERE c.[razon_social] LIKE @busqueda OR CAST(d.[id_documento] AS VARCHAR(50)) LIKE @busqueda";*/
            string query = @"-- 1. Definimos la CTE...
;WITH DocumentosCombinados AS (
    SELECT 
        id_factura AS id_documento, id_cliente, tipo_documento, fecha, total, location, 'Factura' AS Origen
    FROM [SurFeFinal].[dbo].[factura]
    
    UNION ALL
    
    SELECT 
        id_notaDeCredito AS id_documento, id_cliente, tipo_documento, fecha, total, location, 'Nota de Credito' AS Origen
    FROM [SurFeFinal].[dbo].[notaDeCredito]
    
    UNION ALL
    
    SELECT 
        id_presupuesto AS id_documento, id_cliente, tipo_documento, fecha, total, location, 'Presupuesto' AS Origen
    FROM [SurFeFinal].[dbo].[presupuesto]
)
-- 2. Cambiamos a LEFT JOIN para el test
SELECT 
    d.[id_documento] AS id_factura,
    c.[razon_social] AS NombreCliente,
    tf.[descripcion] AS TipoDocumento,
    d.[Origen],
    d.[fecha],
    d.[total],
    d.[location]
FROM DocumentosCombinados d
-- VAMOS A USAR LEFT JOIN PARA ENCONTRAR EL PROBLEMA
LEFT JOIN [SurFeFinal].[dbo].[cliente] c ON d.[id_cliente] = c.[id_cliente]
LEFT JOIN [SurFeFinal].[dbo].[tipo_factura] tf ON d.[tipo_documento] = tf.[id]
-- 3. FILTRO 'WHERE' ...
WHERE c.[razon_social] LIKE @busqueda OR CAST(d.[id_documento] AS VARCHAR(50)) LIKE @busqueda
-- 4. ORDENADO...
ORDER BY CAST(d.[fecha] AS DATETIME) DESC";

            // 3. Usa un DataTable para guardar los datos temporalmente
            DataTable dt = new DataTable();

            try
            {
                // 4. Usa bloques 'using' para asegurar que las conexiones se cierren
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // 5. ¡AQUÍ AÑADIMOS EL PARÁMETRO!
                        // Esto es vital para la seguridad.
                        // Usamos '%' como comodines para que LIKE busque coincidencias parciales
                        // (ej: si buscás 'Coca', encontrará 'Coca-Cola').
                        cmd.Parameters.AddWithValue("@busqueda", "%" + terminoBusqueda + "%");

                        // 6. El SqlDataAdapter es el puente entre la BD y el DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // 7. El método Fill() ejecuta la consulta con el parámetro
                            da.Fill(dt);
                        }
                    }
                }

                // 8. ¡Asigna el DataTable como la fuente de datos del DataGridView!
                dataGridView1.DataSource = dt;

                // (Opcional) Mejorar los nombres de las columnas
                AjustarColumnasDataGridView();
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que pueda ocurrir
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AjustarColumnasDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_factura"].HeaderText = "N° Factura";
                dataGridView1.Columns["NombreCliente"].HeaderText = "Razon Social";
                dataGridView1.Columns["TipoDocumento"].HeaderText = "Tipo";
                dataGridView1.Columns["Origen"].HeaderText = "Origen";
                dataGridView1.Columns["fecha"].HeaderText = "Fecha";
                dataGridView1.Columns["total"].HeaderText = "Total";
                dataGridView1.Columns["location"].HeaderText = "Ubicación";

                // Opcional: Hacer que las columnas se autoajusten
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verificamos que el doble clic no sea en el encabezado
            // (e.RowIndex < 0 es el encabezado)
            if (e.RowIndex < 0)
            {
                return;
            }


            try
            {
                string ubicacion = dataGridView1.Rows[e.RowIndex].Cells["location"].Value.ToString();


                //// MessageBox.Show("El dato extraído es: " + ubicacion);

                string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;

                string rutaCompletaArchivo = Path.Combine(directorioPrograma, ubicacion);









                PDFView formPDF = new PDFView(rutaCompletaArchivo);

                // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
                formPDF.ShowDialog();

            }
            catch (NullReferenceException)
            {
                // Esto previene un error si la celda estuviera vacía (null)
                MessageBox.Show("La celda de ubicación está vacía.");
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado
                MessageBox.Show("Error al extraer el dato: " + ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarFacturas(textBox1.Text.Trim());
        }
    }
}

