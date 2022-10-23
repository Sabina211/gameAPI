using GameAPI.Domain.Entities;

namespace GameAPI.Infrastructure
{
    public class CreateTestData
    {       
        public static void CreateData(GameDbContext gameDbContext)
        {
            gameDbContext.Database.EnsureCreated();
            if (gameDbContext.Genres.Any()) return;
            var genres = new List<GenreEntity>
            {
            new GenreEntity() { Id = Guid.NewGuid(),  Name= "Действие" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Приключения" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Симулятор" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Стратегия" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Головоломка" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Ролевая игра" },
            new GenreEntity() { Id = Guid.NewGuid(),  Name = "Смешанный жанр" }
            };
            using (var trans = gameDbContext.Database.BeginTransaction())
            {
                foreach (var genre in genres)
                {
                    gameDbContext.Genres.Add(genre);
                }
                gameDbContext.SaveChanges();
                trans.Commit();
            }

            if (gameDbContext.Developers.Any()) return;
            var developers = new List<DeveloperEntity> 
            { 
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Rockstar North"},
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Nintendo"},
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Blizzard Entertainment"},
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Epic Games"},
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Capcom"},
                new DeveloperEntity(){ Id = Guid.NewGuid(),  Name= "Ubisoft"}

            };
            using (var trans = gameDbContext.Database.BeginTransaction())
            {
                foreach (var developer in developers)
                {
                    gameDbContext.Developers.Add(developer);
                }
                gameDbContext.SaveChanges();
                trans.Commit();
            }

            var adv =  gameDbContext.Genres.FirstOrDefault(x=>x.Name.Contains("Приключения"));
            var nintendo = gameDbContext.Developers.FirstOrDefault(x => x.Name.Contains("Nintendo"));
            if (adv == null || nintendo == null) return;
            var game = new GameEntity
            { Id = Guid.NewGuid(),  Name = "Super Mario Odyssey", 
                Genres = new List<GenreEntity>{ adv }, DeveloperStudio= nintendo  
            };
            using (var trans = gameDbContext.Database.BeginTransaction())
            {
                gameDbContext.Games.Add(game);
                gameDbContext.SaveChanges();
                trans.Commit();
            }

        }
    }
}
