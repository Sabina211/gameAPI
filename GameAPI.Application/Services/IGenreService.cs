using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Application.Services
{
    public interface IGenreService
    {
        public List<GenreModel> GetAll();
    }
}
