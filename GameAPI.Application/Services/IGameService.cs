using GameAPI.Domain.Entities;
using GameAPI.Domain.Models;

namespace GameAPI.Application.Services
{
    public interface IGameService
    {
        public Task<Guid> Create(GameModel game);
        public List<GameEntity> GetAll();
        public Task<GameEntity> GetById(Guid id);
        public Task<GameEntity> Update(GameEntity game);
        public Task Delete(Guid id);
    }
}
