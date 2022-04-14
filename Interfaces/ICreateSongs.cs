using api.models;
using api.Interfaces;

namespace api.Interfaces
{
    public interface ICreateSongs
    {
         public void Create(Song song);
    }
}