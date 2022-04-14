using System;
using api.Interfaces;
using api.database;

namespace api.models
{
    public class Song: IComparable<Song>
    {
        // auto implemented properties
        public int SongID {get; set;}
        public string SongTitle {get; set;}
        public DateTime SongTimestamp {get; set;}
        public string Deleted { get; set; }

        public string Favorite {get; set;}

        // private ICreateSongs Create {get; set;}

        // private IDeleteSongs Delete {get; set;}

        // private IUpdateSongs Update {get; set;}

        // public Song()
        // {
        //     Create = new CreateSong();

        //     Delete = new DeleteSong();

        //     Update = new EditSong();
        // }


        // public override string ToString() // overriding the ToString for the song class to include all properties of the class
        // {
        //     return SongTitle + " (ID: " + SongID + ", Added " + SongTimestamp + ")";
        // }

        // public string ToFile(){
        //     return SongID + "#" + SongTitle + "#" + SongTimestamp + "#" + Deleted;
        // }

        public int CompareTo(Song temp) { // since I am using IComparable, I need a CompareTo for "contract"
            return -this.SongTimestamp.CompareTo(temp.SongTimestamp); // negative sign allows the timestamps to be sorted in descending order
        }
    }
}