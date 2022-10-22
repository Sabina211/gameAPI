using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;

namespace GameAPI.Application.Services
{
    public interface IGameService
    {
        public Task<Guid> Create(GameModel game);
        public List<GameResponseModel> GetAll();
        public Task<GameEntity> GetById(Guid id);
        public Task<List<GameResponseModel>> GetByGenres(List<Guid> ids);
        public Task<GameResponseModel> Update(GameModel game);
        public Task Delete(Guid id);
    }
}
