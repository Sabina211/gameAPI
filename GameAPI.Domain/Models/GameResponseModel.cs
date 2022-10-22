using GameAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Domain.Models
{
    public class GameResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DeveloperEntity Developer { get; set; } = null!;
        public List<GenreModel>? Genres { get; set; }
    }
}
