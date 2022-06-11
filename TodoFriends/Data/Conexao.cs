using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TodoFriends.Data
{
    public class Conexao
    {

        SqlConnection con = new SqlConnection();
        public Conexao()
        {

            con.ConnectionString = @"Data Source=LAPTOP-6OQDIIJJ\SQLEXPRESS;Initial Catalog=TodoFriends;Integrated Security=True";


        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    
                }

            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }


        }











    }
}