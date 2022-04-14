using System;
using System.Collections.Generic;
using api.Interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadSongData : IReadSongs
    {
        public List<Song> GetAll()
        {
            List<Song> playlist = new List<Song>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM songs WHERE deleted = 'n'";

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Song tempSong = new Song(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorite = rdr.GetString(4)};
                playlist.Add(tempSong);
            }

            return playlist;
        }

        public Song GetOne(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con= new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM songs WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            Song song = new Song();
            List<Song> playlist = new List<Song>();

            while(rdr.Read())
                {
                    song = new Song(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorite = rdr.GetString(4)};  
                }
            return song;
        }
    }
}