using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;
using GameAPI.Domain.Repositories;
using System.Xml.Linq;

namespace GameAPI.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IDeveloperRepository developerRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Create(GameModel game)
        {
            return await _gameRepository.Create(new GameEntity
            {
                Id = game.Id,
                Name = game.Name,
                DeveloperStudio = await _developerRepository.GetById(game.DeveloperStudioId),
                Genres = await _genreRepository.GetByIds(game.GenresIds)
            }) ;
        }

        public async Task Delete(Guid id)
        {
            await _gameRepository.Delete(id);
        }

        public List<GameResponseModel> GetAll()
        {
            var result = _gameRepository.GetAll()
                .Select(x => new GameResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Developer = x.DeveloperStudio,
                    Genres = x.Genres.Select(p=>new GenreModel {Id = p.Id, Name=p.Name }).ToList()
                }).ToList() ;
            return result;
        }

        public async Task<GameEntity> GetById(Guid id)
        {
            return await _gameRepository.GetById(id);
        }

        public async Task<GameEntity> Update(GameEntity game)
        {
            return await _gameRepository.Update(game);
        }
    }
}
