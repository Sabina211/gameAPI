using GameAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Domain.Repositories
{
    public  interface IGenreRepository
    {
        public Task<GenreEntity> GetById(Guid id);
        public List<GenreEntity> GetAll();
    }
}
