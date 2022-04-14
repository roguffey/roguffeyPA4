using System;
using System.Collections.Generic;
using api.Interfaces;
using api.models;
using api;
using MySql.Data.MySqlClient;
using MySql;
using System.Data;

namespace api.database
{
    public class CreateSong : ICreateSongs
    {

        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE IF NOT EXISTS songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, dateadded DATETIME, deleted text, favorite text);";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void Create(){}
        public static void Create(Song s)
        {
            CreateSongTable();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            DateTime tempDate = DateTime.Now;

            string stm = @"INSERT INTO songs(title, dateadded, deleted, favorite) VALUES(@title, @dateadded, @deleted, @favorite);";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", s.SongTitle);
            cmd.Parameters.AddWithValue("@dateadded", tempDate);
            cmd.Parameters.AddWithValue("@deleted", "n");
            cmd.Parameters.AddWithValue("@favorite", "n");

            Console.WriteLine("before prepare");

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            string stm2 = @"Select * FROM Songs ORDER BY dateadded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);
        }

        void ICreateSongs.Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            DateTime tempDate = DateTime.Now;

            string stm3 = "Select * FROM songs ORDER BY id DESC";
            using var cmd3 = new MySqlCommand(stm3,con);

            using MySqlDataReader rdr = cmd3.ExecuteReader();

            rdr.Read();

            string stm = @"INSERT INTO songs(title, dateadded, deleted, favorite) VALUES(@title, @dateadded, @deleted, @favorite)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@dateadded", tempDate);
            cmd.Parameters.AddWithValue("@Deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@Favorite", song.Favorite);

            cmd3.Prepare();
            cmd.Prepare();

            string stm2 = "Select * FROM Songs ORDER BY dateadded DESC";
            using var cmd2 = new MySqlCommand(stm2,con);

            cmd.ExecuteNonQuery();
        }
    }
}