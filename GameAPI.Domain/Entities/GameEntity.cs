namespace GameAPI.Domain.Entities
{
    public class GameEntity: BaseEntity
    {
        public string Name { get; set; } = null!;
        public DeveloperEntity DeveloperStudio { get; set; } = null!;
        public List<GenreEntity> Genres { get; set; } = null!;
    }
}
