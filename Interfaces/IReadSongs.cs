using System.Collections.Generic;
using api.models;
using api.Interfaces;

namespace api.Interfaces
{
    public interface IReadSongs
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
         
    }
}