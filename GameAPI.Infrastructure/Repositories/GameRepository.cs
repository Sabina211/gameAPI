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
        var genre = await _gameDbContext.Genres.FirstOrDefaultAsync(x => x.Id == game.Genres[0].Id);
        var developer = await _gameDbContext.Developers.FirstOrDefaultAsync(x => x.Id == game.DeveloperStudio.Id);
        if (genre == null) throw new Exception("Нет жанра с таким id");
        if (developer == null) throw new Exception("Нет разработчика с таким id");
        GameEntity game1 = new GameEntity
        {
            Id = game.Id,
            Name = game.Name,
            DeveloperStudio = developer,
            Genres = new List<GenreEntity> { genre }
        };
        var result = await _gameDbContext.Games.AddAsync(game1);
        await _gameDbContext.SaveChangesAsync();

         return result.Entity.Id;
        //return Guid.Empty;
    }

    public async Task Delete(Guid entity)
    {
        var game = await _gameDbContext.Games.FirstOrDefaultAsync();
        if (game == null) throw new EntityNotFoundException();
        _gameDbContext.Games.Remove(game);
        await _gameDbContext.SaveChangesAsync();
    }

    public List<GameEntity> GetAll()
    {
        //var result = _gameDbContext.Games.ToList();
        var res = _gameDbContext.Games
            .Include(x => x.Genres)
            .Include(x => x.DeveloperStudio)
            .ToList();

        return res;
    }

    public async Task<GameEntity> GetById(Guid id)
    {
        var result = await _gameDbContext.Games
            .Include(x => x.Genres)
            .Include(x => x.DeveloperStudio)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (result == null) throw new EntityNotFoundException();

        return result;
    }

    public async Task<GameEntity> Update(GameEntity game)
    {
        var result = _gameDbContext.Games.Update(game);
        await _gameDbContext.SaveChangesAsync();
        return result.Entity;
    }
}