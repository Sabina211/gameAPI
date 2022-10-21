namespace GameAPI.Domain.Entities
{
    public class GameEntity: BaseEntity
    {
        public string Name { get; set; } = null!;
        public DeveloperEntity DeveloperStudio { get; set; } = null!;
        //public Guid? DeveloperStudioId { get; set; }
        public List<GenreEntity> Genres { get; set; }
        //public List<Guid>? GenresIds { get; set; }
    }
}
