using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace TP_N__7_Vicentin_Fabricio
{
    class Conexion
    {
        public List<Empleado> Conectar()
        {
            SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=EMPLEADOS_DB;Trusted_Connection=True;");
            conexion.Open();
            string sql = "SELECT * FROM Empleados";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.CommandType = System.Data.CommandType.Text;
            SqlDataReader lector;


            List<Empleado> Empleados = new List<Empleado>();  
            lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                Empleado empleado = new Empleado();
                empleado.Id = lector.GetInt32(0);
                empleado.NombreCompleto = lector.GetString(1);
                empleado.DNI = lector.GetString(2);
                empleado.Edad = lector.GetInt32(3);
                empleado.Casado = lector.GetBoolean(4);
                empleado.Salario = lector.GetDecimal(5);

                Empleados.Add(empleado);
            }

            conexion.Close();

            return Empleados;

        }

    }
}
