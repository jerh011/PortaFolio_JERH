using System.Data.SqlClient;
using System.Data;
using PortaFolio_JERH.Models;

namespace PortaFolio_JERH.Datos
{
    public class DaPersonalesDatos
    {
        public List<DatosPersonalesModel> Listar()
        {
            List<DatosPersonalesModel> Lista = new List<DatosPersonalesModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_listar_datos", conexion);//Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new DatosPersonalesModel()
                        {
                            Id = Convert.ToInt32(dr["Id_DatosPersonales"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellido_Pa = ' '+dr["ApePa"].ToString(),
                            Apellido_Ma = ' ' + dr["ApeMa"].ToString(),
                            Numero_cel = dr["Numero_cel"].ToString(),
                            Correo1 = dr["Correo1"].ToString(),
                            Correo2 = dr["Correo2"].ToString()
                           
                        }
                        );
                    }
                }
            }
            return Lista;
        }
      
        
    }
}