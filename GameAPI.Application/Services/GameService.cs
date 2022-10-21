using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;
using GameAPI.Domain.Repositories;

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
                Genres = new List<GenreEntity>(){ await _genreRepository.GetById(game.GenresIds[0]) }
            }); ;
        }

        public async Task Delete(Guid id)
        {
            await _gameRepository.Delete(id);
        }

        public List<GameEntity> GetAll()
        {
            return _gameRepository.GetAll();
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
