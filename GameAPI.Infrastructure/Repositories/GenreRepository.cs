using GameAPI.Domain.Entities;
using GameAPI.Domain.Exceptions;
using GameAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameDbContext _gameDbContext;

        public GenreRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public List<GenreEntity> GetAll()
        {
            var result = _gameDbContext.Genres.ToList();
            return result;
        }

        public Task<GenreEntity> GetById(Guid id)
        {
            var result = _gameDbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) throw new EntityNotFoundException();
            return result;
        }
    }
}
