using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_N__7_Vicentin_Fabricio
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarDataGrid();
        }
        private void actualizarDataGrid()
        {
            Conexion conexion = new Conexion();
            dataGridView1.DataSource = conexion.Conectar();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int idEmpleado;
        private string empleado;
        private string dniEmpleado;
        private string edadEmpleado;
        private string salarioEmpleado;
        private string nombreEmpleado;
        private bool casadoEmpleado;
        private bool casado;
        private bool editar = false;
        private int valorCasado;
        public void button1_Click(object sender, EventArgs e)
        { 
            if (editar == false)
            {
                try
                {
                    nombreEmpleado = txtNombreCompleto.Text;
                    dniEmpleado = txtDNI.Text;
                    edadEmpleado = txtEdad.Text;
                    salarioEmpleado = txtSalario.Text;
                    casadoEmpleado = casado;

                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=EMPLEADOS_DB;Trusted_Connection=True;";
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "Insert into Empleados(NombreCompleto,DNI,Edad,Casado,Salario) values ('" + nombreEmpleado + "','" + dniEmpleado + "','" + edadEmpleado + "','" + casadoEmpleado + "','" + salarioEmpleado + "')";
                    comando.Connection = conexion;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    actualizarDataGrid();
                    conexion.Close();
                    LimpiarCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (editar == true)

            {
                              if (dataGridView1.SelectedRows.Count > 0) 
                {
                    idEmpleado = (int)dataGridView1.SelectedCells[0].Value;
                    lblId.Text = idEmpleado.ToString();
                        nombreEmpleado = txtNombreCompleto.Text;
                        dniEmpleado = txtDNI.Text;
                        edadEmpleado = txtEdad.Text;
                        salarioEmpleado = txtSalario.Text;


                        SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=EMPLEADOS_DB;Trusted_Connection=True;";
                        conexion.Open();
                    SqlCommand comando = new SqlCommand();
                    //    string sql = @"UPDATE[dbo].[Empleados] SET[NombreCompleto] = @NombreCompleto,[DNI]= @DNI,[Edad]= @Edad,[Casado]= @Casado,[Salario]= @Salario WHERE id = @id";

                    //SqlCommand comando = new SqlCommand(sql, conexion);
                    //    comando.Parameters.AddWithValue("id", idEmpleado);
                    //    comando.Parameters.AddWithValue("NombreCompleto", nombreEmpleado).ToString();
                    //    comando.Parameters.AddWithValue("DNI", dniEmpleado);
                    //    comando.Parameters.AddWithValue("Edad", edadEmpleado);
                    //comando.Parameters.AddWithValue("Casado", valorCasado);
                    //comando.Parameters.AddWithValue("Salario", salarioEmpleado);

                    comando.CommandText = "UPDATE Empleados SET(NombreCompleto,DNI,Edad,Casado,Salario) " +
                    "values ('" + nombreEmpleado + "','" + dniEmpleado + "','" + edadEmpleado + "','" + casadoEmpleado + "','" + salarioEmpleado + "','" + "WHERE id = " + idEmpleado  + "";
                    comando.Connection = conexion;
                    //conexion.Open();
                    comando.ExecuteNonQuery();
                    actualizarDataGrid();
                    conexion.Close();
                }
                editar = false;
                }
                
                

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                casado = true;
            else if (checkBox1.Checked == false)
                casado = false;
        }
        public void esCasado()
        {
            if (casado== true)
            {
                valorCasado = 1;
            }
            else if (casado== false)
            {
                valorCasado = 0;
            }
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                lblId.Text = idEmpleado.ToString();
                Empleado empleado = new Empleado();
                idEmpleado = (int)dataGridView1.SelectedCells[0].Value;
                txtNombreCompleto.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtDNI.Text = dataGridView1.SelectedCells[2].Value.ToString();
                txtEdad.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtSalario.Text = dataGridView1.SelectedCells[5].Value.ToString();
                casado = (bool)dataGridView1.SelectedCells[4].Value;
            }
            else if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("Seleccione un Empleado");
            }
         }
        private void LimpiarCampos()
        {
            lblId.Text = "";
            txtNombreCompleto.Text = "";
            txtDNI.Text = "";
            txtEdad.Text = "";
            txtSalario.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Registro?","Eliminar", MessageBoxButtons.YesNo)== DialogResult.Yes) 
            { 
            idEmpleado = (int)dataGridView1.SelectedCells[0].Value;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=EMPLEADOS_DB;Trusted_Connection=True;";
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.CommandText = @"DELETE FROM [dbo].[Empleados] WHERE Id = '" + idEmpleado + "'";
            comando.Connection = conexion;
            comando.ExecuteNonQuery();
            actualizarDataGrid();
            conexion.Close();
            LimpiarCampos();
            }
            
        }
    }
       
    
}
