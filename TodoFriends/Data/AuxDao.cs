using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TodoFriends.Data
{
    public class AuxDao
    {

        public static void deleteTrash()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("DELETE FROM Comodo WHERE Nome is null", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}