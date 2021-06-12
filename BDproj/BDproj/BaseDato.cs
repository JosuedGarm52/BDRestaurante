using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace BDproj
{
    public class BaseDato
    {
        public MySqlConnection con;
        //static DataTable dt;
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        string server = "localhost";
        string database = "restaurante";
        string user = "root";
        string password = "";
        public BaseDato()
        {
            con = new MySqlConnection($"Server={server}; Database={database};User=root; Password={password}");
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
        public void CambiarDatabase(string strserver, string strbasedato, string strUsuario, string strContraseña)
        {
            server = strserver;
            database = strbasedato;
            user = strUsuario;
            password = strContraseña;
            con = new MySqlConnection($"Server={server}; Database={database};User=root; Password={password}");
        }
    }
}
