namespace GameAPI.Domain.Entities;

public class GenreEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<GameEntity>? Games { get; set; }
}