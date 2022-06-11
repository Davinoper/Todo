using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoFriends.Models;

namespace TodoFriends.Data
{
    public class ResidencialDao
    {

        public static void putAux(Residencial residencial)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("UPDATE Tarefa SET Horario_Id = @horario, Usuario_Id = @usuario WHERE Id = @id", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = residencial.Id;
            cmd.Parameters.Add("@horario", SqlDbType.Int).Value = residencial.Horario.Id;
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = residencial.Usuario.Id;

            cmd.ExecuteNonQuery();

        }


    }
}