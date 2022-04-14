using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.models;
using api.database;
using api.Interfaces;
using MySql;
using MySql.Data.MySqlClient;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs -async
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs readSongs = new ReadSongData(); 
            List<Song> allSongs = readSongs.GetAll();
            allSongs.Sort();
            return allSongs;
        }

        // GET: api/Songs -async/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            IReadSongs readSongs = new ReadSongData(); 
            return readSongs.GetOne(id);
        }

        // POST: api/Songs -async
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            value.SongTimestamp = DateTime.Now;
            value.Favorite = "n";
            Console.WriteLine($"adding {value.SongTitle}");
            CreateSong.Create(value);
        }

        // PUT: api/Songs -async/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song value)
        {
            if (value.Favorite == "y")
            {
                IReadSongs readSong = new ReadSongData(); 
                value = readSong.GetOne(id);
                value.Favorite = "y";
            }
            else if (value.Favorite == "n")
            {
                IReadSongs readSong = new ReadSongData();
                value = readSong.GetOne(id);
                value.Favorite = "n";
            }
            IReadSongs readSongs = new ReadSongData();
            IUpdateSongs editSong = new EditSong();
            editSong.Update(value);
        }

        // DELETE: api/Songs -async/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IReadSongs readSong = new ReadSongData(); 
            Song song = readSong.GetOne(id);
            DeleteSong.Delete(id);
        }
    }
}
