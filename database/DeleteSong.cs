using System;
using System.Collections.Generic;
using api.Interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class DeleteSong : IDeleteSongs
    {
        public static void DropSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET deleted = @deleted WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@deleted", "y");
            cmd.Prepare();

            string stm2 = "Select * FROM Songs ORDER BY TimeAdded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);
            cmd.ExecuteNonQuery();
        }

        
        void IDeleteSongs.Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET deleted = @deleted WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@deleted", "y");
            cmd.Prepare();

            string stm2 = "Select * FROM Songs ORDER BY TimeAdded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);
            cmd.ExecuteNonQuery();
        }
    }
}