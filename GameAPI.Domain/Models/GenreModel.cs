using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Domain.Models
{
    public class GenreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
