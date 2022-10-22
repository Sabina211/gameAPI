using System.ComponentModel.DataAnnotations;

namespace GameAPI.Domain.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}