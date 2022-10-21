using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;
using GameAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<GenreModel> GetAll()
        {
            var genres = _genreRepository.GetAll();
            var genresModel = new List<GenreModel>();
            foreach (var item in genres)
            {
                genresModel.Add(new GenreModel { Id= item.Id, Name=item.Name});
            }
            return genresModel;
        }
    }
}
