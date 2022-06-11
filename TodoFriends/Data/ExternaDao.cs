using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoFriends.Models;

namespace TodoFriends.Data
{
    public class ExternaDao
    {


        public static void putAux(Externa externa)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("UPDATE Tarefa SET Horario_Id = @horario, Usuario_Id = @usuario WHERE Id = @id", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = externa.Id;
            cmd.Parameters.Add("@horario", SqlDbType.Int).Value = externa.Horario.Id;
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = externa.Usuario.Id;

            cmd.ExecuteNonQuery();

            SqlCommand comd = new SqlCommand("UPDATE Tarefa_Externa SET Local_Id = @local WHERE Id = @id", con);
            comd.Parameters.Add("@id", SqlDbType.Int).Value = externa.Id;
            comd.Parameters.Add("@local", SqlDbType.Int).Value = externa.Local.Id;

            comd.ExecuteNonQuery();

            con.Close();


        }




    }
}