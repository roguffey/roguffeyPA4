using System;
using System.Collections.Generic;
using api.Interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class EditSong : IUpdateSongs
    {
        public void Update(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE Songs SET favorite = @favoite WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@favorite", "y");
            cmd.Parameters.AddWithValue("@id", song.SongID);
            

            cmd.Prepare();

            string stm2 = "Select * FROM Songs ORDER BY TimeAdded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);

            cmd.ExecuteNonQuery();
        }

        void IUpdateSongs.Update(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET favorite = @favorite WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@favorite", song.Favorite);
            cmd.Parameters.AddWithValue("@id", song.SongID);

            cmd.Prepare();

            string stm2 = "Select * FROM Songs ORDER BY TimeAdded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);

            cmd.ExecuteNonQuery();
        }
    }
}