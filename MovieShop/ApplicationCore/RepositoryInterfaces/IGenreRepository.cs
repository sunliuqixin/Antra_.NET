using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IGenreRepository
    {
        Task<Genre> GetById(int id);
        Task<IEnumerable<Genre>> GetAll();
    }
}
