using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public class Conexao
    {
        static string conectaBanco = @"Server=127.0.0.1;database=cruddao;User id=root;password=Caiozende.1";
        public MySqlConnection conexao = new MySqlConnection(conectaBanco);

        
        public MySqlConnection AbrirConexao()
        {
            try
            {
                conexao.Open();
                if (conexao.State == System.Data.ConnectionState.Open) { }// Console.WriteLine("OK"); }
            }
            catch(Exception erro)
            {
                throw erro;
            }
            return conexao;
        }

        public void FecharConexao()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        
    }
}
