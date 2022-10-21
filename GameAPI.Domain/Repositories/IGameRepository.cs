using GameAPI.Domain.Entities;

namespace GameAPI.Domain.Repositories;

public interface IGameRepository
{
    public Task<Guid> Create(GameEntity game);
    public List<GameEntity> GetAll();
    public Task<GameEntity> GetById(Guid id);
    public Task<GameEntity> Update(GameEntity game);
    public Task Delete(Guid entity);
}