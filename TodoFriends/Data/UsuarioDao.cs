using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoFriends.Models;

namespace TodoFriends.Data
{
    public class UsuarioDao
    {
        public static int findIdByTarefa(Tarefa tarefa)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tarefa WHERE Id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = tarefa.Id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int aux = dr.GetInt32(3);

                con.Close();
                

                return aux;
            }
            else
            {
                con.Close();
               
                return -1;
            }

            
        }
    }
}