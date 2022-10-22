using GameAPI.Domain.Entities;
using GameAPI.Domain.Exceptions;
using GameAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameDbContext _gameDbContext;

    public GameRepository(GameDbContext gameDbContext)
    {
        _gameDbContext = gameDbContext;
    }

    public async Task<Guid> Create(GameEntity game)
    {
        GameEntity game1 = new GameEntity
        {
            Id = game.Id,
            Name = game.Name,
            DeveloperStudio = game.DeveloperStudio,
            Genres = game.Genres
        };
        var result = await _gameDbContext.Games.AddAsync(game1);
        await _gameDbContext.SaveChangesAsync();

         return result.Entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var game = await _gameDbContext.Games.FirstOrDefaultAsync(x=>x.Id==id);
        if (game == null) throw new EntityNotFoundException($"»гра с id = {id} не найдена");
        _gameDbContext.Games.Remove(game);
        await _gameDbContext.SaveChangesAsync();
    }

    public List<GameEntity> GetAll()
    {
        var result = _gameDbContext.Games
            .Include(x => x.Genres)
            .Include(x => x.DeveloperStudio)
            .ToList();

        return result;
    }

    public async Task<GameEntity> GetById(Guid id)
    {
        var result = await _gameDbContext.Games
            .Include(x => x.Genres)
            .Include(x => x.DeveloperStudio)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (result == null) throw new EntityNotFoundException($"»гра с id = {id} не найдена");
        return result;
    }

    public List<GameEntity> GetByGenres(List<Guid> ids)
    {
        var result = _gameDbContext.Games
            .Include(x => x.Genres)
            .Include(x => x.DeveloperStudio)
            .ToList();

        if (result == null) throw new EntityNotFoundException();

        return result;
    }

    public async Task<GameEntity> Update(GameEntity game)
    {
        var qwe = await GetById(game.Id);
        qwe.Name = game.Name;
        qwe.DeveloperStudio = game.DeveloperStudio;
        qwe.Genres = game.Genres;
        await _gameDbContext.SaveChangesAsync();

        return await GetById(game.Id);
    }
}