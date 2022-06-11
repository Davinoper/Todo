using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoFriends.Models;

namespace TodoFriends.Data
{
    public class LocalDao
    {


        public static int findIdByTarefa(Externa tarefa)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tarefa_Externa WHERE Id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = tarefa.Id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                return dr.GetInt32(1);
            }
            else
            {
                return -1;
            }
        }

        public static bool containLocal(Tarefa tarefa)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tarefa_Externa WHERE Id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = tarefa.Id;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                dr.Close();
                return true;
            }
            else
            {
                con.Close();
                dr.Close();
                return false;
                
            }
        }
    }
}