using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace BDproj
{
    public class BaseDato
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost; Database=restaurante ;User=root; Password=");
        //static DataTable dt;
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        public BaseDato()
        {

        }
        public void Conectar()
        {
            //Cadena de conexion
            try
            {
               
                con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
        public void Desconectar()
        {
            con.Close();
        }
        public void ConsultarComando(String consulta)
        {
            cmd = new MySqlCommand(consulta, con);
        }
        public MySqlCommand ConsultarComando(String consulta,String NoValor)
        {
            return new MySqlCommand(consulta, con);
        }
        public void Insertar(string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException myex)
            {
                throw new Exception("" + myex);
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AsignarParametro(String param, MySqlDbType tipo, Object valor) 
        {
            cmd.Parameters.Add(param, tipo).Value = valor;
        }
    }
}
