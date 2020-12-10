using BaseDatosAlumno.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseDatosAlumno.azure
{
    public class Alumnoazure
    {
        //RUTA
        static string connectionString = "Server=PCALEX;Database=BASEDATOSDEALUMNOS;Trusted_Connection=True;";

        private static List<Alumno> alumnos;

        //ALUMNOS
        public static List<Alumno> obteneralumnos()
        {
            var dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand (null, sqlConnection);
                sqlCommand.CommandText = " select * from Alumnos";

                sqlConnection.Open();

                var dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                alumnos = new List<Alumno>();
                for (int i =0; i < dataTable.Rows.Count; i++)
                {
                    Alumno alumno = new Alumno();
                    alumno.id_alumno = int.Parse(dataTable.Rows[i]["id_alumno"].ToString());
                    alumno.rut = dataTable.Rows[i]["rut"].ToString();
                    alumno.id_contacto = dataTable.Rows[i]["id_contacto"].ToString();
                    alumno.id_especialidad = dataTable.Rows[i]["id_especialidad"].ToString();
                    alumno.id_estadopractica = dataTable.Rows[i]["id_estadopractica"].ToString();
                    alumno.id_persona = dataTable.Rows[i]["id_persona"].ToString();
                    alumnos.Add(alumno);

                }

                return alumnos;

            }
           
        }
    }



}
