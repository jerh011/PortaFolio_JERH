using System.Data.SqlClient;
using System.Data;
using PortaFolio_JERH.Models;

namespace PortaFolio_JERH.Datos
{
    public class DaPersonalesDatos
    {
        public List<CMT_TodoModel> Listar()
        {
            List<CMT_TodoModel> Lista = new List<CMT_TodoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_listar_CMTodo ", conexion);//Nombre del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new CMT_TodoModel()
                        {

                            DaPe_Nombres = dr["Nombres"].ToString(),
                            DaPe_ApePa = ' '+dr["ApePa"].ToString(),
                            DaPe_ApeMa = ' ' + dr["ApeMa"].ToString(),
                            DaPe_Numero_cel = dr["Numero_cel"].ToString(),
                            DaPe_Correo1 = dr["Correo1"].ToString(),
                            DaPe_Correo2 = dr["Correo2"].ToString(),
                            DaPe_Sobremi = dr["Sobremi"].ToString(),
                            DaPe_Intereses = dr["Intereses"].ToString(),
                            Tec_Lenguaje = dr["Lenguaje"].ToString(),
                            Tec_Nivel = Convert.ToInt32(dr["Nivel"]),//entero
                            Dic_Calle = dr["Calle"].ToString(),
                            Dic_NumeroDeCasa = Convert.ToInt32(dr["NumeroDeCasa"]),//entero
                            Dic_Coloniea = dr["Coloniea"].ToString(),
                            Dic_CalleTrasera = dr["CalleTrasera"].ToString(),
                            Dic_Ciudad = dr["Ciudad"].ToString(),
                            Dic_Estad = dr["Estado"].ToString()
                        }
                        );
                    }
                }
            }
            return Lista;
        }
      
        
    }
}