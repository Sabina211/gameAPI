using GameAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Domain.Models
{
    public class GameModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public Guid DeveloperStudioId { get; set; } 
        public List<Guid>? GenresIds { get; set; }
    }
}
